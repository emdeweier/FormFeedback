using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels.Graph
{
    public class GraphRoomEventVM
    {
        public string label { get; set; }
        public int value { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
}
