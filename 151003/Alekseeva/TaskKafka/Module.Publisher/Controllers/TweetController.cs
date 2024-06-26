﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Publisher.Dto.Request.CreateTo;
using Publisher.Dto.Request.UpdateTo;
using Publisher.Dto.Response;
using Publisher.Models;
using Publisher.Services.Interfaces;
namespace Publisher.Controllers;

[Route("api/v{version:apiVersion}/tweets")]
[ApiVersion("1.0")]
[ApiController]
public class TweetController(ITweetService service) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<ActionResult<Tweet>> GetTweet(long id)
    {
        return Ok(await service.GetTweetById(id));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets()
    {
        return Ok(await service.GetTweets());
    }

    [HttpPost]
    public async Task<ActionResult<TweetResponseTo>> CreateTweet(CreateTweetRequestTo createTweetRequestTo)
    {
        var addedTweet = await service.CreateTweet(createTweetRequestTo);
        return CreatedAtAction(nameof(GetTweet), new { id = addedTweet.Id }, addedTweet);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteTweet(long id)
    {
        await service.DeleteTweet(id);
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult<TweetResponseTo>> UpdateTweet(UpdateTweetRequestTo updateTweetRequestTo)
    {
        return Ok(await service.UpdateTweet(updateTweetRequestTo));
    }
}