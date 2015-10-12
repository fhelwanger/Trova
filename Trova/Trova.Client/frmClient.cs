using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trova.Client
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var c = new System.Net.Sockets.TcpClient("localhost", 1337);
            var f = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            f.Serialize(c.GetStream(), new Trova.Core.Requests.Entrar() { Apelido = "Fernando" });

            var resp = f.Deserialize(c.GetStream());
            
                
        }
    }
}
