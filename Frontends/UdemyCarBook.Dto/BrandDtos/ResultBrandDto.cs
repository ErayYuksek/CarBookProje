using Newtonsoft.Json;  // JSON dönüşümleri için gerekli kütüphane

namespace UdemyCarBook.Dto.BrandDtos
{
    public class ResultBrandDto
    {
        [JsonProperty("brandID")]  // API'deki "brandID" ile birebir eşleşmesi için
        public int brandID { get; set; }

        [JsonProperty("name")]  // API'deki "name" ile birebir eşleşmesi için
        public string? name { get; set; }
    }



}
