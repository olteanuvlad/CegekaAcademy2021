using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework04.Models
{
    public class LinksWrapper
    {
        public Object Target { get; set; }
        public List<LinkInfo> Links { get; set; }

        public LinksWrapper()
        {
            Target = null;
            Links = null;
        }
        
        public LinksWrapper(Object target, List<LinkInfo> links)
        {
            Target = target;
            Links = links;
        }
    }
}
