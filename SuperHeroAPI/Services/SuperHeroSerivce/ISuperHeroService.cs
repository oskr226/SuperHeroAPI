using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Services.SuperHeroSerivce
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>> UpdateHero(SuperHero requestHero);
        Task<List<SuperHero>> DeleteHero(int id);
    }
}
