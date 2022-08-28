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
    [Route("api/v{version:apiVersion}/AsciiCharacters")]
    //[Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "BrailleOpenAPISpecNP")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AsciiCharactersController : ControllerBase
    {
        private readonly IAsciiCharacterRepository _npRepo;
        private readonly IMapper _mapper;

        public AsciiCharactersController(IAsciiCharacterRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }


        /// <summary>
        /// Get all ascii character symbols
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type =typeof(List<AsciiCharacterDto>))]
        public IActionResult GetAsciiCharacters()
        {
            var objList = _npRepo.GetAsciiCharacters();
            var objDto = new List<AsciiCharacterDto>();
            foreach (var obj in objList) {
                objDto.Add(_mapper.Map<AsciiCharacterDto>(obj));
            }
            return Ok(objDto);
        }

        /// <summary>
        /// Get individual ascii character symbol
        /// </summary>
        /// <param name="AsciiCharacterId"> The Id of the ascii character </param>
        /// <returns></returns>
        [HttpGet("{AsciiCharacterId:int}", Name = "GetAsciiCharacter")]
        [ProducesResponseType(200, Type = typeof(AsciiCharacterDto))]
        [ProducesResponseType(404)]
        [Authorize]
        [ProducesDefaultResponseType]
        public IActionResult GetAsciiCharacter(int AsciiCharacterId)
        {
            var obj = _npRepo.GetAsciiCharacter(AsciiCharacterId);
            if (obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<AsciiCharacterDto>(obj);
            return Ok(objDto);

        }

        /// <summary>
        /// Create new ascii character symbol
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AsciiCharacterDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAsciiCharacter([FromBody] AsciiCharacterDto AsciiCharacterDto)
        {
            if (AsciiCharacterDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_npRepo.AsciiCharacterExists(AsciiCharacterDto.Characters))
            {
                ModelState.AddModelError("", "Ascii Character Exists!");
                return StatusCode(404, ModelState);
            }
            var AsciiCharacterObj = _mapper.Map<AsciiCharacter>(AsciiCharacterDto);
            if (!_npRepo.CreateAsciiCharacter(AsciiCharacterObj))
            {
                ModelState.AddModelError("", $"Saving for {AsciiCharacterObj.Characters} error!");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetAsciiCharacter", new { AsciiCharacterId= AsciiCharacterObj.Id }, AsciiCharacterObj);
        }

        /// <summary>
        /// Update ascii character symbol
        /// </summary>
        [HttpPatch("{AsciiCharacterId:int}", Name = "UpdateAsciiCharacter")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateAsciiCharacter(int AsciiCharacterId, [FromBody] AsciiCharacterDto AsciiCharacterDto)
        {
            if (AsciiCharacterDto == null || AsciiCharacterId!=AsciiCharacterDto.Id)
            {
                return BadRequest(ModelState);
            }

            var AsciiCharacterObj = _mapper.Map<AsciiCharacter>(AsciiCharacterDto);
            if (!_npRepo.UpdateAsciiCharacter(AsciiCharacterObj))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {AsciiCharacterObj.Characters}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

        /// <summary>
        /// Delete ascii character symbol
        /// </summary>
        [HttpDelete("{AsciiCharacterId:int}", Name = "DeleteAsciiCharacter")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAsciiCharacter(int AsciiCharacterId)
        {
            if (!_npRepo.AsciiCharacterExists(AsciiCharacterId))
            {
                return NotFound();
            }

            var AsciiCharacterObj = _npRepo.GetAsciiCharacter(AsciiCharacterId);
            if (!_npRepo.DeleteAsciiCharacter(AsciiCharacterObj))
            {
                ModelState.AddModelError("", $"Something went wrong when deleting the record {AsciiCharacterObj.Characters}");
                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}