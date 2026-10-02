using ControleTarefas.Data;
using ControleTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleTarefas.Controllers;

[ApiController]
[Route("api/v1/tarefas")]
public class TarefasController : ControllerBase
{
    private readonly AppDbContext _context;

    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
    {
        var tarefas = await _context.Tarefas.AsNoTracking().OrderBy(t => t.Id).ToListAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tarefa>> GetTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa is null) return NotFound(new { mensagem = "Tarefa não encontrada." });
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<Tarefa>> CriarTarefa(Tarefa tarefa)
    {
        if (tarefa.DataVencimento < DateTime.Today)
            return BadRequest(new { mensagem = "A data de vencimento não pode ser anterior à data atual." });

        tarefa.Id = 0;
        tarefa.DataCriacao = DateTime.Now;
        tarefa.Concluida = false;
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTarefa), new { id = tarefa.Id }, tarefa);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarTarefa(int id, Tarefa tarefa)
    {
        if (id != tarefa.Id) return BadRequest(new { mensagem = "O ID da rota é diferente do ID enviado." });
        if (tarefa.DataVencimento < DateTime.Today)
            return BadRequest(new { mensagem = "A data de vencimento não pode ser anterior à data atual." });

        var existente = await _context.Tarefas.FindAsync(id);
        if (existente is null) return NotFound(new { mensagem = "Tarefa não encontrada." });

        existente.Titulo = tarefa.Titulo;
        existente.Descricao = tarefa.Descricao;
        existente.DataVencimento = tarefa.DataVencimento;
        existente.Concluida = tarefa.Concluida;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> ExcluirTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa is null) return NotFound(new { mensagem = "Tarefa não encontrada." });
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
