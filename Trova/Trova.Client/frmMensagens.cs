using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trova.Core;
using Trova.Core.Requests;
using Trova.Core.Responses;

namespace Trova.Client
{
    public partial class frmMensagens : Form
    {
        private Cliente cliente;

        public frmMensagens(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.cliente.RecebeuMensagem += cliente_ClienteRecebeuMensagem;
            this.cliente.Iniciar();
        }

        private void cliente_ClienteRecebeuMensagem(Cliente sender, object mensagem)
        {
            if (mensagem as Mensagem != null)
            {
                TratarMensagem((Mensagem)mensagem);    
            }
            else if (mensagem as AvisoServidor != null)
            {
                TratarAvisoServidor((AvisoServidor)mensagem);
            }
            else if (mensagem as ListaClientesConectados != null)
            {
                TratarListaConectados((ListaClientesConectados)mensagem);
            }
        }
        
        private void TratarMensagem(Mensagem mensagem)
        {
            AdicionarTexto($"{mensagem.Origem}: {mensagem.Texto}");
        }

        private void TratarAvisoServidor(AvisoServidor aviso)
        {
            AdicionarTexto(aviso.Aviso);
        }

        private void TratarListaConectados(ListaClientesConectados lista)
        {
            var ds = new List<string>();

            ds.Add("Todos");
            ds.AddRange(lista.Apelidos);

            Invoke(new Action(() =>
            {
                lstClientes.DataSource = ds;
            }));
        }

        private void frmMensagens_Load(object sender, EventArgs e)
        {
            txtMensagem.Focus();
        }

        private void frmMensagens_FormClosed(object sender, FormClosedEventArgs e)
        {
            cliente.Enviar(new Desconectar());
            Task.Delay(100).Wait();
            Application.Exit();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarMensagem();
        }
        
        private void txtMensagem_TextChanged(object sender, EventArgs e)
        {
            btnEnviar.Enabled = (txtMensagem.Text.Length > 0);
        }

        private void txtMensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnEnviar.Enabled)
            {
                EnviarMensagem();
            }
        }

        private void EnviarMensagem()
        {
            object mensagem;

            if (lstClientes.SelectedIndex <= 0)
            {
                mensagem = new EnviarMensagemPublica()
                {
                    Origem = cliente.Apelido,
                    Mensagem = txtMensagem.Text
                };
            }
            else
            {
                mensagem = new EnviarMensagemPrivada()
                {
                    Destino = lstClientes.Text,
                    Origem = cliente.Apelido,
                    Mensagem = txtMensagem.Text
                };
            }
            
            cliente.Enviar(mensagem);

            txtMensagem.Clear();
        }

        private void AdicionarTexto(string texto)
        {
            Invoke(new Action(() =>
            {
                txtMensagens.AppendText(texto);
                txtMensagens.AppendText("\r\n");
            }));
        }
    }
}
