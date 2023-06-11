using CelilCavus.Entites;
using CelilCavus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DoktorController : ControllerBase
    {
        private readonly IRepository<Doktor> _repository;

        public DoktorController(IRepository<Doktor> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetDoktor()
        {
            try
            {
                var getDoktors = _repository.GetAll();
                if (getDoktors != null)
                {
                    return Ok(getDoktors);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Exception : " + ex.Message);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetDoktor(int id)
        {
            try
            {
                if (id! <= 0)
                {
                    var getDoktors = _repository.GetById(id);
                    if (getDoktors != null)
                    {
                        return Ok(getDoktors);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else{return NotFound();}
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Exception : " + ex.Message);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult PostDoktor(Doktor doktor)
        {
            try
            {
                if (doktor is not null)
                {
                    _repository.Add(doktor);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine("Exception ex : " + ex.Message);
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeletedOoktor(int id)
        {
            try
            {
                if (id > 0)
                {
                    _repository.Remove(id);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Doktor Delete Exception ex " + ex.Message);
                throw;
            }
        }

        [HttpPut]
        public IActionResult PutDoktor(Doktor doktor)
        {
            try
            {
                if (doktor is not null)
                {
                    _repository.Update(doktor);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Put Doktor Exception ex " + ex.Message);
                return NotFound();
            }
        }
    }
}