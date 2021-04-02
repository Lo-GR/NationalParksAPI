using Microsoft.EntityFrameworkCore;
using System;

namespace NationalParksAPI.Models
{
  public class NationalParksAPIContext : DbContext
  {
  public NationalParksAPIContext(DbContextOptions<NationalParksAPIContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<State>()
        .HasData(
          new State {StateId = 1, Name = "Washington", Region = "Pacific-NorthWest"},
          new State {StateId = 2, Name = "Oregon", Region = "Pacific-NorthWest"},
          new State {StateId = 3, Name = "Colorado", Region = "Mountain-West"}
        );
      builder.Entity<Park>()
        .HasData(
          new Park {ParkId = 1, Name = "Washington", Region = "Pacific-NorthWest"},
          new Park {StateId = 2, Name = "Oregon", Region = "Pacific-NorthWest"},
          new Park {StateId = 3, Name = "Colorado", Region = "Mountain-West"}
        );

  }
}

ublic int ParkId {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public int Distance {get; set;}
    [Required]
    public string Established {get; set;}
    public string ImageURL {get; set;}
    public int StateId {get; set;}