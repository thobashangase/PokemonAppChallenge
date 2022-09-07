namespace Pokemon_Api
{
    public interface IPokemonApiClient
    {
        Task<List<Pokemon>> GetPokemonsAsync(string term, CancellationToken cancellationToken);
    }
}