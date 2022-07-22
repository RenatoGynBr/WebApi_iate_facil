using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_iate_facil.Models
{
    public class EntityAgendaServicoAcademia
    {
        public int Matricula { get; set; }
        public int Categoria { get; set; }
        public int Dependente { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int Servico { get; set; }
        public int Funcionario { get; set; }
        public int Agenda { get; set; }
        public int Excecao { get; set; }
        public string Usuario { get; set; }
    }
}
