using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class FeedbackVM
    {
        public string Answer { get; set; }
        public string Note { get; set; }
        public int QuestionId { get; set; }
        public int PointId { get; set; }
        public int ParticipantId { get; set; }
        public int EventId { get; set; }
    }
}
