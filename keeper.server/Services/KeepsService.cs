using System;
using System.Collections.Generic;
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

    internal void DeleteKeep(int keepId, string userId)
    {
      Keep keep = GetById(keepId);
      if (keep.CreatorId != userId)
      {
        throw new Exception("You are not allowed to delete a Keep you did not create.");
      }
      _keepsRepo.DeleteKeep(keepId);
    }
    internal Keep Edit(Keep keepData, string id)
    {
      Keep keep = _keepsRepo.GetById(keepData.Id);
      if (keep == null)
      {
        throw new Exception("Invalid Keep Id");
      }
      if (keep.CreatorId != id)
      {
        throw new Exception("You are not allowed to edit a Keep you did not create.");
      }
      return _keepsRepo.Edit(keepData);
    }

    internal IEnumerable<Keep> GetAll()
    {
      return _keepsRepo.GetAll();
    }
    internal Keep GetById(int keepId)
    {
      Keep keep = _keepsRepo.GetById(keepId);
      if (keep == null)
      {
        throw new Exception("Invalid Keep Id");
      }
      return keep;
    }

  }
}