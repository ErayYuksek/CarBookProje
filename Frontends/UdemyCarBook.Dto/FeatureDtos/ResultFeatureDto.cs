using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.FeatureDtos
{
    public class ResultFeatureDto
    {
        [JsonProperty("featureID")]  // API'den gelen "featureID" ile eşleşmesini sağlıyoruz
        public int FeatureID { get; set; }

        [JsonProperty("name")]  // API'deki "name" ile eşleşmesini sağlıyoruz
        public string Name { get; set; }
    }
}
