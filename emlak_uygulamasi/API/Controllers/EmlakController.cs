using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [Authorize]
    public class EmlakController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public EmlakController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmlakDto>>> GetMusteri()
        {
            var emlakKayitlari = await _context.EmlakKayitlari.Include(emlak => emlak.MusteriSatici).ToListAsync();
            var emlakToReturn = _mapper.Map<IEnumerable<EmlakDto>>(emlakKayitlari);
            return Ok(emlakToReturn);
        }
    }
}