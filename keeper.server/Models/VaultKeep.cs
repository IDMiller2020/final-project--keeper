using System;
using System.ComponentModel.DataAnnotations;

namespace keeper.server.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }
  }
  public class VaultKeepViewModel : Keep
  {
    // These items imported from Keep model
    // public DateTime CreatedAt { get; set; }
    // public DateTime UpdatedAt { get; set; }
    // public string CreatorId { get; set; }
  }
}