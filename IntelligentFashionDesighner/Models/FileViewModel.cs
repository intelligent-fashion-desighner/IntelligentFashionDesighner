using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentFashionDesighner.Models
{
    public class FileViewModel
    {
        public FileViewModel()
        {
           namesOfFiles = new List<string>();
        }
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
        public int noOfImages { get; set; }

        public List<string> namesOfFiles { get; set; }

    }
}