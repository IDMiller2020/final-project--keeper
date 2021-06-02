using System;
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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vaultKeepsService;

    public VaultKeepsController(VaultKeepsService vaultKeepsService)
    {
      _vaultKeepsService = vaultKeepsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        vaultKeep.CreatorId = userInfo.Id;
        return Ok(_vaultKeepsService.CreateVaultKeep(vaultKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int id)
    {
      try
      {
        VaultKeep vaultKeep = _vaultKeepsService.Get(id);
        return Ok(vaultKeep);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{vaultKeepId}")]
    public async Task<ActionResult<string>> Remove(int vaultKeepId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _vaultKeepsService.Remove(vaultKeepId, userInfo.Id);
        return Ok("Successfully Removed VaultKeep");
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}