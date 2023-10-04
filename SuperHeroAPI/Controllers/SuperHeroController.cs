using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroSerivce;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var superHeroes = await _superHeroService.GetAllHeroes();

            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _superHeroService.GetSingleHero(id);

            if (hero == null)
            {
                return NotFound("Sorry, the hero doesn't exist!.");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            var superHeroes = await _superHeroService.AddHero(hero);

            return Ok(superHeroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero([FromBody] SuperHero requestHero)
        {
            var superHeroes = await _superHeroService.UpdateHero(requestHero);

            if (superHeroes == null)
            {
                return NotFound("Sorry, the hero doesn't exist!.");
            }

            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var superHeroes = await _superHeroService.DeleteHero(id);

            if(superHeroes == null)
            {
                return NotFound("Sorry, the hero doesn't exist!.");
            }

            return Ok(superHeroes);
        }

    }
}
