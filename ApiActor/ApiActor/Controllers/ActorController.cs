using ApiActor.DAL;
using ApiActor.DTOs;
using ApiActor.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiActor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Actors.ToListAsync());
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            Actor actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (actor == null) return BadRequest();

            return Ok(actor);
        }

        [HttpDelete("")]
        public async Task<IActionResult> Delete(int id)
        {
            Actor actor = await _context.Actors.FindAsync(id);
            if (actor == null) return StatusCode(StatusCodes.Status404NotFound);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(ActorCreateDto actorDto)
        {
            Actor actor = new Actor
            {
                FullName = actorDto.FullName,
                ImageUrl = actorDto.ImageUrl,
                IsDelete = false,
            };

           await  _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return Ok(actorDto);
        }
        [HttpPut("")]
        public async Task<IActionResult> Update(int id, ActorUpdateDto actorDto)
        {
            if (actorDto == null) return StatusCode(StatusCodes.Status400BadRequest);
            Actor actor = await _context.Actors.FindAsync(id);
            if (actor == null) return StatusCode(StatusCodes.Status404NotFound);
            actor.FullName = actorDto.FullName;
            actor.ImageUrl = actorDto.ImageUrl;
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
