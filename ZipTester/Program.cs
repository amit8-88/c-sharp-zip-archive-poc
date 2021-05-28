using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZipFramework;

namespace ZipTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ZIPFile zip = new ZIPFile("D:\\myfirstZip.zip");

            FileEntry file = new FileEntry("D:\\text.txt",Method.Deflated);
            
            

            zip.AddFile(file);
            
           
            zip.CreateZIP();
        }
    }
}
