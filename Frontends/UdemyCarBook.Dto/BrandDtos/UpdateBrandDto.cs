using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BrandDtos
{
    public class UpdateBrandDto
    {
        // [JsonProperty("brandID")]  // JSON'daki "brandID" alanını "BrandID" ile eşleştir
        public int brandID { get; set; }

        //[JsonProperty("name")]  // JSON'daki "name" alanını "BrandName" ile eşleştir
        public string name { get; set; }
    }
}
