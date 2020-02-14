using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TaskReportLib.Entityes
{
    public class Job : BaseEntity
    {
        // -----
        public string Name { get; set; }
        public string Description { get; set; }
        // -----
        // Связь
        public virtual User User { get; set; }        
        // -----
        [Column(TypeName = "datetime2")] public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime2")] public DateTime EndTime { get; set; }
        [Column(TypeName = "datetime2")] public DateTime DeltaTime { get; set; }

        // Saving color int format #RRGGBB (like #ffaacc)
        [MaxLength(7)] public string Color { get; set; }

    }
}
