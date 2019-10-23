using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TaskReportLib.Entityes
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        // Saving color int format #RRGGBB (like #ffaacc)
        [MaxLength(7)] public string Color { get; set; }
        // -----
        public virtual User User { get; set; }
    }
}
