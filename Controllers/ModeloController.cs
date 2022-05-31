using Microsoft.AspNetCore.Mvc;
using ApiComMysql.Models;

namespace ApiComMysql.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ModeloController : ControllerBase
{
    private static int id = 1;

    public static List<Modelo> modelos = new List<Modelo>();

    [HttpGet("{id}")]
    public IActionResult GetModelo(int id)
    {
        Modelo modelo = modelos.FirstOrDefault(m => m.Id == id);
        if (modelo != null)
        {
            return Ok(modelo);
        }
        return BadRequest("Modelo não encontrado");
    }

    [HttpGet("lista/")]
    public IEnumerable<Modelo> GetModelos()
    {
        IEnumerable<Modelo> modelos1 = modelos;
        return modelos;
    }

    [HttpPost]
    public IActionResult PostModelo([FromBody] Modelo modelo)
    {
        modelo.Id = id++;
        modelo.DataCriacao = DateTime.Now;
        modelos.Add(modelo);
        return CreatedAtAction(nameof(GetModelo), new { id = modelo.Id }, modelo);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteModelo(int id)
    {
        Modelo modelo = modelos.FirstOrDefault(m => m.Id == id);
        if (modelo != null)
        {
            modelos.Remove(modelo);
            return NoContent();
        }
        return BadRequest("Não foi possível remover o item");
    }

    [HttpPut("{id}")]
    public IActionResult PutModelo(int id, [FromBody] Modelo novoModelo){

        Modelo modelo = modelos.FirstOrDefault(m => m.Id == id);
        if (modelo != null){
            modelo.Nome = novoModelo.Nome;
            modelo.NomeCriador = novoModelo.NomeCriador;
            return NoContent();
        }
        return BadRequest("Modelo não encontrado");

    }
}