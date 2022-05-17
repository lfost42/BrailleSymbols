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
    [Route("api/v{version:apiVersion}/SpecialSymbols")]
    [ApiVersion("2.0")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "BrailleSymbolsOpenAPISpec")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class SpecialSymbolsV2Controller : Controller
    {
        private readonly ISpecialSymbolsRepository _ssr;
        private readonly IMapper _map;

        public SpecialSymbolsV2Controller(
            ISpecialSymbolsRepository ssr,
            IMapper map)
        {
            _ssr = ssr;
            _map = map;
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
            var ssObj = _ssr.GetSpecialSymbolModels().FirstOrDefault();
            return Ok(_map.Map<SpecialSymbolsModelDto>(ssObj));
        }

       

    }
}