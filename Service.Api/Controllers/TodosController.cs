using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAO;
using DAO.Contracts;
using DAO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers {

    [Route ("api/v1/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase {
        private readonly IRepository _repository;

        public TodosController (IRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> Gets () {
            return await _repository.List ();
        }

        [HttpGet ("{id:Guid}")]
        public async Task<ActionResult<Todo>> GetById (Guid id) {

            if (!await _repository.AnyAsync (id))
                return NotFound ();

            return await _repository.FindAsync (id);
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post (string value) {
            if (string.IsNullOrEmpty (value))
                return BadRequest ();

            var todo = new Todo (value);

            await _repository.AddAsync (todo);

            await _repository.Commit();

            return CreatedAtAction (nameof (GetById), new { id = todo.Id }, todo);
        }

        [HttpPatch ("{id:Guid}")]
        [ProducesResponseType (StatusCodes.Status202Accepted)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Check (Guid id, bool isComplete) {

            if (!await _repository.AnyAsync (id))
                return NotFound ();

            var todo = await _repository.FindAsync (id);

            todo.Check (isComplete);

            await _repository.UpdateAsync (todo);
            
            await _repository.Commit();

            return Accepted (todo);
        }

        [HttpDelete ("{id:Guid}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete (Guid id) {

            if (!await _repository.AnyAsync (id))
                return NoContent ();

            await _repository.DeleteAsync (id);

            await _repository.Commit();
            
            return Ok ();
        }
    }
}