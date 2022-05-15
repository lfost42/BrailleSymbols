using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrailleSymbols.Data.Models;
using BrailleSymbols.Data.Models.Dtos;
using BrailleSymbols.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrailleSymbolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class SpecialSymbolsController : Controller
    {
        private readonly ISpecialSymbolsRepository _ssr;
        private readonly IMapper _map;

        public SpecialSymbolsController(
            ISpecialSymbolsRepository ssr,
            IMapper map)
        {
            _ssr = ssr;
            _map = map;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Get all symbols.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllSymbols")]
        [ProducesResponseType(200, Type = typeof(List<SpecialSymbolsModelDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetSpecialSymbolsModels()
        {
            var specialSymbolsList = _ssr.GetSpecialSymbolModels();

            //using Dto to avoid exposing our objects directly to the API endpoint
            var ssmDto = new List<SpecialSymbolsModelDto>();
            foreach (var symb in specialSymbolsList)
            {
                ssmDto.Add(_map.Map<SpecialSymbolsModelDto>(symb));
            }

            return Ok(ssmDto);
        }

        /// <summary>
        /// View symbol. 
        /// </summary>
        /// <param name="id">Id of the special symbol</param>
        /// <returns></returns>
        [HttpGet("id:int", Name = "GetSpecialSymbols")]
        [ProducesResponseType(200, Type = typeof(SpecialSymbolsModelDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetSpecialSymbolsModel(int id)
        {
            var ssm = _ssr.GetSpecialSymbolsModel(id);
            if (ssm == null)
            {
                return NotFound();
            }
            var ssmDto = _map.Map<SpecialSymbolsModelDto>(ssm);
            return Ok(ssmDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SpecialSymbolsModelDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateSpecialSymbolsModel([FromBody] SpecialSymbolsModelDto specialSymbolsModelDto)
        {
            if (specialSymbolsModelDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ssr.SpecialSymbolsModelExists(specialSymbolsModelDto.SymbolName))
            {
                ModelState.AddModelError("", "specialSymbolsModel already in system");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ssmObj = _map.Map<SpecialSymbolsModel>(specialSymbolsModelDto);

            if (!_ssr.CreateSpecialSymbolsModel(ssmObj))
            {
                ModelState.AddModelError("", $"Unable to add {ssmObj.SymbolName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetSpecialSymbolsModel", new { id = ssmObj.Id }, ssmObj);
        }

        [HttpPatch("{id:int}", Name = "UpdateSpecialSymbolsModel")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateSpecialSymbolsModel(int id, [FromBody] SpecialSymbolsModelDto specialSymbolsModelDto)
        {
            if (specialSymbolsModelDto == null || id != specialSymbolsModelDto.Id)
            {
                return BadRequest(ModelState);
            }

            var ssmObj = _map.Map<SpecialSymbolsModel>(specialSymbolsModelDto);

            if (!_ssr.UpdateSpecialSymbolsModel(ssmObj))
            {
                ModelState.AddModelError("", $"Unable to update {ssmObj.SymbolName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "UpdateSpecialSymbolsModel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteSpecialSymbolsModel(int id)

        {
            if (!_ssr.SpecialSymbolsModelExists(id))
            {
                return NotFound();
            }

            var ssmObj = _map.Map<SpecialSymbolsModel>(id);

            if (!_ssr.DeleteSpecialSymbolsModel(ssmObj))
            {
                ModelState.AddModelError("", $"Unable to delete {ssmObj.SymbolName}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}