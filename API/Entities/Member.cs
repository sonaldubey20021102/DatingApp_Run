using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities;

public class Member
{
    public string Id { get; set; }=null!;

    public DateOnly DateOfBirth { get; set; }
    public string? ImageUrl { get; set; }
    public required string UserName { get; set; } 
    public DateTime Created { get; set; }= DateTime.UtcNow;
    public DateTime LastActive { get; set; }= DateTime.UtcNow;
    public required string Gender { get; set; }
    public string? Description { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }

    //NAvigation Property

    [JsonIgnore]    
         // One-to-many relationship with Photos
    // public ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public List<Photo> Photos { get; set; } = [];

    [JsonIgnore]
    [ForeignKey(nameof(Id))]
    public AppUser User { get; set; }=null!;



}
