using System;
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
  }
}