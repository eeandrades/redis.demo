using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace redis.demo.Model
{
    public class Cliente
    {
        [System.Text.Json.Serialization.JsonPropertyName("uid")]
        public string Uid { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nome")]
        public string Nome { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("documento")]
        public string Documento { get; set; }


    }
}
