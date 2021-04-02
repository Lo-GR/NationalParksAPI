using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NationalParksAPI.Models;

namespace NationalParksAPI.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly NationalParksAPIContext _db;
    public ParksController(NationalParksAPIContext db)
    {
      _db = db;
    }
    [ApiVersion("1.0")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get (string name)
    {
      var query = _db.Parks.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      return await query.ToListAsync();
    }
    //since foreignkeys cannot be null by default, needed a way to pass stateids through endpoints.
    [ApiVersion("1.0")]
    [HttpPost("create/{stateid}")]
    public async Task<ActionResult<Park>> Post(Park park, int stateId)
    {
      var state = _db.States.FirstOrDefault(entry => entry.StateId == stateId);
      park.StateId = state.StateId;
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new {id = park.ParkId}, park);
    }
    [ApiVersion("1.0")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      return park;
    }
    [ApiVersion("1.0")]
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return NotFound();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
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
    private bool ParkExists(int id)
    {
      return _db.Parks.Any(entry => entry.ParkId == id);
    }
    [ApiVersion("1.0")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMessage(int id)
    {
      Park park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}