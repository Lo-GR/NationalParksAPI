using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksAPI.Models;

namespace NationalParksAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatesController : ControllerBase
  {
    private readonly NationalParksAPIContext _db;
    public StatesController(NationalParksAPIContext db)
    {
      _db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<State>>> Get()
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();
      return await query.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<State>> Post(State state)
    {
      _db.States.Add(state);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetState), new {id = state.StateId, state});
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
  }
}