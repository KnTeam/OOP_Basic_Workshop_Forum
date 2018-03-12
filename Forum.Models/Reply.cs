namespace Forum.Models
{
    using System.Collections.Generic;

    public class Reply
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }
        public int PostId { get; set; }
    }
}
