using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudRavendb.Modal
{
    public class DataSet
    {
        public string Id { get; set; }

        public string Rating { get; set; }

        public string Company { get; set; }

        public string Average { get; set; }

        public string Lowest { get; set; }

        public string Highest { get; set; }

        public string Date { get; set; }
    }
}
//Rating,Company,Average,Lowest,Highest,yr/mo/hr