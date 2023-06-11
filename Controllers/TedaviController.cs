using CelilCavus.Entites;
using CelilCavus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [Route("api/[Contoller]")]
    [ApiController]
    public class TedaviController:ControllerBase
    {
        
    
        private readonly IRepository<Tedavi> _repository;

        public TedaviController(IRepository<Tedavi> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult getTedavi()
        {
            try
            {
                var getTedaviValues = _repository.GetAll();
                if (getTedaviValues is not null)
                {
                    return Ok(getTedaviValues);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Tedaviu Exception ex " + ex.Message);
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public IActionResult getTedavi(int id)
        {
            try
            {
                if (id >= 1)
                {
                    var getTedaviValues = _repository.GetById(id);
                    if (getTedaviValues is not null)
                    {
                        return Ok(getTedaviValues);
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
                System.Console.WriteLine("Tedaviu Exception ex " + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult postTedavi(Tedavi Tedavi)
        {
            try
            {
                if (Tedavi is not null)
                {
                    _repository.Add(Tedavi);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Tedavi Exception ex " + ex.Message);
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult putTedavi(Tedavi Tedavi)
        {
            try
            {
                if (Tedavi is not null)
                {
                    _repository.Update(Tedavi);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Tedavi Exception ex " + ex.Message);
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult deleteTedavi(int id)
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
                System.Console.WriteLine("Tedavi Exception ex " + ex.Message);
                return BadRequest();
            }
        }
    }
}
