using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FLAutomation.ComponentHelper
{
    class FileHelper
    {
        public static String SaveScreenShot(String absolutePath, String fileName)
        {
            var dir = Directory.Exists(absolutePath);
            if (!dir)
            {
                Directory.CreateDirectory(absolutePath);
            }

            return absolutePath;

        }
    }
}
