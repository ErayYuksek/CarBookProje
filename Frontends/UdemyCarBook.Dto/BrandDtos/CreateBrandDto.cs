using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BrandDtos
{
    public class CreateBrandDto
    {
        [JsonProperty("brandName")]
        public string BrandName { get; set; }
    }

}
