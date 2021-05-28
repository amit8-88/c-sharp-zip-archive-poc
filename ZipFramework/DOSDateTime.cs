using System;
using System.Collections.Generic;
using System.Text;

namespace ZipFramework
{
    public class DOSDateTime : ZIPObject
    {

        private DateTime classicDate;
        private UInt16 dosDate;
        private UInt16 dosTime;

        /// <summary>
        /// Default nothing is initilized
        /// </summary>
        public DOSDateTime()
        {

        }

        /// <summary>
        /// From classic date time
        /// </summary>
        public DOSDateTime(DateTime classic)
        {
            this.ClassicDateTime = classic;
        }

        /// <summary>
        /// From DOS date and DOS time
        /// </summary>
        public DOSDateTime(UInt16 dosDate, UInt16 dosTime)
        {
            this.dosDate = dosDate;
            this.DOSTime = dosTime;
        }

        /// <summary>
        /// This is the datetime in classic .NET format
        /// </summary>
        public DateTime ClassicDateTime
        {
            get
            {
                return classicDate;
            }
            set
            {
                
                classicDate = value;
                updateDOSDateTime();
            }
        }


        /// <summary>
        /// This is the Date in DOS format
        /// </summary>
        public ushort DOSDate
        {
            get
            {
                return dosDate;
            }
            set
            {
                dosDate = value;
                updateClassicDateTime();
            }
        }

        /// <summary>
        /// This is the Time in DOS format
        /// </summary>
        public ushort DOSTime
        {
            get
            {
                return dosTime;
            }
            set
            {
                dosTime = value;
                updateClassicDateTime();
            }
        }

        /// <summary>
        /// Updates the classic portion of the time
        /// </summary>
        private void updateClassicDateTime()
        {
            int day = GetBits(dosDate, 0, 5);
            int month = GetBits(dosDate, 5, 4);
            int year = GetBits(dosDate, 9, 7)+1980;

            int seconds = GetBits(dosTime, 0, 5)/2;
            int minutes = GetBits(dosTime, 5, 6);
            int hour = GetBits(dosTime, 11, 5);

            classicDate = new DateTime(year, month, day, hour, minutes, seconds);

        }

        /// <summary>
        /// Gets the bits of an int from an offset for a length
        /// </summary>
        /// <param name="value">Value to get the bits from  </param>
        /// <param name="startBit">Where to start</param>
        /// <param name="bitCount">number of bits</param>
        /// <returns></returns>
        private int GetBits(UInt16 value, int startBit, int bitCount)
        {
            UInt16 result;
            result = Convert.ToUInt16((value << (startBit)));
            result = Convert.ToUInt16((result >> (15 - bitCount)));

            return (int)result;
        }

        /// <summary>
        /// Updates the DOS portion of the date and time
        /// </summary>
        private void updateDOSDateTime()
        {
            UInt16 workDate = Convert.ToUInt16((((classicDate.Year - 1980) & 0x7f) << 9));
            workDate |= Convert.ToUInt16(((classicDate.Month & 0xf) << 5));
            workDate |= Convert.ToUInt16((classicDate.Day & 0x1f));

            this.dosDate = workDate;

            UInt16 workTime = Convert.ToUInt16(((classicDate.Hour & 0x1f) << 11));
            workTime |= Convert.ToUInt16(((classicDate.Minute & 0x3f) << 5));
            workTime |= Convert.ToUInt16(((classicDate.Second * 2) & 0x1f));

            this.dosTime = workTime;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected internal override byte[] GetOutput()
        {
            List<byte> bytes = new List<byte>();
            bytes.AddRange(BitConverter.GetBytes(DOSTime));
            bytes.AddRange(BitConverter.GetBytes(DOSDate));

            return bytes.ToArray();
        }
    }
}
