using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public abstract class DataHeaderBase : HeaderBase
    {

        private FileEntry parent;

        public DataHeaderBase(FileEntry Parent)
        {
            parent = Parent;
        }

        public FileEntry Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Gets or Sets the compressed size of the file
        /// </summary>
        public uint CompressedSize
        {
            get
            {
                return this.Parent.compressedSize;
            }
            protected internal set
            {
                this.Parent.compressedSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the uncompressed size of the file
        /// </summary>
        public uint UnCompressedSize
        {
            get
            {
                return this.Parent.unCompressedSize;
            }
            protected internal set
            {
                this.Parent.unCompressedSize = value;
            }
        }

        /// <summary>
        /// Gets or Sets the CRC32 value of the file
        /// </summary>
        public uint CRC32
        {
            get
            {
                return this.Parent.crc32;
            }
            protected internal set
            {
                this.Parent.crc32 = value;
            }
        }
    }
}
