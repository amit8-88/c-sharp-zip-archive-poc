using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public class DataDescriptor : DataHeaderBase
    {
        private const UInt32 DATA_DESC_HEADER = 0x08074b50;

        /// <summary>
        /// Default constructor does nothing
        /// </summary>
        public DataDescriptor(FileEntry Parent):base(Parent)
        {

        }
        
        /// <summary>
        /// The signature of the Data descriptor
        /// </summary>
        public override UInt32 Signature
        {
            get
            {
                return DATA_DESC_HEADER;
            }
        }

        /// <summary>
        /// Returns a Byte array representing all of this object
        /// </summary>
        /// <returns>A byte array</returns>
        protected internal override byte[] GetOutput()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(this.Signature));
            bytes.AddRange(BitConverter.GetBytes(this.CRC32));
            bytes.AddRange(BitConverter.GetBytes(this.CompressedSize));
            bytes.AddRange(BitConverter.GetBytes(this.UnCompressedSize));

            return bytes.ToArray();

        }

    }
}
