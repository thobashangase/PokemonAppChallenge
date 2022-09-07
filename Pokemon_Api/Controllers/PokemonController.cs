using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pokemon_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonApiClient _pokemonApiClient;

        public PokemonController(ILogger<PokemonController> logger, IPokemonApiClient pokemonApiClient)
        {
            _logger = logger;
            _pokemonApiClient = pokemonApiClient;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Pokemon>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPokemons([FromQuery] string term)
        {
            try
            {
                var pokemons = await _pokemonApiClient.GetPokemonsAsync(term, cancellationToken: CancellationToken.None);

                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
