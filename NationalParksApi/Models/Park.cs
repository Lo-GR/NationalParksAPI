using System.ComponentModel.DataAnnotations;
using System;

namespace NationalParksAPI.Models
{
  public class Park 
  {
    public int ParkId {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public int Distance {get; set;}
    [Required]
    public string Established {get; set;}
    public string ImageURL {get; set;}
    public int StateId {get; set;}
  }
}