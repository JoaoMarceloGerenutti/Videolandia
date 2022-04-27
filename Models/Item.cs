using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Titulo { get; set; }
        public List<Genero> Generos { get; set; }
        public DateTime Lancamento { get; set; }
        public bool Tipo { get; set; }
        public float Preco { get; set; }
        public DateTime DataAquisicao { get; set; }
        public float Valor { get; set; }
        public bool Situacao { get; set; }
        public List<Ator> Atores { get; set; }
        public string Diretor { get; set; }
        public string Capa { get; set; }
    }
}
