using BL.Service;
using DL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
<<<<<<< HEAD
    { 
=======
    {
>>>>>>> 593e67366a53dc4b88d3c2570fe7d6da20ceee32
        private readonly IService bs;
        public ValuesController(IService _service)
        {
            bs = _service;
<<<<<<< HEAD
        } 
          
=======
        }


>>>>>>> 593e67366a53dc4b88d3c2570fe7d6da20ceee32
        [HttpGet("GetKisiler")]
        public async Task< IActionResult> GetKisiler()
        {
            var kisiler = await bs.GetAll();
            return Ok(kisiler);
        }

        [HttpGet("GetKisi/{id}")]
        public IActionResult GetKisi(int id)
        {
            var kisi = bs.GetById(id);
            if (kisi == null)
            {
                return NotFound();
            }
            return Ok(kisi);
        }

        [HttpPost("AddKisi")]
        public IActionResult AddKisi([FromBody] Kisi kisi)
        {
            bs.Add(kisi);
            return CreatedAtAction(nameof(GetKisi), new { id = kisi.Id }, kisi);
        }

        [HttpPut("UpdateKisi/{id}")]
        public IActionResult UpdateKisi(int id, [FromBody] Kisi kisi)
        {
            var existingKisi = bs.GetById(id);
            if (existingKisi == null)
            {
                return NotFound();
            }

            kisi.Id = id;
            bs.Update(kisi);
            return NoContent();
        }

        [HttpDelete("DeleteKisi/{id}")]
        public IActionResult DeleteKisi(int id)
        {
            var existingKisi = bs.GetById(id);
            if (existingKisi == null)
            {
                return NotFound();
            }

            bs.Delete(id);
            return NoContent();
        }

    }
}
