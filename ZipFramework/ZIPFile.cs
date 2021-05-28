using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ZipFramework
{
    public class ZIPFile : ZIPObject
    {
        private List<FileEntry> files;
        private EndOfCentralDirectoryHeader eocdh;

        private FileInfo filePath;

        public ZIPFile(string ZipFileName)
        {
            filePath =  new FileInfo(ZipFileName);
            files = new List<FileEntry>();
            eocdh = new EndOfCentralDirectoryHeader();
        }

        /// <summary>
        /// The path to the zip file to be created
        /// </summary>
        public FileInfo FilePath
        {
            get
            {
                return filePath;
            }
        }

        public EndOfCentralDirectoryHeader EndOfCentralDirectoryHeader
        {
            get
            {
                return eocdh;
            }
            
        }

        public void AddFile(FileEntry file)
        {
            file.Parent = this;
            files.Add(file);
        }

        public void CreateZIP()
        {
            FileStream outStream = filePath.OpenWrite();

            byte[] buff;

            foreach (FileEntry f in files)
            {
                //before anything is written for this file get the position in the stream
                f.CDHeader.RelativeOffsetOfLocalHeader = (uint)outStream.Position;
                buff = f.Header.GetOutput();
                outStream.Write(buff,0,buff.Length);

                buff = f.FileBytes.GetOutput();
                outStream.Write(buff, 0, buff.Length);

                buff = f.DataDescriptor.GetOutput();
                outStream.Write(buff, 0, buff.Length);
            }

            //need to get hold of the start of the central directory position before it is written
            this.EndOfCentralDirectoryHeader.OffsetToCentralDir = (uint)outStream.Position;

            foreach (FileEntry f in files)
            {
                buff = f.CDHeader.GetOutput();
                this.EndOfCentralDirectoryHeader.TotalNumberOfEntriesInCentralDir += 1;
                this.EndOfCentralDirectoryHeader.SizeOfCentralDirectory += (uint)buff.Length;
                outStream.Write(buff,0,buff.Length);
            }


            buff = this.EndOfCentralDirectoryHeader.GetOutput();

            outStream.Write(buff, 0, buff.Length);
            

            outStream.Close();
        }
    
        protected internal override byte[] GetOutput()
        {
            throw new NotImplementedException();
        }
    }
}
