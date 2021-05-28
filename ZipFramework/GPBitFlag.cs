using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public class GPBitFlag : ZIPObject
    {
        private GPBitFlags gpBitFlag;

        [Flags]
        public enum GPBitFlags : ushort
        {
            Empty = 0,
            Encrypted = 1,
            PrivateComp1 = 2,
            PrivateComp2 = 4,
            DataDescriptor = 8,
            EnhancedDeflating = 16,
            CompressedPatch = 32,
            StrongEncryption = 64,
            Unused1 = 128,
            Unused2 = 256,
            Unused3 = 512,
            Unused4 = 1024,
            UTF8Encoding = 2048,
            ReservedEnhancedCompression = 4096,
            EncryptedCentralDirectory = 8192,
            ReservedPK1 = 16384,
            ReservedPK2 = 32768
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Flag"></param>
        public void AddFlag(GPBitFlags Flag)
        {
            gpBitFlag = gpBitFlag | Flag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Flag"></param>
        public void RemoveFlag(GPBitFlags Flag)
        {
            gpBitFlag = gpBitFlag & ~Flag;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GPBitFlag()
        {
            gpBitFlag = 0;
        }


        /// <summary>
        /// Returns a Byte array representing all of this object
        /// </summary>
        /// <returns>A byte array</returns>
        protected internal override byte[] GetOutput()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes((ushort)gpBitFlag));

            return bytes.ToArray();
        }
    }
}
