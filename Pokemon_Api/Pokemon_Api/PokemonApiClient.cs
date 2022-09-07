using System.Threading;

namespace Pokemon_Api
{
    public class PokemonApiClient : IPokemonApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PokemonApiClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(string term, CancellationToken cancellationToken)
        {
            var pokemon = await _httpClient.GetFromJsonAsync<PokemonJsonResponse>(
                $"{_configuration.GetValue<string>("Pokemon:ApiBaseUrl")}/pokemon?offset=0&limit=100", cancellationToken);


            if (pokemon is null or { Results.Count: 0 })
            {
                throw new InvalidOperationException("Something went wrong while getting the list of Pokemons");
            }

            return string.IsNullOrWhiteSpace(term) ? pokemon.Results : pokemon.Results.Where(x => x.Name.Contains(term)).ToList();
        }
    }
}
