using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ML
{
    public class Result
    {
        public string Messages { get; set; }
        public Exception ex { get; set; }
        public bool Correct { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }
        [DisplayName("Archvio")]
        public HttpPostedFileBase file { get; set; }
        [DisplayName("Cadena")]
        public string Path { get; set; }
    }
}
