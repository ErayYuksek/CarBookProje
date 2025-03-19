using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BannerDtos
{
    public class UpdateBannerDto
    {
        [JsonProperty("bannerID")]
        public int BannerID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("videoDescription")]
        public string VideoDescription { get; set; }

        [JsonProperty("videoUrl")]
        public string VideoUrl { get; set; }
    }
}
