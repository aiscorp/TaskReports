using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReportLib.Entityes;
using TaskReportLib.Services.Interfaces;

namespace TaskReportLib.Services.EF
{
    public class EFTagsDataProvider : EFDataProvider<Tag>, ITagsDataProvider
    {
        public EFTagsDataProvider(DataContextProvider db) : base(db) { }
    }
}