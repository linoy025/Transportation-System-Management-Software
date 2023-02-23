
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]

    /// <summary>
    ///  int חריגות עבור ישויות בעלות מזהה אחד מסוג  
    /// </summary>
    public class BadIdException : Exception
    {
        public int ID;      
        public BadIdException(int id) : base() => ID = id;
        public BadIdException(int id, string message) :
            base(message) => ID = id;
        public BadIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad  id: {ID}";

    }

    /// <summary>
    ///  string חריגות עבור ישויות בעלות מזהה אחד מסוג  
    /// </summary>
    public class BadStringIdException : Exception
    {
        public string SID;
        public BadStringIdException(string id) : base() => SID = id;
        public BadStringIdException(string id, string message) :
            base(message) => SID = id;
        public BadStringIdException(string id, string message, Exception innerException) :
            base(message, innerException) => SID = id;

        public override string ToString() => base.ToString() + $", bad  id: {SID}";
    }



    /// <summary>
    ///  int חריגות עבור ישויות בעלות שני מזהים מסוג  
    /// </summary>
    public class BadFirstIDSecondIDException : Exception
        {
        public int FirstID;
        public int SecondID;
        public BadFirstIDSecondIDException(int firID, int secID) : base() { FirstID = firID; SecondID = secID; }
        public BadFirstIDSecondIDException(int firID, int secID, string message) :
            base(message)
        { FirstID = firID; SecondID = secID; }
        public BadFirstIDSecondIDException(int firID, int secID, string message, Exception innerException) :
            base(message, innerException)
        { FirstID = firID; SecondID = secID; }

        public override string ToString() => base.ToString() + $", bad first id: {FirstID} and second id: {SecondID}";
        }


    /// <summary>
    /// /  int ומזהה TimeSpan חריגות עבור ישויות בעלות מזהה 
    /// עבור יציאת קו
    /// </summary>
    public class BadFirstIDSecondTimeIDException : Exception
    {
        public int FirstID;
        public TimeSpan SecondID;
        public BadFirstIDSecondTimeIDException(int firID, TimeSpan secID) : base() { FirstID = firID; SecondID = secID; }
        public BadFirstIDSecondTimeIDException(int firID, TimeSpan secID, string message) :
            base(message)
        { FirstID = firID; SecondID = secID; }
        public BadFirstIDSecondTimeIDException(int firID, TimeSpan secID, string message, Exception innerException) :
            base(message, innerException)
        { FirstID = firID; SecondID = secID; }

        public override string ToString() => base.ToString() + $", bad first id: {FirstID} and second id: {SecondID}";
    }




    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }

}