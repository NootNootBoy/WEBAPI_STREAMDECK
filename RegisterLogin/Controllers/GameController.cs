using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RegisterLogin.Model;
using Microsoft.AspNetCore.Authorization;

namespace RegisterLogin.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            return (new JsonResult(games));
        }
        // POST
        [HttpPost]
        public IActionResult Create([FromBody] Game game)
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            games.Add(game);
            string jsonEdit = JsonConvert.SerializeObject(games, Formatting.Indented);
            System.IO.File.WriteAllText("data.json", jsonEdit);
            return Ok("Le jeu à bien été crée");
        }
        //Put
        [HttpPut]
        public IActionResult Edit([FromBody] Game game)
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            Game myGame = games.FirstOrDefault(G => G.Id == game.Id);
            myGame.Name = game.Name;
            myGame.Genre = game.Genre;
            string jsonEdit = JsonConvert.SerializeObject(games, Formatting.Indented);
            System.IO.File.WriteAllText("data.json", jsonEdit);
            return Ok("Le jeu à bien été modifié");
        }
        //DELETE
        [HttpDelete]
        public IActionResult Delete([FromBody] Game game)
        {
            string json = System.IO.File.ReadAllText("data.json");
            List<Game> games = JsonConvert.DeserializeObject<List<Game>>(json);
            Game myGame = games.FirstOrDefault(G => G.Id == game.Id);
            games.Remove(myGame);
            string jsonEdit = JsonConvert.SerializeObject(games, Formatting.Indented);
            System.IO.File.WriteAllText("data.json", jsonEdit);
            return Ok("Le jeu à été supprimé");
        }
    }
}
