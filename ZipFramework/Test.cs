using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public class Test
    {
        public static void main(string[] args)
        {
            ZIPFile zip = new ZIPFile("D:\\myfirstZip.zip");

            FileEntry file = new FileEntry("D:\\text.txt",Method.Stored);

            zip.AddFile(file);
            zip.CreateZIP();
        }
    }
}
