using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Sistema_de_Hospedagem.Models
{
    public class APIServer
    {
        public static async Task<List<Suite>> GetSuitesAsync()
        {
            using HttpClient client = new HttpClient();
            var responseSuites = await client.GetStringAsync("http://localhost:3000/quartos");
            var suites = JsonSerializer.Deserialize<List<Suite>>(responseSuites, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return suites?? new List<Suite>();
        }
    }
}