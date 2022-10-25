using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliação.DTO
{
    internal class VeiculoDTO
    {
        private int id_veiculo;
        private string nome;
        private string modelo;
        private string ano;
        private string tipo;

        public int Id_veiculo { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Tipo { get; set; }
    }
}
