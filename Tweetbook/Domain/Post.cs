using System;
using System.ComponentModel.DataAnnotations;

namespace Tweetbook.Domain
{
    public class Post
    {
        public Post()
        {
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}