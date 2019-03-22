using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crowdience.Models
{
    public class Vote
    {
        public int Id { get; set; } 
       
        public int VoteOne { get; set; }
        public int VoteTwo { get; set; }
        public string coupleOne { get; set; }
        public string coupleTwo { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}