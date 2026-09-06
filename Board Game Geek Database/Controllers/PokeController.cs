using System.Diagnostics;
using System.Text.Json;
using Board_Game_Geek_Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Board_Game_Geek_Database.Controllers
{
    public class PokeController : Controller
    {
        private readonly HttpClient _httpClient;

        public PokeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GrabPokemon(string name)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{name}/";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string jsonString = await response.Content.ReadAsStringAsync();
            var apiData = JsonSerializer.Deserialize<PokeModelDto>(jsonString);

            var viewModel = new PokeModel
            {
                Id = apiData.Id,
                Name = apiData.Name,
                Order = apiData.Order,
                Weight = apiData.Weight,
                Abilities = apiData.Abilities
            };

            return PartialView("_PokeDetailPartial", viewModel);
        }
    }
}
