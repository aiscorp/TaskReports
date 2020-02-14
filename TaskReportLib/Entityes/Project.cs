using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TaskReportLib.Entityes
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        // -----
        public virtual User User { get; set; }

        // Saving color int format #RRGGBB (like #ffaacc)
        [MaxLength(7)] public string Color { get; set; }
    }
}
