using Microsoft.AspNetCore.Mvc;
using SessionWebApi.Dtos;
using SessionWebApi.Extensions;

namespace SessionWebApi.Controllers;

public class SessionController : ControllerBase
{
    private readonly ILogger<SessionController> _logger;

    public SessionController(
        ILogger<SessionController> logger
    )
    {
        _logger = logger;
    }

    [HttpGet("get-sessionId")]
    public ActionResult<string> GetSession()
    {
        var session = HttpContext.Session.Id;
        return Ok(session);
    }

    [HttpPost("set-string-session")]
    public IActionResult SetStringSession([FromBody] IDictionary<string, string> attributes)
    {
        foreach (var attribute in attributes)
        {
            HttpContext.Session.SetString(attribute.Key, attribute.Value);
        }

        return NoContent();
    }

    [HttpGet("get-string-session/{key}")]
    public IActionResult GetStringSession(string key)
    {
        var session = HttpContext.Session.GetString(key);

        if (string.IsNullOrWhiteSpace(session))
            return NotFound();

        return Ok(session);
    }

    [HttpPost("set-object-session/{key}")]
    public IActionResult SetObjectSession(string key, [FromBody] ProfileDto profileDto)
    {
        HttpContext.Session.Set<ProfileDto>(key, profileDto);

        return NoContent();
    }

    [HttpGet("get-object-session/{key}")]
    public IActionResult GetObjectSession(string key)
    {
        var session = HttpContext.Session.Get<ProfileDto>(key);
            if(session == null)
            return NotFound();

        return Ok(session);
    }

    [HttpGet("clear-session")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return NoContent();
    }

    [HttpGet("remove-session/{key}")]
    public IActionResult RemoveSession(string key)
    {
        HttpContext.Session.Remove(key);
        return NoContent();
    }
}