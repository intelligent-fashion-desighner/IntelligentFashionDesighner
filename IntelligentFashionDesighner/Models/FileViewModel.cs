using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentFashionDesighner.Models
{
    public class FileViewModel
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
        
    }
}