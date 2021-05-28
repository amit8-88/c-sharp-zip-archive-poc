using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ZipFramework
{
    public class FileEntry
    {

        #region private members
        private LocalFileHeader lfh;
        private CentralDirectoryFileHeader cdfh;
        
        private FileData fileBytes;
        private ZIPFile parent;
        private FileInfo filePath;
        private string password;
        private DataDescriptor dDesc;
        #endregion

        #region protected internal members
        protected internal uint compressedSize;
        protected internal uint crc32;
        protected internal uint unCompressedSize;
        protected internal string extraField;
        protected internal string fileName;
        protected internal GPBitFlag gpBitFlag;
        protected internal DOSDateTime lastMod;
        protected internal Method method;
        #endregion


        public FileEntry(string Filename,Method CompressionMethod)
        {
            filePath = new FileInfo(Filename);
            initialise(CompressionMethod);
        }

        public FileEntry(string FileName, string Password, Method CompressionMethod)
        {
            filePath = new FileInfo(FileName);
            password = Password;
            initialise(CompressionMethod);
            this.Header.GeneralPurposeBitFlag.AddFlag(GPBitFlag.GPBitFlags.Encrypted | GPBitFlag.GPBitFlags.DataDescriptor);
        }

        private void initialise(Method CompMethod)
        {
            this.method = CompMethod;
            lfh = new LocalFileHeader(filePath,this);
            cdfh = new CentralDirectoryFileHeader(this);
            dDesc = new DataDescriptor(this);
            
            fileBytes = new FileData(this);
        }

        /// <summary>
        /// Every file in a zip file has a local file header written before the data
        /// </summary>
        public LocalFileHeader Header
        {
            get
            {
                return lfh;
            }
        }

        /// <summary>
        /// The files entry in the central directory
        /// </summary>
        public CentralDirectoryFileHeader CDHeader
        {
            get
            {
                return cdfh;
            }
            
        }

        /// <summary>
        /// The actual Data to go into the ZIPFILE
        /// </summary>
        public FileData FileBytes
        {
            get
            {
                return fileBytes;
            }
        }

        /// <summary>
        /// The ZIP file that this file entry belongs to
        /// </summary>
        public ZIPFile Parent
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
        /// The path to the file that this object represents
        /// </summary>
        public FileInfo FilePath
        {
            get
            {
                return filePath;
            }
            
        }

        /// <summary>
        /// The password used to encrypt the file in the ZIP file
        /// </summary>
        public string Password
        {
            protected internal get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public DataDescriptor DataDescriptor
        {
            get
            {
                return dDesc;
            }

        }
    }
}
