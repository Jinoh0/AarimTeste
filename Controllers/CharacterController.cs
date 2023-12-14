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
            bool moreCharactersAvailable = true;
            int characterNumber = 1;
            List<Character> filteredCharacters = new List<Character>();

            while (moreCharactersAvailable)
            {
                string apiUrl = $"https://rickandmortyapi.com/api/character/{characterNumber}";
                string content = await _apiService.GetCharacterDataAsync(apiUrl);

                if (!string.IsNullOrEmpty(content))
                {
                    var character = JsonConvert.DeserializeObject<Character>(content);
                    if (character != null)
                    {
                        if (character?.Status?.ToUpper() == "UNKNOWN" && character?.Species?.ToUpper() == "ALIEN" && character?.Episode?.Count > 1)
                        {
                            filteredCharacters.Add(character);
                        }
                        characterNumber++;
                    }
                    else
                    {
                        moreCharactersAvailable = false;
                    }
                }
                else
                {
                    moreCharactersAvailable = false;
                }
            }
            if (filteredCharacters.Count == 0)
            {
                Console.WriteLine("Não foi encontrado nenhum personagem.");
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