using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Email
    {
        public int CodigoEmail { get; set; }
        public string EmailRemetente { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
