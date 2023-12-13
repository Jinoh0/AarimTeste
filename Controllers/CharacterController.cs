using System;
using Newtonsoft.Json;
using AARIMTESTE.Models;
using AARIMTESTE.Services;

namespace AARIMTESTE.Controllers
{
    public class CharacterController
    {
        private readonly FilterDataService _apiService;

        public CharacterController()
        {
            _apiService = new FilterDataService();
        }

        public async Task FilterAndDisplayCharactersAsync()
        {
            string apiUrl = "https://rickandmortyapi.com/api/character";
            string content = await _apiService.GetCharacterDataAsync(apiUrl);

            if (!string.IsNullOrEmpty(content))
            {
                var characterResponse = JsonConvert.DeserializeObject<CharacterResponse>(content);

                if (characterResponse != null && characterResponse.Results != null)
                {
                    List<Character> filteredCharacters = new List<Character>();

                    foreach (var character in characterResponse.Results)
                    {
                        if (character?.Status?.ToUpper() == "unknown".ToUpper() && character?.Species?.ToUpper() == "alien".ToUpper() && character?.Episode?.Count > 1)
                        {
                            filteredCharacters.Add(character);
                        }
                    }

                    if (filteredCharacters.Count == 0)
                    {
                        Console.WriteLine("Não foi encontrado nenhum personagem com as condições solicitadas.");
                    }
                    else
                    {
                        foreach (var character in filteredCharacters)
                        {
                            Console.WriteLine($"Name: {character?.Name}, Status: {character?.Status}, Species: {character?.Species}, Episode Count: {character?.Episode?.Count}");
                        }
                    }
                }
            }
        }
    }
}