using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper.Models;
using keeper.server.Models;
using keeper.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keeper.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vaultsService;

    public VaultsController(VaultsService vaultsService)
    {
      _vaultsService = vaultsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultData.CreatorId = userInfo.Id;
        Vault newVault = _vaultsService.Create(vaultData);
        newVault.Creator = userInfo;
        return Ok(newVault);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetByVaultId(int id)
    {
      try
      {
        Vault vault = _vaultsService.GetByVaultId(id);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault vault)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vault.Id = id;
        Vault newVault = _vaultsService.Edit(vault, userInfo.Id);
        newVault.Creator = userInfo;
        return Ok(newVault);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}