using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class New
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public int View { get; set; }

        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
