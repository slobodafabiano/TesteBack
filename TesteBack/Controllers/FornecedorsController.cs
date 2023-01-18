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
    public class FornecedorsController : ControllerBase
    {
        private readonly TesteBackContext _context;

        public FornecedorsController(TesteBackContext context)
        {
            _context = context;
        }

        // Cadastrar
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();
            return Ok(fornecedor);
        }
        //Editar
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Fornecedor fornecedor)
        {
            var fornecedorExistente = await _context.Fornecedor.FindAsync(id);
            if (fornecedorExistente == null)
                return NotFound();

            fornecedorExistente.Nome = fornecedor.Nome;
            fornecedorExistente.Cnpj = fornecedor.Cnpj;
            fornecedorExistente.Telefone = fornecedor.Telefone;
            fornecedorExistente.Email = fornecedor.Email;
            await _context.SaveChangesAsync();
            return Ok(fornecedorExistente);
        }

        // Obter Fornecedor Único
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterFornecedorUnico(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }


        // Obter Fornecedor Filtro
        [HttpGet]
        public async Task<IActionResult> ObterFornecedorFiltro(string? nome = "", string? cnpj = "", string? cidade = "")
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();


            if (!string.IsNullOrEmpty(nome))
                fornecedores = _context.Fornecedor.Where(x => x.Nome.Contains(nome)).ToList();

            if (!string.IsNullOrEmpty(cnpj))
                fornecedores = _context.Fornecedor.Where(x => x.Cnpj.Contains(cnpj)).ToList();
            if (!string.IsNullOrEmpty(cidade))
                fornecedores = _context.Endereco.Include(x => x.Fornecedor).Where(x => x.Cidade.Contains(cidade)).Select(x => x.Fornecedor).ToList();


            if (fornecedores == null)
                return NotFound();

            return Ok(fornecedores);
        }


    }
}
