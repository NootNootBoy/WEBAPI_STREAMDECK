using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegisterLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace RegisterLogin.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    public class CollectionsController : Microsoft.AspNetCore.Mvc.Controller
    {
        public CollectionsController(Micro_API_DBContext DbContext)
        {
            Database = DbContext;
        }

        private Micro_API_DBContext Database;
        
        // GET
        [HttpGet]
        public async Task<List<Models.Collection>> Index()
        {
            return await Database.Collections.ToListAsync();
        }
        
        // POST
        [HttpPost]
        public async Task<List<Models.Collection>> Create([FromBody] Collection collectionData)
        {
            Database.Collections.Add(collectionData);
            Database.SaveChanges();
            return await Database.Collections.ToListAsync();
        }
        
        //Put
        [HttpPut]
        public async Task<List<Models.Collection>> Edit([FromBody] Collection collectionData)
        {
            Database.Collections.Update(collectionData);
            Database.SaveChanges();
            return await Database.Collections.ToListAsync();
        }
        
        //DELETE
        [HttpDelete]
        public async Task<List<Models.Collection>> Delete([FromBody] Collection collectionData)
        {
            Database.Collections.Remove(collectionData);
            Database.SaveChanges();
            return await Database.Collections.ToListAsync();
        }
    }
}