namespace SuperHero.Services.SuperHeroServices
{
    public class SuperHeroService : ISuperHeroService //implements the super Hero service interface
    {
        /* private static List<SuperHeroModel> superHeros = new List<SuperHeroModel>
            {
                new SuperHeroModel
                {
                    Id=1,Name="Spider Man", FirstName="Peter", LastName="Parker", Place="New york City",
                },
                  new SuperHeroModel
                {
                    Id=2,Name="Iron Man", FirstName="Iron", LastName="Stark", Place="Malibu",
                }

            };*/
        private readonly DataContext _context;
        public SuperHeroService(DataContext context) //now injecting the Database context to allow service to work with Database
        {
            _context = context;
        }
        public async Task<List<SuperHeroModel>?> AddHero(SuperHeroModel Hero)
        {
           await  _context.SuperHeroes.AddAsync(Hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
            // return superHeros;
        }

        public async Task<List<SuperHeroModel>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
           // await _context.SuperHeroes.RemoveAsync(hero);

             _context.SuperHeroes.Remove(hero);

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
            //rHeros;
        }

        public async Task<List<SuperHeroModel>> GetAllHeros()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
            //Task Type is used bcos I'm returning an async function
           // return superHeros;
        }

        public async Task<SuperHeroModel>? GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHeroModel>?> UpdateHero(int id, SuperHeroModel Hero)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            hero.FirstName = Hero.FirstName;
            hero.LastName = Hero.LastName;
            hero.Name = Hero.Name;
            hero.Place = Hero.Place;

            await _context.SaveChangesAsync(); //this saves changes into the database
          return  await _context.SuperHeroes.ToListAsync();
            //return superHeros;
        }
    }
}
