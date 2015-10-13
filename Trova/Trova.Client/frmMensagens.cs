using System;
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
            if (mensagem as MensagemPublica != null)
            {
                TratarMensagemPublica((MensagemPublica)mensagem);    
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
        
        private void TratarMensagemPublica(MensagemPublica mensagem)
        {
            AdicionarTexto($"{mensagem.Origem}: {mensagem.Mensagem}");
        }

        private void TratarAvisoServidor(AvisoServidor aviso)
        {
            AdicionarTexto(aviso.Aviso);
        }

        private void TratarListaConectados(ListaClientesConectados lista)
        {
            Invoke(new Action(() =>
            {
                lstClientes.DataSource = (lista).Apelidos;
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
            var mensagem = new EnviarMensagemPublica()
            {
                Origem = cliente.Apelido,
                Mensagem = txtMensagem.Text
            };

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
