using System.Threading.Tasks;
using keeper.Models;
using keeper.server.Models;
using keeper.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using CodeWorks.Auth0Provider;
using System.Collections.Generic;

namespace keeper.server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _keepsService;

    public KeepsController(KeepsService keepsService)
    {
      _keepsService = keepsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        keepData.CreatorId = userInfo.Id;
        Keep newKeep = _keepsService.Create(keepData);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteKeep(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _keepsService.DeleteKeep(id, userInfo.Id);
        return Ok("Keep Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Keep>> Edit(int id, [FromBody] Keep keep)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        keep.Id = id;
        Keep newKeep = _keepsService.Edit(keep, userInfo.Id);
        newKeep.Creator = userInfo;
        return Ok(newKeep);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> GetAll()
    {
      try
      {
        IEnumerable<Keep> keeps = _keepsService.GetAll();
        return Ok(keeps);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      try
      {
        Keep keep = _keepsService.GetById(id);
        return Ok(keep);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}