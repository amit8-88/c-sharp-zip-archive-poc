using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public abstract class HeaderBase : ZIPObject
    {
        

        /// <summary>
        /// The signature of the header record
        /// this is unique and constant for the different headers
        /// </summary>
        public abstract uint Signature
        {
            get;
        }

        
        
    }
}
