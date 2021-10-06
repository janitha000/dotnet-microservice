using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Models
{
    public class Framework
    {
        public int FrameworkID { get; set; }
        public string Name { get; set; }
        public Platform Platform { get; set; }
    }
}
