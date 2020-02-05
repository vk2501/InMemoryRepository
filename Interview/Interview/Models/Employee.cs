using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Models
{
    public class Employee : IStoreable<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
