using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBack.Data;
using TesteBack.Model;

namespace TesteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoesController : ControllerBase
    {
        private readonly TesteBackContext _context;

        public EnderecoesController(TesteBackContext context)
        {
            _context = context;
        }

        // Cadastrat
        
        [HttpPost]
        public async Task<ActionResult<Endereco>> CadastrarEndereco(Endereco endereco)
        {
            var fornecedorExistente = await _context.Fornecedor.FindAsync(endereco.Fornecedor_id);
            if (fornecedorExistente == null)
                return NotFound();

            endereco.Fornecedor = fornecedorExistente;
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            return Ok(endereco);
            
        }


        // Editar
       
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarEndereco(int id, Endereco endereco)
        {
            var EndExistente = await _context.Endereco.FindAsync(id);
            if (EndExistente == null)
                return NotFound();



            var fornecedorExistente = await _context.Fornecedor.FindAsync(endereco.Fornecedor_id);
            if (fornecedorExistente == null)
                return NotFound();

            EndExistente.Fornecedor = fornecedorExistente;
            EndExistente.Cep = endereco.Cep;
            EndExistente.Complemento = endereco.Complemento;
            EndExistente.Estado = endereco.Estado;
            EndExistente.Cidade = endereco.Cidade;
            EndExistente.Pais = endereco.Pais;
            EndExistente.Numero = endereco.Numero;
            EndExistente.Rua =endereco.Rua;

            _context.Entry(EndExistente).State = EntityState.Modified;
            _context.Entry(EndExistente.Fornecedor).State = EntityState.Unchanged;

            await _context.SaveChangesAsync();

            return Ok(EndExistente);
        }


        // GET: api/Enderecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return await _context.Endereco.Include(x=>x.Fornecedor).ToListAsync();
        }

        
    }
}
