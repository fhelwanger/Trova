using System.Windows.Forms;
using Trova.Core;

namespace Trova.Client
{
    public partial class frmMensagens : Form
    {
        private Cliente cliente;

        public frmMensagens(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
        }

        private void frmMensagens_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
