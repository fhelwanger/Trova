using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trova.Server
{
    public partial class frmServer : Form
    {
        private Servidor servidor;

        public frmServer()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Tag == null)
            {
                Iniciar();
                btnIniciar.Tag = "1";
            }
            else
            {
                Parar();
                btnIniciar.Tag = null;
            }
        }

        private void Iniciar()
        {
            int porta;

            if (!int.TryParse(txtPorta.Text, out porta))
            {
                MessageBox.Show("Preencha a porta corretamente.", "Trova", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorta.Focus();
                return;
            }

            servidor = new Servidor(porta);
            servidor.ListaClientesMudou += servidor_ListaClientesMudou;
            servidor.Iniciar();

            txtPorta.Enabled = false;
            btnIniciar.Text = "Parar";
        }

        private void Parar()
        {
            servidor.Parar();
            servidor.ListaClientesMudou -= servidor_ListaClientesMudou;
            servidor = null;

            txtPorta.Enabled = true;
            btnIniciar.Text = "Iniciar";
        }

        private void servidor_ListaClientesMudou(IEnumerable<string> lista)
        {
            Invoke(new Action(() => lstClientesConectados.DataSource = lista));
        }
    }
}
