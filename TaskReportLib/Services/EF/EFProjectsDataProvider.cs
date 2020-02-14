using System;
using System.Collections.Generic;
using System.Linq;
using TaskReportLib.Entityes;
using TaskReportLib.Services.Interfaces;

namespace TaskReportLib.Services.EF
{
    public class EFProjectsDataProvider : EFDataProvider<Tag>, ITagsDataProvider    
    {
        public EFProjectsDataProvider(DataContextProvider db) : base(db) { }
    }
}
