using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TectoluxConfigurator.Data.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsArchived { get; set; }
    }
}
