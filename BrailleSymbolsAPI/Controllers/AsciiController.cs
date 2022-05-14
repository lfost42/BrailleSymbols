using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrailleSymbols.Data.Models;
using BrailleSymbols.Data.Models.Dtos;
using BrailleSymbols.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BrailleSymbolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsciiController : Controller
    {
        private IAsciiRepository _ar;
        private readonly IMapper _map;

        public AsciiController(
            IAsciiRepository ar,
            IMapper map)
        {
            _ar = ar;
            _map = map;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAsciis()
        {
            var asciiList = _ar.GetAsciis();

            //using Dto to avoid exposing our objects directly to the API endpoint
            var asciiDto = new List<AsciiModelDto>();
            foreach (var ascii in asciiList)
            {
                asciiDto.Add(_map.Map<AsciiModelDto>(ascii));
            }

            return Ok(asciiDto);
        }

        [HttpGet("id:int", Name ="GetAsciiModel")]
        public IActionResult GetAsciiModel(int id)
        {
            var ascii = _ar.GetAsciiModel(id);
            if (ascii == null)
            {
                return NotFound();
            }
            var asciiDto = _map.Map<AsciiModelDto>(ascii);
            return Ok(asciiDto);
        }

        [HttpPost]
        public IActionResult CreateAsciiModel([FromBody] AsciiModelDto asciiModelDto)
        {
            if (asciiModelDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ar.AsciiExists(asciiModelDto.AsciiSymbol))
            {
                ModelState.AddModelError("", "Ascii symbol already in system");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asciiModelObj = _map.Map<AsciiModel>(asciiModelDto);

            if(!_ar.UpdateAsciiModel(asciiModelObj))
            {
                ModelState.AddModelError("", $"Unable to add {asciiModelObj.AsciiSymbol}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetAsciiModel", new { id = asciiModelObj.Id }, asciiModelObj );
        }

        [HttpPatch("id:int", Name = "GetAsciiModel")]
        public IActionResult UpdateAsciiModel(int id, [FromBody] AsciiModelDto asciiModelDto)
        {
            if (asciiModelDto == null || id != asciiModelDto.Id)
            {
                return BadRequest(ModelState);
            }

            var asciiModelObj = _map.Map<AsciiModel>(asciiModelDto);

            if (!_ar.UpdateAscii(asciiModelObj))
            {
                ModelState.AddModelError("", $"Unable to uddate {asciiModelObj.AsciiSymbol}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("id:int", Name = "GetAsciiModel")]
        public IActionResult DeleteAsciiModel(int id)
        {
            if (!_ar.AsciiModelExists(id))
            {
                return NotFound();
            }

            var asciiModelObj = _ar.GetAsciiModel(id);

            if (!_ar.DeleteAsciiModel(asciiModelObj))
            {
                ModelState.AddModelError("", $"Unable to delete {asciiModelObj.AsciiSymbol}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }



    }
}