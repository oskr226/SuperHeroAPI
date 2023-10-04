using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Services.SuperHeroSerivce
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;              

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);

            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

        public async Task<List<SuperHero>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return null;
            }

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return heroes;
        }

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return null;
            }

            return hero;
        }

        public async Task<List<SuperHero>> UpdateHero(SuperHero requestHero)
        {
            var hero = await _context.SuperHeroes.FindAsync(requestHero.Id);

            if (hero == null)
            {
                return null;
            }

            hero.Name = requestHero.Name;
            hero.FirtsName = requestHero.FirtsName;
            hero.LastName = requestHero.LastName;
            hero.Place = requestHero.Place;

            await _context.SaveChangesAsync();

            return await GetAllHeroes();
        }

    }
}
