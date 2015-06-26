using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobo.Pags
{
    public class RssGlobo
    {
        private string _description;
        public string title { get; set; }
        public string pubDate { get; set; }
        
        public string description 
        {
            get { return _description.Replace("<p>", "").Replace("</p>", "").Replace("<a style=", "").Replace("color:#ff0000; font-weight:bold;", "").Replace("href=", "").Replace("</a>", "").Replace(">", ""); }
            set { _description = value; }
        }
        public string link { get; set; }



    }
}
