using System;
using System.Collections.Generic;
using System.Linq;
using TaskReportLib.Entityes;
using TaskReportLib.Services.Interfaces;

namespace TaskReportLib.Services.EF
{
    public class EFJobsDataProvider : EFDataProvider<Tag>, ITagsDataProvider
    {
        public EFJobsDataProvider(DataContextProvider db) : base(db) { }
    }
}