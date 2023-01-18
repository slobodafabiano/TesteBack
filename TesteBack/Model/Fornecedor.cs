using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteBack.Model
{
    public class Fornecedor
    {
        [Key]
        public int idFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

      

    }
}
