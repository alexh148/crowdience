using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crowdience.Models
{
    public class Game
    {
        public int Id { get; set; }
        public bool inProgress { get; set; }
        public string uniqueID { get; set; }
        public string coupleOne { get; set; }
        public string coupleTwo { get; set; }

        public List<Question> Questions { get; set; }
    }
}