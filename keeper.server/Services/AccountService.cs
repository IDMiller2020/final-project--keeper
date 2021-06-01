using System;
using System.Collections.Generic;
using keeper.Models;
using keeper.Repositories;
using keeper.server.Models;
using keeper.server.Repositories;

namespace keeper.Services
{
  public class AccountService
  {
    private readonly AccountsRepository _repo;
    private readonly KeepsRepository _keepsRepo;
    private readonly VaultsRepository _vaultsRepo;
    public AccountService(AccountsRepository repo, KeepsRepository keepsRepo, VaultsRepository vaultsRepo)
    {
      _repo = repo;
      _keepsRepo = keepsRepo;
      _vaultsRepo = vaultsRepo;
    }

    internal string GetProfileEmailById(string id)
    {
      return _repo.GetById(id).Email;
    }
    internal Account GetProfileByEmail(string email)
    {
      return _repo.GetByEmail(email);
    }
    internal Account GetOrCreateProfile(Account userInfo)
    {
      Account profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }

    internal Account Edit(Account editData, string userEmail)
    {
      Account original = GetProfileByEmail(userEmail);
      original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
      original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
      return _repo.Edit(original);
    }
    internal IEnumerable<Keep> GetKeeps(string profileId)
    {
      IEnumerable<Keep> keeps = _keepsRepo.GetKeepsByProfile(profileId);
      return keeps;
    }
    internal IEnumerable<Vault> GetVaults(string profileId, string userId)
    {
      if (profileId == userId)
      {
        IEnumerable<Vault> vaults = _vaultsRepo.GetAllVaultsByProfile(profileId);
        if (vaults == null)
        {
          throw new Exception("Invalid Profile Id");
        }
        return vaults;
      }
      else
      {
        IEnumerable<Vault> vaults = _vaultsRepo.GetPublicVaultsByProfile(profileId);
        if (vaults == null)
        {
          throw new Exception("Invalid Profile Id");
        }
        return vaults;
      }
    }

    internal Profile GetProfileById(string id)
    {
      return _repo.GetById(id);
    }


  }
}