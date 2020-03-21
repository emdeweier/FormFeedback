using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class RoomVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Floor { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
