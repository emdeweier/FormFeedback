using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormFeedbackAPI.ViewModels
{
    public class EmployeeVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NIK { get; set; }
        public int Department_Id { get; set; }
        public bool isDelete { get; set; }
    }
}
