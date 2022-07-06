using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_iate_facil.Models
{
    public class EntityLoginUpdate
    {
        public string Usuario { get; set; }
        public string SenhaAtual { get; set; }
        public string SenhaNova { get; set; }
    }
}
