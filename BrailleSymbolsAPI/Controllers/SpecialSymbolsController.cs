using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BrailleSymbols.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BrailleSymbolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SpecialSymbolsController : Controller
    {
        private ISpecialSymbolsRepository _ssr;
        private IAsciiRepository _ar;
        private readonly IMapper _map;

        public SpecialSymbolsController(ISpecialSymbolsRepository ssr,
            IAsciiRepository ar,
            IMapper map)
        {
            _ssr = ssr;
            _ar = ar;
            _map = map;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}