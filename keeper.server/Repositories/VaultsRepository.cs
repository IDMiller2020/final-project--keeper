using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;
using keeper.server.Models;

namespace keeper.server.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults(name, description, isPrivate, creatorId)
      VALUES (@Name, @Description, @IsPrivate, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }

    internal void DeleteVault(int vaultId)
    {
      string sql = @"
      DELETE FROM vaults
      WHERE id = @vaultId
      LIMIT 1
      ";
      _db.Execute(sql, new { vaultId });
    }
    internal Vault Edit(Vault vault)
    {
      string sql = @"
      UPDATE vaults
      SET
        name = @Name,
        description = @Description,
        isPrivate = @IsPrivate
      WHERE id = Id;
      ";
      _db.Execute(sql, vault);
      return vault;
    }


    internal Vault GetByVaultId(int vaultId)
    {
      string sql = @"
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = @vaultId
      ";
      return _db.Query<Vault, Account, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { vaultId }, splitOn: "id").FirstOrDefault();
    }

    internal IEnumerable<Vault> GetAllVaultsByProfile(string profileId)
    {
      string sql = @"
      SELECT
        v.*,
        a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.creatorId = @profileId;
      ";
      return _db.Query<Vault, Account, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { profileId }, splitOn: "id");
    }

    internal IEnumerable<Vault> GetPublicVaultsByProfile(string profileId)
    {
      string sql = @"
      SELECT
        v.*,
        a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.creatorId = @profileId AND isPrivate = false;
      ";
      return _db.Query<Vault, Account, Vault>(sql, (v, a) =>
      {
        v.Creator = a;
        return v;
      }, new { profileId }, splitOn: "id");
    }
  }
}