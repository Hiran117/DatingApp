using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController(DataContext context) : BaseApiController
{
    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth()
    {
        return "secret text";
    }
    
    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFoud()
    {
            var thing = context.Users.Find(-1);
            if (thing == null) return NotFound();
            return thing;
    }

    [HttpGet("server-error")]
    public ActionResult<AppUser> GetServerError()
    {
        var thing = context.Users.Find(-1) ?? throw new Exception ("A bad thing has happend");
        return thing;
    }

        [HttpGet("bad-request")]
    public ActionResult<AppUser> GetBadRequest()
    {
        return BadRequest("This was not a good request");
    }

}
