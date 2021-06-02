using System;
using System.Collections.Generic;
using keeper.server.Models;
using keeper.server.Repositories;

namespace keeper.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vaultsRepo;
    private readonly VaultKeepsRepository _vaultKeepsRepo;

    public VaultsService(VaultsRepository vaultsRepo, VaultKeepsRepository vaultKeepsRepo)
    {
      _vaultsRepo = vaultsRepo;
      _vaultKeepsRepo = vaultKeepsRepo;
    }

    internal Vault Create(Vault vaultData)
    {
      return _vaultsRepo.Create(vaultData);
    }
    internal void DeleteVault(int vaultId, string userId)
    {
      Vault vault = GetByVaultId(vaultId, userId);
      if (vault.CreatorId != userId)
      {
        throw new Exception("You are not allowed to delete a Vault you did not create.");
      }
      _vaultsRepo.DeleteVault(vaultId);
    }
    internal Vault Edit(Vault vaultData, string userId)
    {
      Vault vault = _vaultsRepo.GetByVaultId(vaultData.Id);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      if (vault.CreatorId != userId)
      {
        throw new Exception("You are not allowed to edit a Vault you did not create.");
      }
      return _vaultsRepo.Edit(vaultData);
    }
    internal Vault GetByVaultId(int vaultId, string userId)
    {
      Vault vault = _vaultsRepo.GetByVaultId(vaultId);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      if (vault.IsPrivate && vault.CreatorId != userId)
      {
        throw new Exception("You are not allowed to access a private Vault that you did not create.");
      }
      return vault;
    }

    internal IEnumerable<VaultKeepViewModel> GetKeeps(int vaultId)
    {
      return _vaultKeepsRepo.GetVaultKeeps(vaultId);
    }
  }
}