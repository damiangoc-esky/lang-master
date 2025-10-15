using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageLearningAPI.Models;
using LanguageLearningAPI.Repositories;

namespace LanguageLearningAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly DatabaseRepository _repository;

        public ApiController(DatabaseRepository repository)
        {
            _repository = repository;
        }

        // Users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _repository.GetAllEntitiesAsync<User>());
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _repository.GetEntityByIdAsync<User>(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("users")]
        public async Task<ActionResult> CreateUser(User user)
        {
            await _repository.AddEntityAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserID)
            {
                return BadRequest();
            }
            await _repository.UpdateEntityAsync(user);
            return NoContent();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repository.GetEntityByIdAsync<User>(id);
            if (user == null)
            {
                return NotFound();
            }
            await _repository.DeleteEntityAsync(user);
            return NoContent();
        }

        // Learning Plans
        [HttpGet("learning-plans")]
        public async Task<ActionResult<IEnumerable<LearningPlan>>> GetLearningPlans()
        {
            return Ok(await _repository.GetAllEntitiesAsync<LearningPlan>());
        }

        [HttpGet("learning-plans/{id}")]
        public async Task<ActionResult<LearningPlan>> GetLearningPlan(int id)
        {
            var plan = await _repository.GetEntityByIdAsync<LearningPlan>(id);
            if (plan == null)
            {
                return NotFound();
            }
            return Ok(plan);
        }

        [HttpPost("learning-plans")]
        public async Task<ActionResult> CreateLearningPlan(LearningPlan plan)
        {
            await _repository.AddEntityAsync(plan);
            return CreatedAtAction(nameof(GetLearningPlan), new { id = plan.PlanID }, plan);
        }

        [HttpPut("learning-plans/{id}")]
        public async Task<IActionResult> UpdateLearningPlan(int id, LearningPlan plan)
        {
            if (id != plan.PlanID)
            {
                return BadRequest();
            }
            await _repository.UpdateEntityAsync(plan);
            return NoContent();
        }

        [HttpDelete("learning-plans/{id}")]
        public async Task<IActionResult> DeleteLearningPlan(int id)
        {
            var plan = await _repository.GetEntityByIdAsync<LearningPlan>(id);
            if (plan == null)
            {
                return NotFound();
            }
            await _repository.DeleteEntityAsync(plan);
            return NoContent();
        }

        // Translation Groups
        [HttpGet("translation-groups")]
        public async Task<ActionResult<IEnumerable<TranslationGroup>>> GetTranslationGroups()
        {
            return Ok(await _repository.GetAllEntitiesAsync<TranslationGroup>());
        }

        [HttpGet("translation-groups/{id}")]
        public async Task<ActionResult<TranslationGroup>> GetTranslationGroup(int id)
        {
            var group = await _repository.GetEntityByIdAsync<TranslationGroup>(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost("translation-groups")]
        public async Task<ActionResult> CreateTranslationGroup(TranslationGroup group)
        {
            await _repository.AddEntityAsync(group);
            return CreatedAtAction(nameof(GetTranslationGroup), new { id = group.GroupID }, group);
        }

        [HttpPut("translation-groups/{id}")]
        public async Task<IActionResult> UpdateTranslationGroup(int id, TranslationGroup group)
        {
            if (id != group.GroupID)
            {
                return BadRequest();
            }
            await _repository.UpdateEntityAsync(group);
            return NoContent();
        }

        [HttpDelete("translation-groups/{id}")]
        public async Task<IActionResult> DeleteTranslationGroup(int id)
        {
            var group = await _repository.GetEntityByIdAsync<TranslationGroup>(id);
            if (group == null)
            {
                return NotFound();
            }
            await _repository.DeleteEntityAsync(group);
            return NoContent();
        }

        // Translation Pairs
        [HttpGet("translation-pairs")]
        public async Task<ActionResult<IEnumerable<TranslationPair>>> GetTranslationPairs()
        {
            return Ok(await _repository.GetAllEntitiesAsync<TranslationPair>());
        }

        [HttpGet("translation-pairs/{id}")]
        public async Task<ActionResult<TranslationPair>> GetTranslationPair(int id)
        {
            var pair = await _repository.GetEntityByIdAsync<TranslationPair>(id);
            if (pair == null)
            {
                return NotFound();
            }
            return Ok(pair);
        }

        [HttpPost("translation-pairs")]
        public async Task<ActionResult> CreateTranslationPair(TranslationPair pair)
        {
            await _repository.AddEntityAsync(pair);
            return CreatedAtAction(nameof(GetTranslationPair), new { id = pair.PairID }, pair);
        }

        [HttpPut("translation-pairs/{id}")]
        public async Task<IActionResult> UpdateTranslationPair(int id, TranslationPair pair)
        {
            if (id != pair.PairID)
            {
                return BadRequest();
            }
            await _repository.UpdateEntityAsync(pair);
            return NoContent();
        }

        [HttpDelete("translation-pairs/{id}")]
        public async Task<IActionResult> DeleteTranslationPair(int id)
        {
            var pair = await _repository.GetEntityByIdAsync<TranslationPair>(id);
            if (pair == null)
            {
                return NotFound();
            }
            await _repository.DeleteEntityAsync(pair);
            return NoContent();
        }
    }
}
