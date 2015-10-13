using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Trova.Core;
using Trova.Core.Requests;
using Trova.Core.Responses;

namespace Trova.Client
{
    public partial class frmEntrar : Form
    {
        private bool abriuMensagens = false;

        public frmEntrar()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            int porta;

            if (string.IsNullOrWhiteSpace(txtHost.Text))
            {
                MessageBox.Show("Preencha o host corretamente.", "Trova", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtHost.Focus();
                return;
            }

            if (!int.TryParse(txtPorta.Text, out porta))
            {
                MessageBox.Show("Preencha a porta corretamente.", "Trova", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApelido.Text))
            {
                MessageBox.Show("Preencha o apelido corretamente.", "Trova", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApelido.Focus();
                return;
            }
            
            TcpClient tcpClient;

            try
            {
                tcpClient = new TcpClient(txtHost.Text, porta);
            }
            catch (Exception)
            {
                MessageBox.Show("Falha ao conectar com o servidor.", "Trova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cliente = new Cliente(tcpClient);
            cliente.Apelido = txtApelido.Text;

            cliente.Enviar(new Entrar() { Apelido = cliente.Apelido });

            var resp = cliente.Receber();

            if (resp as Ok != null)
            {
                var frm = new frmMensagens(cliente);
                frm.Show();

                abriuMensagens = true;

                Close();
                
            }
            else if (resp as Erro != null)
            {
                var erro = (Erro)resp;
                MessageBox.Show(erro.Mensagem, "Trova", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEntrar_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!abriuMensagens)
            {
                Application.Exit();
            }
        }
    }
}
