namespace UdemyCarBook.Dto.BlogDtos
{
    public class GetBlogById
    {
        public int BlogID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorID { get; set; }

        public string? CoverImageUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }

        //public string /*Descripton*/ { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
