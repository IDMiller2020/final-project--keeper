using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keeper.Models;
using keeper.server.Models;
using keeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace keeper.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly AccountService _accountService;

    public ProfilesController(AccountService accountService)
    {
      _accountService = accountService;
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(string id)
    {
      try
      {
        Profile profile = _accountService.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{profileId}/keeps")]
    public ActionResult<IEnumerable<Keep>> GetKeeps(string profileId)
    {
      try
      {
        return Ok(_accountService.GetKeeps(profileId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<IEnumerable<Vault>>> GetVaults(string profileId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        if (userInfo == null)
        {
          String userId = "";
          IEnumerable<Vault> vaults = _accountService.GetVaults(profileId, userId);
          return Ok(vaults);
        }
        else
        {
          String userId = userInfo.Id;
          IEnumerable<Vault> vaults = _accountService.GetVaults(profileId, userId);
          return Ok(vaults);
        }
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}