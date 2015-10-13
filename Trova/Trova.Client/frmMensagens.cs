using System;
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
        }

        private void TratarMensagemPublica(MensagemPublica mensagem)
        {
            Invoke(new Action(() =>
            {
                txtMensagens.AppendText($"{mensagem.Origem}: {mensagem.Mensagem}\n");
            }));
        }

        private void frmMensagens_Load(object sender, System.EventArgs e)
        {
            txtMensagem.Focus();
        }

        private void frmMensagens_FormClosed(object sender, FormClosedEventArgs e)
        {
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
    }
}
