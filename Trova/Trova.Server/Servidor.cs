using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
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
            cliente.ClienteEnviouMensagem += OnClienteEnviouMensagem;
            cliente.ClienteDisparouException += OnClienteDisparouException;
            cliente.ClienteDesconectou += OnClienteDesconectou;

            lock (this)
            {
                clientes.Add(cliente.Apelido, cliente);
                NotificarMudancaListaClientes();
            }

            cliente.Enviar(new Ok());
            cliente.Iniciar();
        }

        private void FinalizarCliente(Cliente cliente)
        {
            cliente.Encerrar();
            cliente.ClienteEnviouMensagem -= OnClienteEnviouMensagem;
            cliente.ClienteDisparouException -= OnClienteDisparouException;
            cliente.ClienteDesconectou -= OnClienteDesconectou;
        }

        private void OnClienteEnviouMensagem(Cliente sender, object mensagem)
        {

        }

        private void OnClienteDisparouException(Cliente sender, Exception ex)
        {

        }

        private void OnClienteDesconectou(Cliente cliente)
        {
            FinalizarCliente(cliente);

            lock (this)
            {
                clientes.Remove(cliente.Apelido);
                NotificarMudancaListaClientes();
            }
        }

        private void NotificarMudancaListaClientes()
        {
            ListaClientesMudou(clientes.Keys.ToList());
        }
    }
}
