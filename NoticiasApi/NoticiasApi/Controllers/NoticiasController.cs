using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasApi.Models;
using NoticiasApi.Repositories;

namespace NoticiasApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoticiasController : ControllerBase
{
    [HttpGet("Ola")]
    public string Ola()
    {
        return "Relou Uordi!!!";
    }

    [HttpGet]
    public IActionResult BuscarTodas()
    {
        var repository = new NoticiasRepository();
        var dados = repository.BuscarTodas();

        if (dados.ToList().Count > 0)
            return Ok(dados);

        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var repository = new NoticiasRepository();
        var dados = repository.BuscarPorId(id);

        return dados != null ? Ok(dados) : NoContent();
    }

    [HttpPost]
    public IActionResult Adicionar(Noticia noticia)
    {
        try
        {
            var repository = new NoticiasRepository();
            return Ok(repository.Adicionar(noticia));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Alterar(Noticia noticia)
    {
        try
        {
            var repository = new NoticiasRepository();
            return Ok(repository.Alterar(noticia));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        try
        {
            var repository = new NoticiasRepository();
            return Ok(repository.Excluir(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
