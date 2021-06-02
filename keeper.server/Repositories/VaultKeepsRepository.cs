using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.server.Controllers;
using keeper.server.Models;

namespace keeper.server.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public VaultKeep Create(VaultKeep vaultKeep)
    {
      string sql = @"
      INSERT INTO vaultkeeps(vaultId, keepId, creatorId)
      VALUES (@VaultId, @KeepId, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, vaultKeep);
      vaultKeep.Id = id;
      return vaultKeep;
    }

    internal VaultKeep GetVaultKeep(int id)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
    internal void Remove(int id)
    {
      string sql = "DELETE FROM vaultKeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

    internal IEnumerable<VaultKeepViewModel> GetVaultKeeps(int vaultId)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE vaultkeeps.vaultId = @vaultId";
      return _db.Query<VaultKeepViewModel>(sql, new { vaultId }).ToList();
    }
  }
}