namespace Pokemon_Api
{
    public interface IPokemonApiClient
    {
        Task<List<Pokemon>> GetPokemonsAsync(CancellationToken cancellationToken);
        Task<List<Pokemon>> GetPokemonsFilteredAsync(string term, CancellationToken cancellationToken);
    }
}