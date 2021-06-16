using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataGenerator
    {
         public static async Task GenerateData(DataContext context)
        {
            if (await context.SaticiMusteriler.AnyAsync()) return; 

            var musteriData = await System.IO.File.ReadAllTextAsync("Data/MusteriData.json");
            var musteriler = JsonSerializer.Deserialize<List<MusteriSatici>>(musteriData);
            foreach (var musteri in musteriler)
            {

                context.SaticiMusteriler.Add(musteri);

            }

            await context.SaveChangesAsync();
        }
    }
}