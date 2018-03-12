using System;

namespace Forum.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            var forumData = new ForumData();
            forumData.SaveChanges();
            foreach (var item in forumData.Categories)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(string.Join(",", item.PostIds));
            }

            Console.WriteLine();

            foreach (var item in forumData.Users)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Username);
                Console.WriteLine(item.Password);
                Console.WriteLine(string.Join(",", item.PostIds));
            }

            foreach (var item in forumData.Posts)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Content);
                Console.WriteLine(forumData.Users.Find(x => x.Id.Equals(item.AuthorId)).Username);
                Console.WriteLine(forumData.Categories.Find(x => x.Id.Equals(item.CategoryId)).Name);
                Console.WriteLine(string.Join(",", item.ReplyIds));
            }
        }
    }
}
