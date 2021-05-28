using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public class CentralDirectoryFileHeader : FileHeaderBase
    {
        private const UInt32 CENTRAL_DIRECTORY_HEADER = 0x02014b50;
        private const UInt16 WIN32_ZIP2_3 = 0xB17;
        private string fileComment;
        protected uint relativeOffset;

        public CentralDirectoryFileHeader(FileEntry Parent):base(Parent)
        {
            fileComment = "";
        }

        public override uint Signature
        {
            get { return CENTRAL_DIRECTORY_HEADER; }
        }

        /// <summary>
        /// The ZIP version that made the zip file
        /// </summary>
        public ushort VersionMadeBy
        {
            get
            {
                return WIN32_ZIP2_3;
            }
        }

        /// <summary>
        /// The length of the file comment
        /// </summary>
        public ushort FileCommentLength
        {
            get
            {
                return (ushort)(fileComment.Length);
            }
            
        }

        /// <summary>
        /// The disk on which this file starts
        /// </summary>
        public ushort DiskNumberStart
        {
            get
            {
                //Currently only support writing to one big ZIP file
                return 0;
            }
        }

        /// <summary>
        /// The interal attributes of the file
        /// </summary>
        public ushort InternalFileAttributes
        {
            get
            {
                //Hard coded and dirty but will hopefully work
                return 0;
            }
        }

        /// <summary>
        /// The external atributes of the file
        /// </summary>
        public UInt32 ExternalFileAttributes
        {
            get
            {
                //Hard coded and dirty but will hopefully work
                return 0;
            }
            
        }

        /// <summary>
        /// The offset from the start of the zip file of the local header for this file
        /// </summary>
        public uint RelativeOffsetOfLocalHeader
        {
            get
            {
                return relativeOffset;
            }
            protected internal set
            {
                relativeOffset = value;
            }
        }

        /// <summary>
        /// A comment about the file
        /// </summary>
        public string FileComment
        {
            get
            {
                return fileComment;
            }
            set
            {
                fileComment = value;
            }
        }

        protected internal override byte[] GetOutput()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(this.Signature));
            bytes.AddRange(BitConverter.GetBytes(this.VersionMadeBy));
            bytes.AddRange(BitConverter.GetBytes(this.VersionNeededToExtract));
            bytes.AddRange(this.GeneralPurposeBitFlag.GetOutput());
            bytes.AddRange(BitConverter.GetBytes((ushort)this.Method));
            bytes.AddRange(this.LastModDataTime.GetOutput());
            bytes.AddRange(BitConverter.GetBytes(this.CRC32));
            bytes.AddRange(BitConverter.GetBytes(this.CompressedSize));
            bytes.AddRange(BitConverter.GetBytes(this.UnCompressedSize));
            bytes.AddRange(BitConverter.GetBytes(this.FileNameLength));
            bytes.AddRange(BitConverter.GetBytes(this.ExtraFieldLength));
            bytes.AddRange(BitConverter.GetBytes(this.FileCommentLength));
            bytes.AddRange(BitConverter.GetBytes(this.DiskNumberStart));
            bytes.AddRange(BitConverter.GetBytes(this.InternalFileAttributes));
            bytes.AddRange(BitConverter.GetBytes(this.ExternalFileAttributes));
            bytes.AddRange(BitConverter.GetBytes(this.RelativeOffsetOfLocalHeader));

            System.Text.ASCIIEncoding ascii = (System.Text.ASCIIEncoding)System.Text.Encoding.ASCII;
            bytes.AddRange(ascii.GetBytes(this.FileName));
            bytes.AddRange(ascii.GetBytes(this.ExtraField));
            bytes.AddRange(ascii.GetBytes(this.FileComment));

            return bytes.ToArray();
        }
    }
          
}
