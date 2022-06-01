using Microsoft.AspNetCore.Mvc;
using ApiComMysql.Models;

namespace ApiComMysql.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ModeloController : ControllerBase
{
    //inicia o contexto que irá acessar o banco
    private readonly ModeloContext _context;
    public ModeloController(ModeloContext context)
    {
        _context = context;
    }

    //Recupera um modelo
    [HttpGet("{id}")]
    public IActionResult GetModelo(int id)
    {
        Modelo modelo = _context.Modelos.FirstOrDefault(m => m.Id == id);
        if (modelo != null)
        {
            return Ok(modelo);
        }
        return BadRequest("Modelo não encontrado");
    }

    //Recupera todos os modelos
    [HttpGet("lista/")]
    public IEnumerable<Modelo> GetModelos()
    {
        IEnumerable<Modelo> modelos = _context.Modelos;

        return modelos;
    }

    //Cadastra um modelo
    [HttpPost]
    public IActionResult PostModelo([FromBody] Modelo modelo)
    {
        if (!ModelState.IsValid)
            return BadRequest("Não foi possível criar o modelo");

        modelo.DataCriacao = DateTime.Now;
        _context.Modelos.Add(modelo);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetModelo), new { id = modelo.Id }, modelo);

    }

    //Apagar Modelo
    [HttpDelete("{id}")]
    public IActionResult DeleteModelo(int id)
    {
        Modelo modelo = _context.Modelos.FirstOrDefault(m => m.Id == id);
        if (modelo != null)
        {
            _context.Remove(modelo);
            _context.SaveChanges();
            return NoContent();
        }
        return BadRequest("Não foi possível remover o item");
    }

    //Atualizar modelo
    [HttpPut("{id}")]
    public IActionResult PutModelo(int id, [FromBody] Modelo novoModelo)
    {
        if (!ModelState.IsValid)
            return BadRequest("Modelo Inválido");

        Modelo modelo = _context.Modelos.FirstOrDefault(m => m.Id == id);
        if (modelo == null)
        {
            return BadRequest("Modelo não encontrado");
        }
        modelo.Nome = novoModelo.Nome;
        modelo.NomeCriador = novoModelo.NomeCriador;
        _context.SaveChanges();
        return NoContent();
    }
}