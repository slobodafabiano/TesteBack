using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBack.Model
{
    public class Endereco
    {

        [Key]
        public int id { get; set; }        
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public virtual int Fornecedor_id { get; set; }
        public  Fornecedor Fornecedor { get; set; }
    }
}