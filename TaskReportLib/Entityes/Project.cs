﻿using System;
using System.Collections.Generic;
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
        public SolidColorBrush Color { get; set; }
        // -----
        public virtual User User { get; set; }
    }
}
