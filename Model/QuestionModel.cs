using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crowdience.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int questionNumber { get; set; }
        public string questionTitle { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}