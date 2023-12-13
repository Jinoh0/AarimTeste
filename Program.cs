using System;
using System.Threading.Tasks;
using AARIMTESTE.Controllers;

namespace AARIMTESTE
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CharacterController characterController = new CharacterController();
            await characterController.FilterAndDisplayCharactersAsync();
        }
    }
}