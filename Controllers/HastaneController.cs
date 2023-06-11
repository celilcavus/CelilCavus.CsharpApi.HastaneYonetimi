using CelilCavus.Entites;
using CelilCavus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly IRepository<Hastane> _repository;

        public HastaneController(IRepository<Hastane> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult getHastane()
        {
            try
            {
                var getHospital = _repository.GetAll();
                if (getHospital is not null)
                {
                    return Ok(getHospital);
                }
                else
                {
                    return Ok(Enumerable.Empty<Hastane>());
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hastane Exception ex " + ex.Message);
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult getHastane(int id)
        {
            try
            {
                if (id >= 1)
                {
                    var values = _repository.GetById(id);
                    if (values is not null)
                    {
                        return Ok(values);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult postHastane(Hastane hastane)
        {
            try
            {
                if (hastane is not null)
                {
                    _repository.Add(hastane);
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hastane Exception ex " + ex.Message);
                throw;
            }
        }

        [HttpPut]
        public IActionResult putHastane(Hastane hastane)
        {
            try
            {
                if (hastane is not null)
                {
                    _repository.Update(hastane);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hastane Exception ex " + ex.Message);
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult removeHastane(int id)
        {
            try
            {
                if (id >= 1)
                {
                    _repository.Remove(id);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hastane Exception ex " + ex.Message);
                return NotFound();
            }
        }
    }
}