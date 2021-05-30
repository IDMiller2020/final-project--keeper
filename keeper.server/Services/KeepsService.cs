using System;
using keeper.server.Models;
using keeper.server.Repositories;

namespace keeper.server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _keepsRepo;

    public KeepsService(KeepsRepository keepsRepo)
    {
      _keepsRepo = keepsRepo;
    }

    internal Keep Create(Keep keepData)
    {
      return _keepsRepo.Create(keepData);
    }
  }
}