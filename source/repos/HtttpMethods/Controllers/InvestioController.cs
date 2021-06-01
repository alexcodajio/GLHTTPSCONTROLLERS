using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtttpMethods.Controllers
{
    [ApiController]
    [Route("Start")]
    public class InvestioController : ControllerBase
    {
        private static readonly List<string> Assets = new List<string>
        {
            "Shares", "Crypto", "Banking", "Binary options", "Real estate"
        };

        private readonly ILogger<InvestioController> _logger;

        public InvestioController(ILogger<InvestioController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult Asset(int id)
        {
            var rng = new Random();
            return Ok(Assets);

        }

        [HttpGet("{id}")]
        public IActionResult AssetByType(int id)
        {
            var rng = new Random();
            return Ok(Assets[id]);

        }

        [HttpPost]
        public IActionResult CreateAsset([FromBody] string type)
        {

            Assets.Add(type);
            return Ok("Created");
        }

        [HttpPut]
        public IActionResult UpdateAsset(int id, string type)
        {

            Assets.RemoveAt(id);
            Assets.Add(type);
            return Ok("Updated");
        }
        [HttpDelete]
        public IActionResult DeleteAsset([FromRoute] int id)
        {

            Assets.RemoveAt(id);
            return Ok("Deleted");
        }

    }
}
