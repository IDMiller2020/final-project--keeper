using System;
using System.Data;
using Dapper;
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
  }
}