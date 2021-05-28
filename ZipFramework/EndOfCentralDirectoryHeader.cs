using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public class EndOfCentralDirectoryHeader : HeaderBase
    {
        private const UInt32 END_OF_CENTRAL_DIRECTORY_HEADER = 0x06054b50;
        private ushort numberOfEntries;
        private uint sizeOfCentralDir;
        private uint offsetToCentralDir;
        private string zipComment = "";

        

        public override uint Signature
        {
            get { return END_OF_CENTRAL_DIRECTORY_HEADER; }
        }

        public ushort DiskNumber
        {
            get
            {
                return 0;
            }
        }

        public ushort CentralDirStartDisk
        {
            get
            {
                return 0;
            }
        }

        public ushort NumberEntriesOnThisDisk
        {
            get
            {
                return numberOfEntries;
            }
        }

        public ushort TotalNumberOfEntriesInCentralDir
        {
            get
            {
                return numberOfEntries;
            }
            set
            {
                numberOfEntries = value;
            }
        }

        public uint SizeOfCentralDirectory
        {
            get
            {
                return sizeOfCentralDir;
            }
            set
            {
                sizeOfCentralDir = value;
            }
        }

        public uint OffsetToCentralDir
        {
            get
            {
                return offsetToCentralDir;
            }
            set
            {
                offsetToCentralDir = value;
            }
        }

        public ushort ZipFileCommentLength
        {
            get
            {
                return (ushort)ZipFileComment.Length;
            }
        }

        public string ZipFileComment
        {
            get
            {
                return zipComment;
            }
            set
            {
                zipComment = value;
            }
        }

        protected internal override byte[] GetOutput()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(this.Signature));
            bytes.AddRange(BitConverter.GetBytes(this.DiskNumber));
            bytes.AddRange(BitConverter.GetBytes(this.CentralDirStartDisk));
            bytes.AddRange(BitConverter.GetBytes(this.NumberEntriesOnThisDisk));
            bytes.AddRange(BitConverter.GetBytes(this.TotalNumberOfEntriesInCentralDir));
            bytes.AddRange(BitConverter.GetBytes(this.SizeOfCentralDirectory));
            bytes.AddRange(BitConverter.GetBytes(this.OffsetToCentralDir));
            bytes.AddRange(BitConverter.GetBytes(this.ZipFileCommentLength));

            System.Text.ASCIIEncoding ascii = (System.Text.ASCIIEncoding)System.Text.Encoding.ASCII;
            bytes.AddRange(ascii.GetBytes(this.ZipFileComment));

            return bytes.ToArray();
        }
    }
}
