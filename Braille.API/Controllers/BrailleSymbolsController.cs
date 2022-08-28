using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Braille.Data.Models;
using Braille.Data.Models.Dtos;
using Braille.Data.Repository.IRepository;

namespace Braille.Controllers
{
    //[Route("api/BrailleSymbols")]
    [Route("api/v{version:apiVersion}/BrailleSymbols")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "BrailleOpenAPISpecBrailleSymbols")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class BrailleSymbolsController : ControllerBase
    {
        private readonly IBrailleSymbolRepository _BrailleSymbolRepo;
        private readonly IMapper _mapper;

        public BrailleSymbolsController(IBrailleSymbolRepository BrailleSymbolRepo, IMapper mapper)
        {
            _BrailleSymbolRepo = BrailleSymbolRepo;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all BrailleSymbols.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type =typeof(List<BrailleSymbolDto>))]
        public IActionResult GetBrailleSymbols()
        {
            var objList = _BrailleSymbolRepo.GetBrailleSymbols();
            var objDto = new List<BrailleSymbolDto>();
            foreach (var obj in objList) {
                objDto.Add(_mapper.Map<BrailleSymbolDto>(obj));
            }
            return Ok(objDto);
        }

        /// <summary>
        /// Get individual BrailleSymbol.
        /// </summary>
        /// <param name="BrailleSymbolId"> The id of the BrailleSymbol </param>
        /// <returns></returns>
        [HttpGet("{BrailleSymbolId:int}", Name = "GetBrailleSymbol")]
        [ProducesResponseType(200, Type = typeof(BrailleSymbolDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        [Authorize(Roles ="Admin")]
        public IActionResult GetBrailleSymbol(int BrailleSymbolId)
        {
            var obj = _BrailleSymbolRepo.GetBrailleSymbol(BrailleSymbolId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<BrailleSymbolDto>(obj);
            
            return Ok(objDto);

        }

        /// <summary>
        /// Find BrailleSymbol by AsciiCharactersId
        /// </summary>
        [HttpGet("[action]/{AsciiCharacterId:int}")]
        [ProducesResponseType(200, Type = typeof(BrailleSymbolDto))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetBrailleSymbolInAsciiCharacter(int AsciiCharacterId)
        {
            var objList = _BrailleSymbolRepo.GetBrailleSymbolsInAsciiCharacter(AsciiCharacterId);
            if (objList == null)
            {
                return NotFound();
            }
            var objDto = new List<BrailleSymbolDto>();
            foreach(var obj in objList)
            {
                 objDto.Add(_mapper.Map<BrailleSymbolDto>(obj));
            }
            

            return Ok(objDto);

        }

        /// <summary>
        /// Create Braille Symbol
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BrailleSymbolDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateBrailleSymbol([FromBody] BrailleSymbolCreateDto BrailleSymbolDto)
        {
            if (BrailleSymbolDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_BrailleSymbolRepo.BrailleSymbolExists(BrailleSymbolDto.Name))
            {
                ModelState.AddModelError("", "BrailleSymbol Exists!");
                return StatusCode(404, ModelState);
            }
            var BrailleSymbolObj = _mapper.Map<BrailleSymbol>(BrailleSymbolDto);
            if (!_BrailleSymbolRepo.CreateBrailleSymbol(BrailleSymbolObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {BrailleSymbolObj.Name}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetBrailleSymbol", new { BrailleSymbolId= BrailleSymbolObj.Id }, BrailleSymbolObj);
        }


        /// <summary>
        /// Update Braille Symbol
        /// </summary>
        [HttpPatch("{BrailleSymbolId:int}", Name = "UpdateBrailleSymbol")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateBrailleSymbol(int BrailleSymbolId, [FromBody] BrailleSymbolUpdateDto BrailleSymbolDto)
        {
            if (BrailleSymbolDto == null || BrailleSymbolId!=BrailleSymbolDto.Id)
            {
                return BadRequest(ModelState);
            }

            var BrailleSymbolObj = _mapper.Map<BrailleSymbol>(BrailleSymbolDto);
            if (!_BrailleSymbolRepo.UpdateBrailleSymbol(BrailleSymbolObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {BrailleSymbolObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        /// <summary>
        /// Delete Braille Symbol
        /// </summary>
        [HttpDelete("{BrailleSymbolId:int}", Name = "DeleteBrailleSymbol")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteBrailleSymbol(int BrailleSymbolId)
        {
            if (!_BrailleSymbolRepo.BrailleSymbolExists(BrailleSymbolId))
            {
                return NotFound();
            }

            var BrailleSymbolObj = _BrailleSymbolRepo.GetBrailleSymbol(BrailleSymbolId);
            if (!_BrailleSymbolRepo.DeleteBrailleSymbol(BrailleSymbolObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {BrailleSymbolObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}