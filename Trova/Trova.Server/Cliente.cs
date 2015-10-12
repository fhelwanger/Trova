using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Trova.Server
{
    public class Cliente
    {
        private TcpClient tcpClient;
        private Task monitorarMensagens;
        private bool parar;

        public string Apelido { get; set; }
        
        public delegate void ClienteEnviouMensagemHandler(Cliente sender, object mensagem);
        public event ClienteEnviouMensagemHandler ClienteEnviouMensagem;

        public delegate void ClienteDisparouExceptionHandler(Cliente sender, Exception ex);
        public event ClienteDisparouExceptionHandler ClienteDisparouException;

        public delegate void ClienteDesconectouHandler(Cliente sender);
        public event ClienteDesconectouHandler ClienteDesconectou;

        public Cliente(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }

        public void Iniciar()
        {
            parar = false;
            monitorarMensagens = Task.Run(new Action(MonitorarMensagens));
        }

        public void Enviar(object objeto)
        {
            try
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(tcpClient.GetStream(), objeto);
            }
            catch (Exception ex)
            {
                ClienteDisparouException(this, ex);
            }
        }

        public object Receber()
        {
            try
            {
                var formatter = new BinaryFormatter();

                return formatter.Deserialize(tcpClient.GetStream());
            }
            catch (Exception ex)
            {
                ClienteDisparouException(this, ex);
                return null;
            }
        }

        public void Encerrar()
        {
            parar = true;

            if (monitorarMensagens != null)
            {
                monitorarMensagens.Wait(5000);
            }

            if (tcpClient.Connected)
            {
                tcpClient.Close();
            }
        }

        private void MonitorarMensagens()
        {
            while (!parar)
            {
                if (!tcpClient.Connected)
                {
                    ClienteDesconectou(this);
                    break;
                }
            }
        }
    }
}
