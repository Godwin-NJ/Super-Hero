namespace SuperHero.Services.SuperHeroServices
{
    public interface ISuperHeroService
    {
        Task<List<SuperHeroModel>> GetAllHeros();
        Task<SuperHeroModel>? GetSingleHero(int id);
        Task<List<SuperHeroModel>?> AddHero(SuperHeroModel Hero);
        Task<List<SuperHeroModel>?> UpdateHero(int id, SuperHeroModel Hero);

        Task<List<SuperHeroModel>?> DeleteHero(int id);

    }
}
