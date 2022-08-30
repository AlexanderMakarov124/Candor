using Candor.DataAccess;
using Candor.Domain.Models;

namespace Candor.IntegrationTests.Utility
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationContext db)
        {
            var user1 = new User { UserName = "User1", Email = "User1@gmail.com" };
            var user2 = new User { UserName = "User2", Email = "User2@gmail.com" };
            var user3 = new User { UserName = "User3", Email = "User3@gmail.com" };
            db.Users.Add(user1);
            db.Users.Add(user2);
            db.Users.Add(user3);
            db.Posts.AddRange(new List<Post>
            {
                new Post { Title = "Post1", Content = "TEST RECORD: You're standing on my scarf.", User = user1},
                new Post { Title = "Post2", Content = "TEST RECORD: Would you like a jelly baby?", User = user2 },
                new Post { Title = "Post3", Content = "TEST RECORD: To the rational mind", User = user3 }
            });
            db.SaveChanges();
        }
    }
}
