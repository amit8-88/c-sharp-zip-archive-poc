using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ZipFramework
{
    public abstract class ZIPObject
    {
        /// <summary>
        /// Returns a Byte array containing the bytes representing the object
        /// from a given offset for a given length
        /// </summary>
        /// <param name="offset">Number of bytes to skip</param>
        /// <param name="length">Maximum number of bytes to return</param>
        /// <returns>Byte array containing the bytes representing a portion of this object</returns>
        protected internal byte[] GetOutput(int offset, int length)
        {

            byte[] bytes = this.GetOutput();
            byte[] bytesRet = new byte[bytes.Length];

            Array.Copy(bytes, offset, bytesRet, 0, length > bytes.Length ? bytes.Length : length);

            return bytesRet;
        }

        /// <summary>
        /// Returns a Byte array representing all of this object
        /// </summary>
        /// <returns>A byte array</returns>
        protected abstract internal Byte[] GetOutput();
        

        

        /// <summary>
        /// Puts bytes representing part of the object into a given
        /// stream
        /// </summary>
        /// <returns>boolean representing success</returns>
        protected internal bool InsertOutput(System.IO.Stream output, int offset, int length)
        {
            try
            {
                byte[] bytes = this.GetOutput(offset, length);
                output.Write(bytes, 0, bytes.Length);
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Puts bytes representing the object into a given file stream
        /// </summary>
        /// <returns>boolean representing success</returns>
        protected internal bool InsertOutput(System.IO.Stream output)
        {
            try
            {
                byte[] bytes = this.GetOutput();
                output.Write(bytes, 0, bytes.Length);
            }
            catch (Exception E)
            {
                return false;
            }

            return true;
        }
        
    }
}
