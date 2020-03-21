using FormFeedbackAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.Models
{
    [Table("TB_M_Participant")]
    public class Participant : BaseModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int BatchId { get; set; }
    }
}
