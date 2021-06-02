using System;
using keeper.server.Controllers;
using keeper.server.Models;
using keeper.server.Repositories;

namespace keeper.server.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _vaultKeepsRepo;
    private readonly VaultsRepository _vaultsRepo;
    private readonly KeepsRepository _keepsRepo;

    public VaultKeepsService(VaultKeepsRepository vaultKeepsRepo, VaultsRepository vaultsRepo, KeepsRepository keepsRepo)
    {
      _vaultKeepsRepo = vaultKeepsRepo;
      _vaultsRepo = vaultsRepo;
      _keepsRepo = keepsRepo;
    }

    internal object CreateVaultKeep(VaultKeep vaultKeep)
    {
      Vault vault = _vaultsRepo.GetByVaultId(vaultKeep.VaultId);
      Keep keep = _keepsRepo.GetById(vaultKeep.KeepId);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      if (keep == null)
      {
        throw new Exception("Invalid Keep Id");
      }
      if (vault.CreatorId != vaultKeep.CreatorId)
      {
        throw new Exception("This is not your vault");
      }
      keep.Keeps++;
      return _vaultKeepsRepo.Create(vaultKeep);
    }

    internal VaultKeep Get(int id)
    {
      VaultKeep vaultKeep = _vaultKeepsRepo.GetVaultKeep(id);
      if (vaultKeep == null)
      {
        throw new Exception("Invalid VaultKeep Id");
      }
      return vaultKeep;
    }

    internal void Remove(int vaultKeepId, string userId)
    {
      VaultKeep vaultKeep = Get(vaultKeepId);
      if (vaultKeep.CreatorId != userId)
      {
        throw new Exception("You are not allowed to delete a VaultKeep you did not create.");
      }
      _vaultKeepsRepo.Remove(vaultKeepId);
    }
  }
}