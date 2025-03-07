using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;  // JSON dönüşümleri için gerekli kütüphane

namespace UdemyCarBook.Dto.BrandDtos
{
    public class ResultBrandDto
    {
        [JsonProperty("brandID")]  // JSON'daki "brandID" alanını "BrandID" ile eşleştir
        public int BrandID { get; set; }

        [JsonProperty("name")]  // JSON'daki "name" alanını "BrandName" ile eşleştir
        public string BrandName { get; set; }
    }
}
