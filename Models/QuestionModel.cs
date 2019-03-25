using System.ComponentModel.DataAnnotations.Schema;

namespace crowdience.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }


        public int VoteOneTotal { get; set; }
        public int VoteTwoTotal { get; set; }
        public string CoupleOneVote { get; set; }
        public string CoupleTwoVote { get; set; }
    }
}