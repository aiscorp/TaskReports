using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskReportLib.Entityes
{
    public class Job
    {
        public int Id { get; set; }
        // -----
        public string Name { get; set; }
        public string Description { get; set; }
        // -----
        public virtual User User { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual Project Project { get; set; }
        // -----
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DeltaTime { get; set; }

    }
}
