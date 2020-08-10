using System;

namespace Interview_Task
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Post(int id, int userId, string title, string body)
        {
            this.Id = id;
            this.UserId = userId;
            this.Title = title;
            this.Body = body;
        }
    }
}
