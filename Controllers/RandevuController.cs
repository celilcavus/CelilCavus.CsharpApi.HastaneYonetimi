using CelilCavus.Entites;
using CelilCavus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [Route("api/[Contoller]")]
    [ApiController]
    public class RandevuController : ControllerBase
    {
        private readonly IRepository<Randevu> _repository;

        public RandevuController(IRepository<Randevu> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult getRandevu()
        {
            try
            {
                var getRandevuValues = _repository.GetAll();
                if (getRandevuValues is not null)
                {
                    return Ok(getRandevuValues);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Randevuu Exception ex " + ex.Message);
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public IActionResult getRandevu(int id)
        {
            try
            {
                if (id >= 1)
                {
                    var getRandevuValues = _repository.GetById(id);
                    if (getRandevuValues is not null)
                    {
                        return Ok(getRandevuValues);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else { return BadRequest(); }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Randevuu Exception ex " + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult postRandevu(Randevu randevu)
        {
            try
            {
                if (randevu is not null)
                {
                    _repository.Add(randevu);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Randevu Exception ex " + ex.Message);
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult putRandevu(Randevu randevu)
        {
            try
            {
                if (randevu is not null)
                {
                    _repository.Update(randevu);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Randevu Exception ex " + ex.Message);
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult deleteRandevu(int id)
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
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Randevu Exception ex " + ex.Message);
                return BadRequest();
            }
        }
    }
}