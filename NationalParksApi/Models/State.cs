using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NationalParksAPI.Models
{
  public class State
  {
    public State()
    {
      Parks = new HashSet<Park>();
    }
    public int StateId {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public string Region {get; set;}
    public virtual ICollection<Park> Parks {get; set;}
    
  }
}