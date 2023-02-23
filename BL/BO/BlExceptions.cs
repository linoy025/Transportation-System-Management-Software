//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BO
//{
//    public class BlExceptions
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DO;

namespace BO
{
    /// <summary>
    /// חריגות עבור ישות אוטובוס
    /// </summary>
    [Serializable]
    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad bus id: {ID}";
    }

    /// <summary>
    /// חריגות עבור ישות קו
    /// </summary>
    [Serializable]
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }

    /// <summary>
    /// חריגות עבור ישות תחנה 
    /// </summary>
    [Serializable]
    public class BadStationIdException : Exception
    {
        public int ID;
        public BadStationIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad station id: {ID}";
    }


    /// <summary>
    /// חריגות עבור ישות משתמש 
    /// </summary>
    [Serializable]
    public class BadUserIdException : Exception
    {
        public string SID;
        public BadUserIdException(string message, Exception innerException) :
            base(message, innerException) => SID = ((DO.BadStringIdException)innerException).SID;
        public override string ToString() => base.ToString() + $", bad user id: {SID}";
    }




    /// <summary>
    /// חריגות עבור ישות תחנת קו 
    /// </summary>
    [Serializable]
    public class BadLineIdStationIDException : Exception
    {
        public int FirstID;
        public int SecondID;
        public BadLineIdStationIDException(string message, Exception innerException) :
            base(message, innerException)
        {
            SecondID = ((DO.BadFirstIDSecondIDException)innerException).FirstID;
            SecondID = ((DO.BadFirstIDSecondIDException)innerException).SecondID;
        }
        public override string ToString() => base.ToString() + $", bad line id: {FirstID} and station ID: {SecondID}";
    }

    /// <summary>
    /// חריגות עבור ישות תחנת עוקבות 
    /// </summary>
    [Serializable]
    public class BadFirstStationIdSecondStationIDException : Exception
    {
        public int FirstID;
        public int SecondID;
        public BadFirstStationIdSecondStationIDException(string message, Exception innerException) :
            base(message, innerException)
        {
            FirstID = ((DO.BadFirstIDSecondIDException)innerException).FirstID;
            SecondID = ((DO.BadFirstIDSecondIDException)innerException).SecondID;
        }
        public override string ToString() => base.ToString() + $", bad first station id: {FirstID} and second station ID: {SecondID}";
    }


    /// <summary>
    /// חריגות עבור ישות יציאת קו 
    /// </summary>
    [Serializable]
    public class BadLineIdStartingTimeIDException : Exception
    {
        public int FirstID;
        public TimeSpan SecondID;
        public BadLineIdStartingTimeIDException(string message, Exception innerException) :
            base(message, innerException)
        {
            FirstID = ((DO.BadFirstIDSecondTimeIDException)innerException).FirstID;
            SecondID = ((DO.BadFirstIDSecondTimeIDException)innerException).SecondID;
        }
        public override string ToString() => base.ToString() + $", bad line id: {FirstID} and starting time ID: {SecondID}";
    }

}