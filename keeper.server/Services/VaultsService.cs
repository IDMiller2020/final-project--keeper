using System;
using System.Collections.Generic;
using keeper.server.Models;
using keeper.server.Repositories;

namespace keeper.server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _vaultsRepo;

    public VaultsService(VaultsRepository vaultsRepo)
    {
      _vaultsRepo = vaultsRepo;
    }

    internal Vault Create(Vault vaultData)
    {
      return _vaultsRepo.Create(vaultData);
    }
    internal Vault GetByVaultId(int vaultId)
    {
      Vault vault = _vaultsRepo.GetByVaultId(vaultId);
      if (vault == null)
      {
        throw new Exception("Invalid Vault Id");
      }
      return vault;
    }

  }
}