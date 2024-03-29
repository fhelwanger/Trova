﻿using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Trova.Core
{
    public class Cliente
    {
        private TcpClient tcpClient;
        private Task monitorarMensagens;
        private bool parar;

        public string Apelido { get; set; }
        
        public delegate void RecebeuMensagemHandler(Cliente sender, object mensagem);
        public event RecebeuMensagemHandler RecebeuMensagem;

        public delegate void DisparouExceptionHandler(Cliente sender, Exception ex);
        public event DisparouExceptionHandler DisparouException;

        public delegate void DesconectouHandler(Cliente sender);
        public event DesconectouHandler Desconectou;

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
                Task.Run(() => OnDisparouException(ex));
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
                Task.Run(() => OnDisparouException(ex));
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
                    Task.Run(() => OnDesconectou());
                    break;
                }

                if (tcpClient.Available == 0)
                {
                    Task.Delay(10).Wait();
                    continue;
                }

                var msg = Receber();
                Task.Run(() => OnRecebeuMensagem(msg));
            }
        }

        private void OnRecebeuMensagem(object mensagem)
        {
            if (RecebeuMensagem != null && mensagem != null)
            {
                RecebeuMensagem(this, mensagem);
            }
        }

        private void OnDisparouException(Exception ex)
        {
            if (DisparouException != null)
            {
                DisparouException(this, ex);
            }
        }

        private void OnDesconectou()
        {
            if (Desconectou != null)
            {
                Desconectou(this);
            }
        }
    }
}
