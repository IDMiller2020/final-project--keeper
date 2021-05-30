using System;
using System.Collections.Generic;
using keeper.server.Models;

namespace keeper.Models
{
  public class Account : Profile
  {
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}