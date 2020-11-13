using Microsoft.AspNetCore.Mvc;
using redis.demo.Model;
using StackExchange.Redis;
using System;
using System.Text.Json;

namespace redis.demo.Controllers
{
    [Route("Clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IDatabase _database;

        public ClienteController(IDatabase dataBase)
        {
            this._database = dataBase ?? throw new ArgumentNullException(nameof(dataBase));
        }

        // GET: api/Cache/5
        [HttpGet("{id}", Name = "Get")]
        public Cliente Get(string id)
        {
            var result = this._database.StringGet(id);
            return result.HasValue ? JsonSerializer.Deserialize<Cliente>(result.ToString()) : throw new ArgumentException($"Chave {id} não encontrada.");
        }

        // POST: api/Cache
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            this._database.StringSet(cliente.Uid, JsonSerializer.Serialize(cliente));
        }

    }
}
