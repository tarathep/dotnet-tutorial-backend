using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Tutorial.Api.Controllers
{
    [Route("tutorials")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        //GET : /api/tutorials
        // [{"id":"602aa1e04f3b51804eca6917","title":"yy","description":"xx Description","published":false,"createdAt":"0001-01-01T00:00:00Z","updatedAt":"0001-01-01T00:00:00Z"},{"id":"602aa1e04f3b51804eca6917","title":"yy","description":"xx Description","published":false,"createdAt":"0001-01-01T00:00:00Z","updatedAt":"0001-01-01T00:00:00Z"}]
        [HttpGet]
        public IEnumerable<Tutorial> Get()
        {
            return Enumerable.Range(1, 2).Select(index => new Tutorial { id = "602aa1e04f3b51804eca6917", title = "yy", description = "xx Description", published = false, createdAt = new DateTime(), updatedAt = new DateTime() }).ToArray();

        }

        //GET : /api/tutorials/602aa1e04f3b51804eca6917
        [HttpGet("{id}")]
        public ActionResult GetTutorialById(int id)
        {
            return Ok(new { id = "602aa1e04f3b51804eca6917", title = "yy", description = "xx Description", published = false, createdAt = "0001-01-01T00:00:00Z", updatedAt = "0001-01-01T00:00:00Z" });
        }


        public class TutorialAdd
        {
            public string title { get; set; }
            public string description { get; set; }
        }

        [HttpPost]
        public ActionResult AddTutorial([FromBody] TutorialAdd tutorial) // FromBody and FromForm
        {
            return Ok(new { code=200 , message = "Inserted a single document Success"});
        }

        [HttpPut("{id}")] 
        public ActionResult UpdateTutorialById(string id, [FromBody] Tutorial tutorial)
        {

            if (id.Equals(tutorial.id))
            {
                return BadRequest();
            }

            return Ok(tutorial);
        }

        [HttpDelete]
        public ActionResult DeleteAll()
        {
            return Ok(new { code="200", message="All deleted" });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(string id)
        {
            if (id != "?")
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}