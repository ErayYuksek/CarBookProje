using UCarBook.Domain.Entities;

namespace UCarBook.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}


//Evet, public Blog Blog { get; set; }
//ifadesi, o TagCloud nesnesine bağlı olan Blog nesnesinin özelliklerini getirir.