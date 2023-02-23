using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BLApi
{
    /// <summary>
    /// מטרתה לאפשר לשכבה עליונה ליצר אובייקטים משכבה תחתונה שממשים ממשק מוסכם, מבלי להכיר את המחלקה המממשת.
    ///השכבה התחתונה תגדיר "מפעל לייצור אובייקטים" (Factory), מחלקת ביניים, והיצור יעשה דרך מתודה של המפעל שתחזיר עצם מטיפוס הממשק.
   /// מחלקת הייצור זו תהיה סטטית לצורך חסכון בהגדרת מופעים
   /// מחלקת הייצור תהיה האחראית הבלעדית ליצירת האובייקטים שמממשים את הממשק.
   /// המתודה המייצרת תקבל פרמטר שבעזרתו היא תדע איזה טיפוס של אובייקט לייצר.
    /// </summary>
    public static class BLFactory
    {
        public static IBL GetBL()
        {            
           return new BLImp();           
        }

    }
}


