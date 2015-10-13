using System;

namespace Trova.Core.Requests
{
    [Serializable]
    public class EnviarMensagemPublica
    {
        public string Origem { get; set; }
        public string Mensagem { get; set; }
    }
}
