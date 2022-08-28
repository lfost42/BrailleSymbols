using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Braille.Data.Models;
using Braille.Data.Models.Dtos;
using Braille.Data.Repository.IRepository;

namespace Braille.Controllers
{
    [Route("api/v{version:apiVersion}/AsciiCharacters")]
    [ApiVersion("2.0")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "BrailleOpenAPISpecNP")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AsciiCharactersV2Controller : ControllerBase
    {
        private readonly IAsciiCharacterRepository _npRepo;
        private readonly IMapper _mapper;

        public AsciiCharactersV2Controller(IAsciiCharacterRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }


        /// <summary>
        /// Get list of ascii characters.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type =typeof(List<AsciiCharacterDto>))]
        public IActionResult GetAsciiCharacters()
        {
            var obj = _npRepo.GetAsciiCharacters().FirstOrDefault();
           
            return Ok(_mapper.Map<AsciiCharacterDto>(obj));
        }

    }
}