using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public abstract class FileHeaderBase : DataHeaderBase
    {
        private const UInt16 PKUNZIP2_0 = 20;
        
                     


        public FileHeaderBase(FileEntry Parent):base(Parent)
        {
            this.GeneralPurposeBitFlag = new GPBitFlag();
        }

        /// <summary>
        /// The version of the program needed to extract the zip file
        /// </summary>
        public UInt16 VersionNeededToExtract
        {
            get
            {
                return PKUNZIP2_0;
            }
        }

        /// <summary>
        /// The general purpose bit flag that describes various properties of a zipped file
        /// </summary>
        public GPBitFlag GeneralPurposeBitFlag
        {
            get
            {
                return this.Parent.gpBitFlag;
            }
            protected internal set
            {
                this.Parent.gpBitFlag = value;
            }
        }

        /// <summary>
        /// The compression method
        /// </summary>
        public Method Method
        {
            get
            {
                return this.Parent.method;
            }
            set
            {
                this.Parent.method = value;
            }
        }

        /// <summary>
        /// The date and time the file was last modified in dos format
        /// </summary>
        public DOSDateTime LastModDataTime
        {
            get
            {
                return this.Parent.lastMod;
            }
            set
            {
                this.Parent.lastMod = value;
            }
        }

        /// <summary>
        /// The name of the file
        /// </summary>
        public string FileName
        {
            get
            {
                return this.Parent.fileName;
            }
            set
            {
                this.Parent.fileName = value;
            }
        }

        /// <summary>
        /// The extra data about the file
        /// </summary>
        public string ExtraField
        {
            get
            {
                return this.Parent.extraField;
            }
            set
            {
                this.Parent.extraField = value;
            }
        }

        /// <summary>
        /// The length of the file name
        /// </summary>
        public UInt16 FileNameLength
        {
            get
            {
                return (UInt16)(this.Parent.fileName.Length);
            }
            
        }

        /// <summary>
        /// The length of the extra data
        /// </summary>
        public ushort ExtraFieldLength
        {
            get
            {
                return (UInt16)(this.ExtraField.Length);
            }
        }
    }
}
