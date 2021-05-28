using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ZipFramework
{
    public class LocalFileHeader : FileHeaderBase
    {
        #region private fields
        private const UInt32 LOCAL_FILE_HEADER = 0x04034b50;
        #endregion
        /// <summary>
        /// This is a constant property i.e. read only
        /// </summary>
        public override UInt32 Signature
        {
            get
            {
                return LOCAL_FILE_HEADER;
            }
        }

        public LocalFileHeader(FileInfo file,FileEntry Parent):base(Parent)
        {
            
            this.ExtraField = "";
            this.FileName = file.Name;
            
            this.LastModDataTime = new DOSDateTime(file.LastWriteTime);
            this.UnCompressedSize = (uint)file.Length;
        }

        protected internal override byte[] GetOutput()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(this.Signature));
            bytes.AddRange(BitConverter.GetBytes(this.VersionNeededToExtract));
            bytes.AddRange(this.GeneralPurposeBitFlag.GetOutput());
            bytes.AddRange(BitConverter.GetBytes((ushort)this.Method));
            bytes.AddRange(this.LastModDataTime.GetOutput());
            bytes.AddRange(BitConverter.GetBytes(this.CRC32));
            bytes.AddRange(BitConverter.GetBytes(this.CompressedSize));
            bytes.AddRange(BitConverter.GetBytes(this.UnCompressedSize));
            bytes.AddRange(BitConverter.GetBytes(this.FileNameLength));
            bytes.AddRange(BitConverter.GetBytes(this.ExtraFieldLength));

            System.Text.ASCIIEncoding ascii = (System.Text.ASCIIEncoding)System.Text.Encoding.ASCII;
            bytes.AddRange(ascii.GetBytes(this.FileName));
            bytes.AddRange(ascii.GetBytes(this.ExtraField));

            return bytes.ToArray();
        }
    }
}
