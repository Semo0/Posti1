using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using model.DTOs;
using model.Models;

namespace WebApplication1.Controllers;
[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostLogic Service;

    public PostsController(IPostLogic service)
    {
        Service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostCreationDto dto)
    {
        try
        {
            Post created = await Service.CreateAsync(dto);
           // Console.WriteLine(dto+"Controller");
            return Created($"posts/{created.Id}",created);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? Usernamw,int? userId,string? posttittel)
    {
        try
        {
            SearchPostParameterDto parameterDto = new SearchPostParameterDto(Usernamw,userId,posttittel);
         IEnumerable<Post> posts= await Service.GetAsync(parameterDto);
         return Ok(posts);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }
}

