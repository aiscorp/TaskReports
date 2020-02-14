using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReportLib.Data;

namespace TaskReportLib.Services.EF
{
    public class DataContextProvider
    {

        public string ConnectionString { get; set; } = "name=DbConnection";

        public TaskReportsDb CreateContext() => new TaskReportsDb(ConnectionString);
    }
}
