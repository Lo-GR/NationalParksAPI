using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksAPI.Models;

namespace NationalParksAPI.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/{v:apiVersion}/[controller]")]
  [ApiController]
  public class StatesController : ControllerBase
  {
    private readonly NationalParksAPIContext _db;
    public StatesController(NationalParksAPIContext db)
    {
      _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<State>>> Get(string name, string region)
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      if (region != null)
      {
        query = query.Where(entry => entry.Region.Contains(region));
      }
      return await query.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<State>> Post(State state)
    {
      _db.States.Add(state);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetState), new {id = state.StateId}, state);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<State>> GetState(int id)
    {
      State state = await _db.States.FindAsync(id);
      if (state == null)
      {
        return NotFound();
      }
      return state;
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, State state)
    {
      if (id != state.StateId)
      {
        return NotFound();
      }

      _db.Entry(state).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StateExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    private bool StateExists(int id)
    {
      return _db.States.Any(entry => entry.StateId == id);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMessage(int id)
    {
      State state = await _db.States.FindAsync(id);
      if (state == null)
      {
        return NotFound();
      }
      _db.States.Remove(state);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}