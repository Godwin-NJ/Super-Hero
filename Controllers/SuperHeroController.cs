using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Models;
using SuperHero.Services.SuperHeroServices;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase //controller base is used to define that this class is a controller
    {
        //ctor >>shortcut to create controller
       private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService) //dependency injection of the super hero service interface
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroModel>>> GetAllHeros()
        {
          
            return await _superHeroService.GetAllHeros();
        }

        [HttpGet("id")]
       // [Route("id")]
        public async Task<ActionResult<SuperHeroModel>> GetSingleHero(int id)
        {
            var hero = await _superHeroService.GetSingleHero(id);
            if (hero is null)
            {
                return NotFound("Sorry this hero does not exist");
            }

            return Ok(hero);
            /* var hero = superHeros.Find(x => x.Id == id);
             if(hero is null)
             {
                 return NotFound("Sorry this hero does not exist");
             }
             return Ok(hero);*/
        }

        [HttpPost("AddHero")]
        public async Task<ActionResult<List<SuperHeroModel>>> AddHero(SuperHeroModel Hero)
        {
            var hero = await _superHeroService.AddHero(Hero);

            if (hero is null)
            {
                return NotFound($"error creating hero");
            }
            return Ok(hero);
          /*  superHeros.Add(Hero);
            return Ok(superHeros);*/
        }

        [HttpPut("id")]
        public async Task<ActionResult<List<SuperHeroModel>>> UpdateHero(int id, SuperHeroModel Hero)
        {
            var hero = await _superHeroService.UpdateHero(id, Hero);

            if (hero is null)
            {
                return NotFound($"Super hero with id:{id}, is not found");
            }
            return Ok(hero);
            /*var hero = superHeros.Find((hero) => hero.Id == id);
             if(hero is null)
             {
                 return NotFound($"Super hero with id:{id}, is not found");
             }
             hero.FirstName = Hero.FirstName;
             hero.LastName = Hero.LastName;
             hero.Name = Hero.Name;
             hero.Place = Hero.Place;

             return Ok(superHeros);*/
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<SuperHeroModel>>> DeleteHero(int id)
        {

            var hero = await _superHeroService.DeleteHero(id);
            if(hero is null)
            {
                return NotFound($"Super hero with id:{id}, is not found");
            }

            return Ok(hero);
            /*var hero = superHeros.Find((hero) => hero.Id == id);
            if (hero is null)
            {
                return NotFound($"Super hero with id:{id}, is not found");
            }
            superHeros.Remove(hero);

            return Ok(superHeros);*/
        }
    }
}
