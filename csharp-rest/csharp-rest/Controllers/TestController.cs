using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // test/
        [HttpGet(Name = "GetTest")]
        public IEnumerable<Test> Get()
        {
            // return 5 random objects
            return Enumerable.Range(1, 5).Select(index => new Test
            {
                Id = Random.Shared.Next(1, 100),
                Date = DateTime.Now.AddDays(index),
                Message = "test"
            })
            .ToArray();
        }

        // test/145
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            return new Test
            {
                Id = id,
                Date = DateTime.Now.AddDays(1),
                Message = "test id"
            };
        }

        // test/
        // in the body-raw send the json object { "Message": "Ok", "Date": "2022-09-27T09:05:19.5778817-05:00", "Id": 1 }
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            // TODO:
            return CreatedAtAction(nameof(GetTest), new { id = test.Id }, test);
        }

        // test/145
        // in the body-raw send the json object { "Message": "Ok", "Date": "2022-09-27T09:05:19.5778817-05:00", "Id": 1 }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }
            //return Ok();
            return NoContent();
        }

        // test/145
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            //TODO:
            return NoContent();
        }
    }
}
