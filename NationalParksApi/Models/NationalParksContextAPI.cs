using Microsoft.EntityFrameworkCore;

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
          new Park {ParkId = 1, Name = "Mount Rainier National Park", Distance = 236381, Established = "1899-03-02", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/32/Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG/1280px-Mount_Rainier_from_above_Myrtle_Falls_in_August.JPG", StateId = 1},
          new Park {ParkId = 2, Name = "Crater Lake National Park", Distance = 183224, Established = "1902-05-22", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Above_Crater_Lake_%28cropped%29.jpg/1920px-Above_Crater_Lake_%28cropped%29.jpg", StateId = 2},
          new Park {ParkId = 3, Name = "Rocky Mountain State Park", Distance = 265461, Established = "1915-01-26", ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/ViewFromSummitofHallett.jpg/1920px-ViewFromSummitofHallett.jpg", StateId = 3}
        );
    }
    public DbSet<Park> Parks {get; set;}
    public DbSet<State> States {get; set;}
  }
}