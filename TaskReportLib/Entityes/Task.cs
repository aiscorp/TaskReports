using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskReportLib.Entityes
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public Tag Tag { get; set; }

        public Project Project { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }

    }
}
