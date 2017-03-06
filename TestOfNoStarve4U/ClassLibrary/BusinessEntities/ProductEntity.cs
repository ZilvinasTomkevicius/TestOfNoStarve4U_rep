using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Globalization;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ProductEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }        
    }
}
