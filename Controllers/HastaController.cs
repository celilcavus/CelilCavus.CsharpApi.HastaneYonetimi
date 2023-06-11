using CelilCavus.Entites;
using CelilCavus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        private readonly IRepository<Hasta> _repository;

        public HastaController(IRepository<Hasta> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult getHasta()
        {
            try
            {
                var getHastaValues = _repository.GetAll();
                if (getHastaValues is not null)
                {
                    return Ok(getHastaValues);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hasta Exception ex " + ex.Message);
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult getHasta(int id)
        {
            try
            {
                if (id >= 1)
                {
                    var getHastaValues = _repository.GetAll();
                    if (getHastaValues is not null)
                    {
                        return Ok(getHastaValues);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else { return NotFound(); }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hasta Exception ex " + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult postHasta(Hasta hasta)
        {
            try
            {
                if (hasta is not null)
                {
                    _repository.Add(hasta);
                    return NoContent();
                }
                else { return NotFound(); }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hasta Exception ex " + ex.Message);
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult putHasta(Hasta hasta)
        {
            try
            {
                if (hasta is not null)
                {
                    _repository.Update(hasta);
                    return NoContent();
                }
                else { return NotFound(); }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hasta Exception ex " + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteHata(int id)
        {
            try
            {
                if (id >= 1)
                {
                    _repository.Remove(id);
                    return NoContent();
                }
                else { return NotFound(); }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Hasta Exception ex " + ex.Message);
                return BadRequest();
            }
        }
    }
}