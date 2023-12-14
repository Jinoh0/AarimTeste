using System.Collections.Generic;

namespace AARIMTESTE.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Species { get; set; }
        public List<string>? Episode { get; set; }
    }
}