using Forum.Models;
using System;

namespace Forum.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            // var input = DataMapper.ReadLines(@"D:\Git\KnTeam\Workshop_Forum\Forum.Data\data");
            var forumData = new ForumData();

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

            forumData.Categories.Add(new Category(10, "Test", new int[0]));
            forumData.SaveChanges();
        }
    }
}
