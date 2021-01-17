using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterLogin.Models;
using IGDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Game = IGDB.Models.Game;

namespace RegisterLogin.Controller
{
    [Route("api/[controller]")]
    public class GamesController : Microsoft.AspNetCore.Mvc.Controller
    {
        public GamesController(Micro_API_DBContext DbContext)
        {
            Database = DbContext;
        }

        private Micro_API_DBContext Database;
        
        // GET
        [HttpGet]
        public async Task<List<Models.Game>> Index()
        {
            Database.Games.RemoveRange(Database.Games.ToList());
            IGDBClient igdb = new IGDBClient(
                "gdomcl7slhaqk8348e5ecoxrhavcs5",
                "jqi256wvzibuy4y5mbexb7efyv0e80"
            );
            Game[] json = igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name,summary; where category = 0 & status = 0; sort rating desc; limit 20;").Result;
            foreach (Game game in json)
            {
                RegisterLogin.Models.Game dbgame = new RegisterLogin.Models.Game
                {
                    GameName = game.Name,
                    GameSummary = game.Summary
                };
                Database.Games.Add(dbgame);
            }
            
            Database.SaveChanges();
            
            return await Database.Games.ToListAsync();
        }
    }
}