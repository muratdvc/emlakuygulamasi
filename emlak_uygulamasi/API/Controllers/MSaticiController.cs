using System.Collections.Generic;
using System.Linq;
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
    public class MSaticiController : BaseController
    {
        private readonly DataContext _context;
        public IMapper Mapper { get; }
        private readonly IMapper _mapper;
        public MSaticiController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusteriSaticiDto>>> GetMusteriSatici()
        {
            var musteriler = await _context.SaticiMusteriler.Include(musteri => musteri.EmlakIlanlari).ToListAsync();
            var userToReturn = _mapper.Map<IEnumerable<MusteriSaticiDto>>(musteriler);
            return Ok(userToReturn);
        }


        [HttpPost]
        public async Task AddMusteriSatici(MusteriSatici musteriSatici) {

            var musteri = new MusteriSatici
            {
                 Isim = musteriSatici.Isim,
                CepTelefonNo = musteriSatici.CepTelefonNo,
                Email = musteriSatici.Email,
                EvTuru = musteriSatici.EvTuru,
                EmlakIlanlari = musteriSatici.EmlakIlanlari
            };

            _context.SaticiMusteriler.Add(musteri);
            await _context.SaveChangesAsync();
        } 


        [HttpDelete]
        public async Task DeleteMusteri()
        {
            var musteriler = await _context.SaticiMusteriler.ToListAsync();
            _context.SaticiMusteriler.RemoveRange(musteriler);
            _context.SaveChanges();
        }


    }
}