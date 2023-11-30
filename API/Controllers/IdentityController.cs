using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Domain.Models;
using Domain.Utilities;
using MediatR;
using Application.Entities.IdentityEntity.Handler;


namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController(AuthenticateHandler AuthenticateHandler) : ControllerBase
{
    private readonly AuthenticateHandler _authenticateHandler = AuthenticateHandler;

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate([FromBody] LoginModel model)
    {
        try
        {
            var token = _authenticateHandler.Authenticate(model);
            return Ok(token);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
