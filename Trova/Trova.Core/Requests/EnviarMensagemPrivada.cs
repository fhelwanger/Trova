using System;

namespace Trova.Core.Requests
{
    [Serializable]
    public class EnviarMensagemPrivada : EnviarMensagemPublica
    {
        public string Destino { get; set; }
    }
}
