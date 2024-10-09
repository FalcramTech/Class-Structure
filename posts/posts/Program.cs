using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("Ivan Babenko", "vanyababenko@gmail.com", "@falcram");
        User user2 = new User("Max Kirstya", "maxKirstya@gmail.com", "@kepassa");

        user1.CreatePost("Hello, world!");
        user1.CreatePost("I love coding!");
        user1.CreatePost("Stranger Things my favorite serial");
        user1.CreatePost("I'm designer.");
        user1.CreatePost("What do you like to play ?");

        user2.CreatePost("Hi!");
        user2.CreatePost("Coffee Time");
        user2.CreatePost("Somewhere in a madhouse");
        user2.CreatePost("I'm barista .");
        user2.CreatePost("What Are You Waiting For");

        Console.WriteLine("Last 5 posts of user1:");
        user1.ShowLastFivePosts(user1);

        Console.WriteLine("\nLast 5 posts of user2:");
        user2.ShowLastFivePosts(user2);
    }
}
class Post
{
    public string Text { get; set; }
    public DateTime CreationDate { get; set; }
    public int Likes { get; set; }
    public List<string> Comments { get; set; }

    public Post(string text)
    {
        Text = text;
        CreationDate = DateTime.Now;
        Likes = 0;
        Comments = new List<string>();
    }

    public void AddLike()
    {
        Likes++;
    }

    public void AddComment(string comment)
    {
        Comments.Add(comment);
    }

    public override string ToString()
    {
        return $"Posted on {CreationDate}: {Text}\nLikes: {Likes}, Comments: {string.Join(", ", Comments)}";
    }
}

class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Nickname { get; set; }
    private List<Post> Posts { get; set; }

    public User(string name, string email, string nickname)
    {
        Name = name;
        Email = email;
        Nickname = nickname;
        Posts = new List<Post>();
    }

    public void CreatePost(string text)
    {
        Posts.Add(new Post(text));
    }

    public void DeletePost(Post post)
    {
        Posts.Remove(post);
    }

    public List<Post> GetLastFivePosts()
    {
        return Posts.OrderByDescending(p => p.CreationDate).Take(5).ToList();
    }

    public void LikePost(Post post)
    {
        post.AddLike();
    }

    public void CommentPost(Post post, string comment)
    {
        post.AddComment(comment);
    }

    public void ShowLastFivePosts(User anotherUser)
    {
        var lastPosts = anotherUser.GetLastFivePosts();
        foreach (var post in lastPosts)
        {
            Console.WriteLine(post.ToString());
        }
    }
}