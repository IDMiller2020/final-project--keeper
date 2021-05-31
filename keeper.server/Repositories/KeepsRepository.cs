using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keeper.Models;
using keeper.server.Models;

namespace keeper.server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Keep Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps(name, description, img, views, shares, keeps, creatorId)
      VALUES (@Name, @Description, @Img, @Views, @Shares, @Keeps, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      newKeep.Id = _db.ExecuteScalar<int>(sql, newKeep);
      return newKeep;
    }
    internal void DeleteKeep(int keepId)
    {
      string sql = @"
      DELETE FROM keeps
      WHERE id =@keepId
      LIMIT 1;
      ";
      _db.Execute(sql, new { keepId });
    }

    internal Keep Edit(Keep keep)
    {
      string sql = @"
      UPDATE keeps
      SET
        name = @Name,
        description = @Description,
        img = @Img
      WHERE id = @Id;
      ";
      _db.Execute(sql, keep);
      return keep;
    }
    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
      SELECT
      k.*,
      a.*
      FROM keeps k
      JOIN accounts a ON k.creatorId = a.id
      ";
      return _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
      {
        keep.Creator = account;
        return keep;
        // REVIEW how do we know when we need to include splitOn: "id" and when we don't?
        // Example 1 GoodEats RestaurantsRepository line 44 (no splitOn)
        // Example 2 spring21-auth-cs-gregslist line 64 (uses splitOn: "id")
      }, splitOn: "id");
    }


    internal Keep GetById(int keepId)
    {
      string sql = @"
      SELECT
        k.*,
        a.*
      FROM keeps k
      JOIN accounts a ON a.id = k.creatorId
      WHERE k.id = @keepId";
      return _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
      {
        keep.Creator = account;
        return keep;
      }, new { keepId }, splitOn: "id").FirstOrDefault();
    }

  }
}