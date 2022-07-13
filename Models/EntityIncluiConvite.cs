using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_iate_facil.Models
{
    public class EntityIncluiConvite
    {
        public string Usuario { get; set; }
        public string NomeConvidado { get; set; }
        public string CpfConvidado { get; set; }
        public string DataNascimento { get; set; }
        public string NrDocEstrangeiro { get; set; }
        public string CategoriaConvite { get; set; }
        public string IP { get; set; }
    }
}
