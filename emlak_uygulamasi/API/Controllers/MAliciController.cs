using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    // [Authorize]
    public class MAliciController : BaseController
    {
        private readonly DataContext _context;
        public IMapper mapper { get; }
        private readonly IMapper _mapper;
        public MAliciController(DataContext context, IMapper mapperr)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusteriAlici>>> GetAliciMusteri()
        {
            var musteriler = await _context.AliciMusteriler.ToListAsync();

            return Ok(musteriler);
        }

        [HttpPost]
        public async Task AddMusteriAlici(MusteriAlici musteriAlici)
        {

            var musteri = new MusteriAlici
            {
                Isim = musteriAlici.Isim,
                CepTelefonNo = musteriAlici.CepTelefonNo,
                Email = musteriAlici.Email,
                EvTuru = musteriAlici.EvTuru
            };

            _context.AliciMusteriler.Add(musteri);
            await _context.SaveChangesAsync();
        }
    }
}