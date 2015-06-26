using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobo.Utilidades
{
    public class Utils
    {

        public static String ReadFile(String path)
        {
            var resource = App.GetResourceStream(new Uri(path, UriKind.Relative));
            if (resource == null)
            {
                return null;
            }
            StreamReader reader = new StreamReader(resource.Stream);
            String arquivo = reader.ReadToEnd();
            return arquivo;
        }

    }
}
