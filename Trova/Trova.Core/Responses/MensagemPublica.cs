using System;

namespace Trova.Core.Responses
{
    [Serializable]
    public class MensagemPublica
    {
        public string Origem { get; set; }
        public string Mensagem { get; set; }
    }
}
