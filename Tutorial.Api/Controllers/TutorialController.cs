using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Tutorial.Api.Models;
using Tutorial.Api.Services;

namespace Tutorial.Api.Controllers
{
    [Route("api/tutorials")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        #region Property
        private readonly ITutorialService _tutorialService;
        #endregion

        #region Constructor
        public TutorialController(ITutorialService tutorialService)
        {
            _tutorialService = tutorialService;
        }
        #endregion

        [HttpGet]
        public async Task<List<Models.Tutorial>> Get([FromQuery(Name = "title")] string? title)
        {
            if (title == null)
                return await _tutorialService.GetAsync();

            return await _tutorialService.GetAyncByTitle(title);
        }


        [HttpGet("{id:length(24)}")]
        public async Task<Models.Tutorial> GetTutorialById(string id)
        {
            var tutorial = await _tutorialService.GetAsync(id);
            
            return tutorial;
        }

        [HttpPost]
        public async Task<IActionResult> AddTutorial([FromBody] Models.Tutorial tutorial)
        {
            await _tutorialService.CreateAsync(tutorial);
            
            return Ok(new { code="200" , message = "Inserted a single document Success"});
            
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateTutorial(string id,[FromBody] Models.Tutorial tutorial)
        {
            var _tutorial = await _tutorialService.GetAsync(id);

            if (_tutorial is null)
            {
                return NotFound(new { });
            }

            tutorial.Id = _tutorial.Id;

            await _tutorialService.UpdateAsync(id, tutorial);

            return Ok(new { code = "200", message = "Updated a single document Success" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _tutorialService.RemoveAsync();

            return Ok(new { code="200", message="All deleted" });
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var tutorial = await _tutorialService.GetAsync(id);

            if (tutorial is null)
            {
                return NotFound();
            }

            await _tutorialService.RemoveAsync(id);

            return Ok(new { code = "200", message = "Deleted id "+id });

        }
    }
}