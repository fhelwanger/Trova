using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Trova.Core;
using Trova.Core.Requests;
using Trova.Core.Responses;

namespace Trova.Server
{
    public class Servidor
    {
        private TcpListener listener;
        private int porta;
        private Task aguardarConexoes;
        private bool parar;
        private IDictionary<string, Cliente> clientes;

        public delegate void ListaClientesMudouHandler(IList<string> lista);
        public event ListaClientesMudouHandler ListaClientesMudou;

        public Servidor(int porta)
        {
            this.porta = porta;
        }

        public void Iniciar()
        {
            parar = false;
            
            listener = new TcpListener(IPAddress.Any, porta);
            listener.Start();

            clientes = new Dictionary<string, Cliente>();

            aguardarConexoes = Task.Run(new Action(AguardarConexoes));
        }

        public void Parar()
        {
            parar = true;

            if (aguardarConexoes != null)
            {
                aguardarConexoes.Wait(5000);
            }

            if (clientes != null)
            {
                foreach (var cliente in clientes.Values)
                {
                    FinalizarCliente(cliente);
                }

                clientes.Clear();
                NotificarMudancaListaClientes();
            }
        }

        private void AguardarConexoes()
        {
            while (!parar)
            {
                if (listener.Pending())
                {
                    AceitarNovoCliente(listener.AcceptTcpClient());
                }
                else
                {
                    Task.Delay(10).Wait();
                }
            }
        }
        
        private void AceitarNovoCliente(TcpClient tcpClient)
        {
            var cliente = new Cliente(tcpClient);

            var entrar = (Entrar)cliente.Receber();

            if (clientes.ContainsKey(entrar.Apelido))
            {
                cliente.Enviar(new Erro() { Mensagem = "Apelido já está em uso." });
                cliente.Encerrar();
                return;
            }

            cliente.Apelido = entrar.Apelido;
            cliente.RecebeuMensagem += cliente_RecebeuMensagem;
            cliente.DisparouException += cliente_DisparouException;
            cliente.Desconectou += cliente_Desconectou;

            lock (this)
            {
                clientes.Add(cliente.Apelido, cliente);
                cliente.Enviar(new Ok());
                NotificarMudancaListaClientes();
            }

            EnviarMensagem(new AvisoServidor()
            {
                Aviso = $"{cliente.Apelido} entrou na sala."
            });

            cliente.Iniciar();
        }

        private void FinalizarCliente(Cliente cliente)
        {
            cliente.Encerrar();
            cliente.RecebeuMensagem -= cliente_RecebeuMensagem;
            cliente.DisparouException -= cliente_DisparouException;
            cliente.Desconectou -= cliente_Desconectou;
        }
        
        private void EnviarMensagem(object mensagem)
        {
            lock (this)
            {
                foreach (var cliente in clientes.Values)
                {
                    cliente.Enviar(mensagem);
                }
            }
        }

        private void cliente_RecebeuMensagem(Cliente sender, object mensagem)
        {
            if (mensagem as EnviarMensagemPrivada != null)
            {
                TratarMensagemPrivada((EnviarMensagemPrivada)mensagem);
            }
            else if (mensagem as EnviarMensagemPublica != null)
            {
                TratarMensagemPublica((EnviarMensagemPublica)mensagem);
            }
            else if (mensagem as Desconectar != null)
            {
                cliente_Desconectou(sender);
            }
        }

        private void TratarMensagemPublica(EnviarMensagemPublica mensagem)
        {
            EnviarMensagem(new Mensagem()
            {
                Origem = mensagem.Origem,
                Texto = mensagem.Mensagem
            });
        }

        private void TratarMensagemPrivada(EnviarMensagemPrivada mensagem)
        {
            var msg = new Mensagem()
            {
                Origem = mensagem.Origem,
                Texto = mensagem.Mensagem
            };

            if (mensagem.Origem != mensagem.Destino)
            {
                clientes[mensagem.Origem].Enviar(msg);
            }
            
            clientes[mensagem.Destino].Enviar(msg);
        }

        private void cliente_DisparouException(Cliente sender, Exception ex)
        {
            // TODO: Log?
        }

        private void cliente_Desconectou(Cliente cliente)
        {
            FinalizarCliente(cliente);

            lock (this)
            {
                clientes.Remove(cliente.Apelido);
                NotificarMudancaListaClientes();
            }

            EnviarMensagem(new AvisoServidor()
            {
                Aviso = $"{cliente.Apelido} saiu da sala."
            });
        }

        private void NotificarMudancaListaClientes()
        {
            if (ListaClientesMudou != null)
            {
                ListaClientesMudou(clientes.Keys.ToList());
            }
            
            EnviarMensagem(new ListaClientesConectados()
            {
                Apelidos = clientes.Keys.ToArray()
            });
        }
    }
}
