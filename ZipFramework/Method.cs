using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public enum Method : ushort
    {
        /// <summary>
        /// The file is stored uncompressed
        /// </summary>
        Stored = 0,
        /// <summary>
        /// The file is shrunk
        /// </summary>
        Shrunk = 1,
        /// <summary>
        /// The file is Reduced with compression factor 1
        /// </summary>
        ReducedCompFactor1 = 2,
        /// <summary>
        /// The file is Reduced with compression factor 2
        /// </summary>
        ReducedCompFactor2 = 3,
        /// <summary>
        /// The file is Reduced with compression factor 3
        /// </summary>
        ReducedCompFactor3 = 4,
        /// <summary>
        /// The file is Reduced with compression factor 4
        /// </summary>
        ReducedCompFactor4 = 5,
        /// <summary>
        /// The file is imploded
        /// </summary>
        Imploded = 6,
        /// <summary>
        /// File is tokenized
        /// </summary>
        Tokenized = 7,
        /// <summary>
        /// The file is stored deflated
        /// </summary>
        Deflated = 8,
        /// <summary>
        /// The file is stored enhanced deflated
        /// </summary>
        Deflate64 = 9,
        /// <summary>
        /// The file is stored via old imploding
        /// </summary>
        OldImploding = 10,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved1 = 11,
        /// <summary>
        /// BZIP2
        /// </summary>
        BZIP2 = 12,
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved2 = 13,
        /// <summary>
        /// LZMA
        /// </summary>
        LZMA = 14,
    }
}
