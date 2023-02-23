using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using BL;
using BLApi;
using BO;

namespace BL
{
    // public class BLImp : IBL
    class BLImp : IBL
    {
        
         IDL dl = DLFactory.GetDL();

        #region AdjacentStations

        /// <summary>
        ///  הוספת יישות תחנות עוקבות 
        /// </summary>
        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
            try
            {
                DO.AdjacentStations adjacentStations1 = new DO.AdjacentStations();
                adjacentStations.CopyPropertiesTo(adjacentStations1);
                dl.AddAdjacentStations(adjacentStations1);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadFirstStationIdSecondStationIDException("First Station Id and Second Station ID already exist", ex);
            }
        }

        /// <summary>
        ///  עדכון יישות תחנות עוקבות 
        /// </summary>
        public void UpdateAdjacentStations(AdjacentStations adjacentStations)
        {
            try
            {
                DO.AdjacentStations adjacentStations1 = new DO.AdjacentStations();
                adjacentStations.CopyPropertiesTo(adjacentStations1);
                dl.UpdateAdjacentStations(adjacentStations1);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadFirstStationIdSecondStationIDException("First Station Id and Second Station ID do not exist", ex);
            }
        }


        /// <summary>
        ///  מקבלת יישות תחנות עוקבות של DO ומחזירה אובייקט של BO  
        /// </summary>
        public AdjacentStations adjacentStationDoBoAdapter(DO.AdjacentStations adjacentStationsDO)
        {
            AdjacentStations adjacentStationsBO = new AdjacentStations();           
            adjacentStationsDO.CopyPropertiesTo(adjacentStationsBO);
            return adjacentStationsBO;
        }

        /// <summary>
        /// מחזירה את  כל התחנות העוקבות 
        /// </summary>
        public IEnumerable<AdjacentStations> GetAllAdjacentStations()
        {
            try
            {
                return from adjacentStationsDO in dl.GetAllAdjacentStations()
                       select adjacentStationDoBoAdapter(adjacentStationsDO);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadFirstStationIdSecondStationIDException("Adjacent stations do not exist", ex);
            }

        }



        /// <summary>
        ///  מקבלת שתי מספרי תחנות ושולפת את היישות תחנות עוקבות המתאימה
        /// </summary>
        public AdjacentStations GetAdjacentStations(int id1, int id2)
        {
            // תקינות קלט
            try
            {
                DO.AdjacentStations adjacentStations1 = new DO.AdjacentStations();
                adjacentStations1 = dl.GetAdjacentStations(id1, id2);
                AdjacentStations adjacentStations = new AdjacentStations();
                adjacentStations1.CopyPropertiesTo(adjacentStations);
                return adjacentStations;
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadFirstStationIdSecondStationIDException("First Station Id and / or Second Station ID do not exist", ex);
            }
        }

        //public void UpdateAdjacentStations(int id1, int id2, Action<AdjacentStations> update);
        //IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        #endregion
      
        #region Bus
        /// <summary>
        ///    מקבלת אוטובוס במטרה להוסיף אותו לרשימת האוטובוסים  
        /// </summary>
        public void AddBus(Bus bus)
        {
            // תקינות קלט
            try
            {
                DO.Bus bus1 = new DO.Bus();
                bus.CopyPropertiesTo(bus1);
                dl.AddBus(bus1);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadBusIdException("Bus ID is illegal", ex);
            }
        }

        /// <summary>
        ///    מקבלת אוטובוס במטרה לעדכן אותו ברשימת האוטובוסים   
        /// </summary>
        public void UpdateBus(Bus bus)
        {
            try
            {
                DO.Bus bus1 = new DO.Bus();
                bus.CopyPropertiesTo(bus1);
                dl.UpdateBus(bus1);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadBusIdException("Bus ID is illegal", ex);
            }
        }

        /// <summary>
        /// מקבלת אוטובוס במטרה למחק אותו מרשימת האוטובוסים 
        /// </summary>
        public void DeleteBus(int id)
        {
            try
            {
                dl.DeleteBus(id);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadBusIdException("Bus id does not exist", ex);
            }

        }

        /// <summary>
        ///  מקבלת מספר רישוי של אוטובוס במטרה לשלוף אותו מרשימת האוטובוסים   
        /// </summary>
        public Bus GetBus(int id)
        {
            Bus bus1 = new Bus();
            // תקינות קלט
            try
            {
                DO.Bus bus = new DO.Bus();
                bus = dl.GetBus(id);          
                bus.CopyPropertiesTo(bus1);

            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadBusIdException("bus id  does not exist", ex);
            }
            return bus1;
        }


        /// <summary>
        ///  שולפת את כל האוטובוסים  מרשימת האוטובוסים   
        /// </summary>
        public IEnumerable<Bus> GetAllBuses()
        {
            try
            {
                return from busDO in dl.GetAllBuses()
                       select busDoBoAdapter(busDO);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadBusIdException("buses do not exist", ex);
            }

        }

        /// <summary>
        /// מקבלת אוטובוס של DO ומחזירה אובייקט של BO
        /// </summary>
        public Bus busDoBoAdapter(DO.Bus busDO)
        {
            Bus busBO = new Bus();
            busDO.CopyPropertiesTo(busBO);
            return busBO;
        }



        // IEnumerable<Bus> GetAllBusesBy(Predicate<Bus> predicate);
        //void UpdateBus(int id, Action<Bus> update); 
        #endregion Bus

        #region LeavingLine
        /// <summary>
        ///    מקבלת יציאת קו  במטרה להוסיף אותו לרשימת לוח הזמנים  
        /// </summary>
        public void AddLeavingLine(LeavingLine leavingLine)
        {
            // תקינות קלט
            try
            {
                DO.LeavingLine leavingLine1 = new DO.LeavingLine();
                leavingLine.CopyPropertiesTo(leavingLine1);
                dl.AddLeavingLine(leavingLine1);
            }
            catch (DO.BadFirstIDSecondTimeIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Line already exists", ex);
            }
        }
      
        

        /// <summary>
        ///    מקבלת יציאת קו  במטרה למחק  אותו מרשימת לוח הזמנים  
        /// </summary>
        public void DeleteLeavingLine(int id, TimeSpan startingtime)
        {
            try
            {
                dl.DeleteLeavingLine(id , startingtime);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Line does not exists", ex);
            }
        }
        /// <summary>
        ///    מקבלת מזהים של יציאת קו  במטרה לשלוף   אותה מרשימת לוח הזמנים  
        /// </summary>
        public LeavingLine GetLeavingLine(int id, TimeSpan startingtime)
        {
            // תקינות קלט
            try
            {
                DO.LeavingLine leavingLine1 = new DO.LeavingLine();
                leavingLine1 = dl.GetLeavingLine(id, startingtime);
                LeavingLine leavingLine = new LeavingLine();
                leavingLine1.CopyPropertiesTo(leavingLine);
                return leavingLine;

            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Line does not exists", ex);
            }
        }

        /// <summary>
        ///  מקבלת יציאת קו של DO ומחזירה מופע של BO
        /// </summary>
        public LeavingLine leavingLineDoBoAdapter(DO.LeavingLine leavingLineDO)
        {
            LeavingLine leavingLineBO = new LeavingLine();
            leavingLineDO.CopyPropertiesTo(leavingLineBO);
            return leavingLineBO;
        }



        /// <summary>
        ///   שולפת את כל יציאות הקו מרשימת לוח הזמנים על ידי קריאה לפונקציה בDAL   
        /// </summary>
        public IEnumerable<LeavingLine> GetAllLeavingLines()
        {
            try
            {
                return from leavingLineDO in dl.GetAllLeavingLines()
                       select leavingLineDoBoAdapter(leavingLineDO);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }

        }

        /// <summary>
        ///    על ידי קריאה לפונקציה בDAL שולפת את כל יציאות הקו של קו ספציפי  מרשימת לוח הזמנים  
        /// </summary>
        public IEnumerable<BO.LeavingLine> GetAllLeavingLinesInSpecificLine(int id)
        {
            try
            {
                return from leavingLineDO in dl.GetAllLeavingLines()
                       where leavingLineDO.LineId == id
                       select leavingLineDoBoAdapter(leavingLineDO);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }

        }

        /// <summary>
        ///   מציגה עבור כל תחנה פיזית את הקווים שמתקרבים אל התחנה כלומר הקווים שכבר יצאו אך עוד לא הגיעו אל התחנה  
        /// </summary>
        public IEnumerable<BO.LineTrip> DigitalPanel(int NumberStation, TimeSpan timeSpan)
        {
            try
            {
                // מקבלת את רשימת הקווים שעוברים בתחנה ספציפית
                List<Line> lines = GetAllLinesInSpecificStation(NumberStation).ToList();
                List<BO.LineTrip> lineTrips = new List<LineTrip>();

                // עבור כל הקווים שעוברים בתחנה
                for (int i = 0; i < lines.Count; i++)
                {
                    // שליחה לפונקציה שתחשב את זמן ההגעה של הקו אל התחנה המבוקשת
                    List<BO.HelpLineTrip> helpLineTrips = HelpCalculateArrivingTimeToStation(lines[i].LineId, NumberStation, timeSpan).ToList();
                    string f = dl.GetStation(lines[i].LastStationId).StationName;

                    // סכימת כל הזמנים משעת יציאת הקו ועד הגעתו אל התחנה המבוקשת ואז נוצרת נסיעת קו
                    for (int j = 0; j < helpLineTrips.Count; j++)
                    {
                        lineTrips.Add(new LineTrip { LineNumber = lines[i].LineNumber, NameOfLastStation = f, ArrivingTime = helpLineTrips[j].CalculateArrivingTimeToStation, LeavingTime = helpLineTrips[j].LeavingTime });
                    }
                }
                return lineTrips;
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }
            catch (DO.BadFirstIDSecondTimeIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }
        }
        /// <summary>
        ///  מחשבת את זמן הגעת קו ספציפי אל תחנה מבוקשת
        /// </summary>
        public IEnumerable<BO.HelpLineTrip> HelpCalculateArrivingTimeToStation(int id, int NumberStation, TimeSpan CurrentTime)
        {
            try
            {
                //  מקבלת את כל יציאות הקו עבור קו ספציפי 
                List<DO.LeavingLine> leavingLines = dl.GetAllLeavingLinesInSpecificLine(id).ToList();

                // מקבלת את כל תחנות הקו של קו ספציפי ממוינות על פי מיקומן בקו
                List<DO.StationInLine> stationInLines = dl.GetAllLineStationsInSpecificLine(id).OrderBy(i => i.StationInLineLocation).ToList();
                List<StationLine> stationInLines1 = new List<StationLine>();

                // מעבר על כל תחנות הקו של הקו הספציפי והשמתן ברשימה
                for (int i = 0; i < stationInLines.Count; i++)
                {
                    StationLine stationLine = new StationLine();
                    stationInLines[i].CopyPropertiesTo(stationLine);
                    stationInLines1.Add(stationLine);
                }

                for (int i = 0; i < stationInLines1.Count - 1; i++)
                {
                    // קריאה לפונקציה שמחזירה את כל הזמנים של התחנות העוקבות של קו ספציפי 
                    //שהרי חישוב הזמנים מתבצע לפי המידע שמופיע בתחנות עוקבות
                    stationInLines1[i].AverageTravelTime = dl.GetAdjacentStations(stationInLines1[i].StationId, stationInLines1[i + 1].StationId).AverageTravelTime;
                }

                double temp = 0;
                // מעבר על זמני הנסיעה בין התחנות החל מהתחנה הראשונה עד התחנה המבוקשת וסכימתם לזמן כולל 
                for (int i = 0; i < stationInLines1.FindIndex(temp => temp.StationId == NumberStation); i++)
                {
                    temp += stationInLines1[i].AverageTravelTime;
                }

                // הזמן הכולל שלוקח לקו להגיע מרגע יציאתו ועד הגעתו לתחנה המבוקשת בתצוגה של שעות ודקות
                TimeSpan TimeFromLeavingToArriving = new TimeSpan(0, (int)temp, 0);

                // בחירת נסיעות הקו שכבר יצאו אך טרם הגיעו אל התחנה המבוקשת
                var p = from l in leavingLines
                        // אם זמן היציאה פלוס הזמן שלוקח לקו להגיע לתחנה גדול מהזמן הנוכחי וגם הזמן הנוכחי גדול מזמן יציאת הקו
                        where l.StartingTime + TimeFromLeavingToArriving > CurrentTime && CurrentTime > l.StartingTime
                        // בחירת נסיעות הקו הרלוונטיות לתצוגה בפאנל הדיגיטלי
                        select new { timeCaming = l.StartingTime + TimeFromLeavingToArriving - CurrentTime, TimeLeving = l.StartingTime };
                // יצירת רשימה עם מידע מצומצם( זמן הגעה לתחנה וזמן יציאה) להצגה בפאנל - שימוש ביישות מעטפת 
                List<BO.HelpLineTrip> helpLineTrips = new List<HelpLineTrip>();

                // הוספת נסיעות הקו הרלוונטיות אל הרשימה 
                foreach (var item in p)
                {
                    helpLineTrips.Add(new HelpLineTrip { CalculateArrivingTimeToStation = item.timeCaming, LeavingTime = item.TimeLeving });
                }
                return helpLineTrips;
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }
            catch (DO.BadFirstIDSecondTimeIDException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
            }
        }
        //void UpdateLeavingLine(int id, Action<LeavingLine> update);
        //IEnumerable<LeavingLine> GetAllLeavingLinesBy(Predicate<LeavingLine> predicate);


        #endregion

        #region Line
        /// <summary>
        ///  מקבלת קו במטרה להכניס אותו לרשימת כל הקווים 
        /// </summary>
        public void AddLine(Line line)
        {
            try
            {
               // בדיקה שהקו מכיל לפחות שתי תחנות
                if (line.ListOfStationLine.Count >= 2)
                {
                    DO.Line line1 = new DO.Line();
                    line.CopyPropertiesTo(line1);
                    line.LineId = dl.AddLine(line1);

                    // מעבר על התחנות קו שהתקבלו מהמשתמש ואתחולן
                    for (int i = 0; i < line.ListOfStationLine.Count; i++)
                    {
                        DO.StationInLine stationLine = new DO.StationInLine();

                        // עדכון השדות
                        line.ListOfStationLine[i].LineId = line.LineId;
                        line.ListOfStationLine[i].StationInLineLocation = i;
                        line.ListOfStationLine[i].IsAvailableStationInLine = true;

                        // העברת התחנה לשכבת הDAL
                        line.ListOfStationLine[i].CopyPropertiesTo(stationLine);
                        dl.AddStationInLine(stationLine);

                    }

                    // מעבר על תחנות הקו לצורך יצירת תחנות עוקבות
                    for (int i = 0; i < line.ListOfStationLine.Count - 1; i++)
                    {
                        DO.AdjacentStations adjacentStations = new DO.AdjacentStations();
                        adjacentStations.StationId1 = line.ListOfStationLine[i].StationId;
                        adjacentStations.StationId2 = line.ListOfStationLine[i + 1].StationId;
                  
                        adjacentStations.AverageTravelTime = line.ListOfStationLine[i].AverageTravelTime;
                        adjacentStations.DistanceBetweenTwoAdjacentSations = line.ListOfStationLine[i].DistanceBetweenTwoAdjacentSations;

                        // העברת התחנה לשכבת הDAL
                        dl.AddAdjacentStations(adjacentStations);
                    }
                }

            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Line ID is illegal", ex);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadFirstStationIdSecondStationIDException("adjacent Stations already exist", ex);
            }
            
        }



        /// <summary>
        ///  מקבלת קו במטרה לעדכן  אותו ברשימת כל הקווים 
        /// </summary>
        public void UpdateLine(Line line)
        {
            try
            {

                DO.Line line1 = new DO.Line();
                line.CopyPropertiesTo(line1);
                dl.UpdateLine(line1);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Line ID is illegal", ex);
            }
        }

        /// <summary>
        ///  מקבלת קו במטרה למחק  אותו מרשימת כל הקווים 
        /// </summary>
        public void DeleteLine(int id)
        {
            try
            {
                dl.DeleteLine(id);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Line id does not exist", ex);
            }
        }

        /// <summary>
        ///  שולפת את כל מזהי הקווים על ידי קריאה לפונקציה בDAL
        /// </summary>
        public IEnumerable<int> GetAllLines()
        {
            try
            {
                IEnumerable<DO.Line> LinesList;
                LinesList = dl.GetAllLines();
                return from line in LinesList
                       select line.LineId;
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Lines do not exist", ex);
            }

        }
        /// <summary>
        ///  מקבלת מזהה קו ושולפת את כל האובייקט קו על ידי קריאה לפונקציה בDAL
        /// </summary>
        public Line GetLine(int id)
        {
            
            try
            {
                DO.Line line = new DO.Line();
                line = dl.GetLine(id);
                
                if (line.IsAvailableLine)
                {
                    Line line1 = new Line();
                    line.CopyPropertiesTo(line1);
                    // קריאה לפונקציה שמחזירה את כל תחנות הקו של קו ספציפי
                    IEnumerable<DO.StationInLine> stationInLines = dl.GetAllLineStationsInSpecificLine(id);

                    // שאילתא שנותנת את רשימת התחנות קו ממוינות לפי סדר הופעתן בקו 
                    line1.ListOfStationLine = (from line2 in stationInLines
                                               orderby line2.StationInLineLocation
                                               let p = GetStationLine(line2.LineId, line2.StationId)
                                               select p).ToList();

                    List<string> vs = new List<string>();

                    // שאילתא שנותנת את שמות התחנות שהקו עובר בהן
                    vs = (from line2 in stationInLines
                          let r = dl.GetStation(line2.StationId)
                          select r.StationName).ToList();

                    // הצמדת שם התחנה לכל תחנת קו 
                    for (int i = 0; i < line1.ListOfStationLine.Count; i++)
                    {
                        line1.ListOfStationLine[i].StationName = vs[i];
                    }

                    //   שליפת יישויות של תחנות עוקבות עבור כל תחנות הקו 
                    for (int i = 0; i < line1.ListOfStationLine.Count - 1; i++)
                    {
                        // קריאה לפונקציה שמחזירה את כל התחנות העוקבות של קו ספציפי
                        DO.AdjacentStations adjacentStations = dl.GetAdjacentStations(line1.ListOfStationLine[i].StationId, line1.ListOfStationLine[i + 1].StationId);
                        double t = Math.Round(adjacentStations.DistanceBetweenTwoAdjacentSations, MidpointRounding.AwayFromZero);
                        line1.ListOfStationLine[i].AverageTravelTime = adjacentStations.AverageTravelTime;
                        line1.ListOfStationLine[i].DistanceBetweenTwoAdjacentSations = t ;
                    }
                    return line1;
                }
                else
                {
                    return null;
                }

            }
            
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Line id  does not exist", ex);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadFirstStationIdSecondStationIDException(" ids   don't not exist", ex);
            }
        }
       
        //IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        //public void UpdateLine(int id, Action<Line> update)


        /// <summary>
        ///  שולפת את כל הקווים העוברים בתחנה ספציפית על ידי קריאה לפונקציה בDAL
        /// </summary>
        public IEnumerable<Line> GetAllLinesInSpecificStation(int stationId)
        {
            try
            {
                IEnumerable<DO.Line> lines;
                lines = dl.GetAllLinesInSpecificStation(stationId);

                // מקבלתDO  ומחזירה BO  
                Func<DO.Line, Line> func = item =>
                {
                    Line line = new Line();
                    line.LineNumber = item.LineNumber;
                    line.LineId = item.LineId;
                    line.LastStationId = item.LastStationId;
                    line.Area = (Enums.AREA)item.Area;
                    return line;
                };

                // שימוש בגרופינג - הצגת הקווים העוברים בתחנה מסויימת ממוינים על פי אזורים
                var Group = from line in lines
                            group line by line.Area into newGroup
                            orderby newGroup.Key
                            select new { g = newGroup };

                // עבור כל קבוצת קווים המשוייכים לאזור מסויים
                return from l in Group
                           // עבור כל קו בקבוצה
                       from n in l.g
                       let p = func(n)
                       // החזרת הקו עם הפרטים
                       select p;
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Lines do not pass in this station", ex);
            }

        }

        #endregion

        #region StationLine

        /// <summary>
        ///  מקבלת תחנת קו DO ומחזירה יישות של BO
        /// </summary>
        public StationLine StationLineBo(DO.StationInLine stationLine)
        {
            try
            {
                StationLine stationLine1 = new StationLine();
                stationLine1.LineId = stationLine.LineId;
                stationLine1.StationId = stationLine.StationId;
                stationLine1.IsAvailableStationInLine = stationLine.IsAvailableStationInLine;
                stationLine1.StationInLineLocation = stationLine.StationInLineLocation;
                return stationLine1;
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("Line Station does not exist ", ex);
            }

        }

        /// <summary>
        ///  מקבלת תחנה לקו במטרה להוסיף אותו לרשימת תחנות הקו 
        /// </summary>
        public void AddStationLine(StationLine stationLine)
        {
            //// תקינות קלט
            try
            {
                List<DO.StationInLine> stationInLines = new List<DO.StationInLine>();
                List<StationLine> stationInLinesB = new List<StationLine>();

                // שליפת כל התחנות קו של הקו הספציפי
                stationInLines = dl.GetAllLineStationsInSpecificLine(stationLine.LineId).ToList();

                //מחיקת כל התחנות קו של הקו הספציפי במטרה להוסיף אותן שוב עם האינדקסים מסודרים
                dl.DeleteLineStation1(stationLine.LineId);
                
                // עבור כל תחנת קו שנמצאת אחרי התחנה החדשה שהתווספה, נגדיל את האינדקס שלה
                foreach (var item in stationInLines)
                {
                    if (item.StationInLineLocation >= stationLine.StationInLineLocation)
                    {
                        ++item.StationInLineLocation;
                    }
                    // הוספת כל התחנות קו לרשימת תחנות הקו עם האינדקס המעודכן 
                    dl.AddStationInLine(item);
                }
                DO.StationInLine stationInLine = new DO.StationInLine();
                stationLine.CopyPropertiesTo(stationInLine);

                //   הוספת התחנה החדשה לרשימת תחנות הקו
                dl.AddStationInLine(stationInLine);

                //  יצירת שתי ישויות של תחנות עוקבות 
                // תחנה לפני והתחנה החדשה 
                dl.AddAdjacentStations(new DO.AdjacentStations{ StationId1 = stationLine.PreviousStationId, StationId2 = stationLine.StationId, AverageTravelTime = stationLine.NextAverageTravelTime, DistanceBetweenTwoAdjacentSations = stationLine.PreviousDistanceBetweenTwoAdjacentSations });
                // התחנה החדשה והתחנה אחרי
                dl.AddAdjacentStations(new DO.AdjacentStations { StationId1 = stationLine.StationId, StationId2 = stationLine.NextStationId, AverageTravelTime = stationLine.AverageTravelTime, DistanceBetweenTwoAdjacentSations = stationLine.DistanceBetweenTwoAdjacentSations });

            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadLineIdException("Line ID is illegal", ex);
            }

            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("Line ID and Station ID already exist", ex);
            }
           
        }

        /// <summary>
        ///  מקבלת תחנת קו במטרה לעדכן אותה ברשימת תחנות הקו
        /// </summary>
        public void UpdateStationLine(StationLine stationLine)
        {
            try
            {
                DO.StationInLine stationLine1 = new DO.StationInLine();
                stationLine.CopyPropertiesTo(stationLine1);
                dl.UpdateStationInLine(stationLine1);
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("Line ID and Station ID do not exist", ex);
            }
        }
        public IEnumerable<StationLine> StationLineList(int IdLine)
        {
            try
            {
                List<DO.StationInLine> stationInLines = dl.GetAllLineStationsInSpecificLine(IdLine).ToList();
                List<StationLine> stationInLinesB = new List<StationLine>();
                Func<DO.StationInLine, StationLine> item1 = func =>
                {
                    StationLine stationLine1 = new StationLine();
                    stationLine1.LineId = func.LineId;
                    stationLine1.StationId = func.StationId;
                    stationLine1.IsAvailableStationInLine = func.IsAvailableStationInLine;
                    stationLine1.StationInLineLocation = func.StationInLineLocation;
                    stationLine1.DropOffStation = func.DropOffStation;
                    stationLine1.UploadStation = func.UploadStation;
                    return stationLine1;
                };

                //סידור התחנות לפי האינדקסים
                stationInLinesB = (from s in stationInLines
                                   let p = item1(s)
                                   orderby p.StationInLineLocation
                                   select p).ToList();
                for (int i = 0; i < stationInLinesB.Count - 1; i++)
                {
                    DO.AdjacentStations adjacentStations = dl.GetAdjacentStations(stationInLinesB[i].StationId, stationInLinesB[i + 1].StationId);
                    stationInLinesB[i].AverageTravelTime = adjacentStations.AverageTravelTime;
                    stationInLinesB[i].DistanceBetweenTwoAdjacentSations = adjacentStations.DistanceBetweenTwoAdjacentSations;
                }


                List<string> namesOfStations = new List<string>();
                

                // שאילתא שנותנת את שמות התחנות שהקו עובר בהן
                namesOfStations = (from station in stationInLinesB
                                   let r = dl.GetStation(station.StationId)
                                   select r.StationName).ToList();

                // התאמה בין שם תחנה פיזית לתחנת הקו
                for (int i = 0; i < stationInLinesB.Count; i++)
                {
                    stationInLinesB[i].StationName = namesOfStations[i];
                }
                return stationInLinesB;
            }
            catch (Exception)
            {

                throw;
            }
        }
            /// <summary>
        ///  מקבלת תחנת קו במטרה למחק אותה מרשימת תחנות הקו
        /// </summary>
        public void DeleteStationLine(int lineId, int stationId)
        {
            try
            {
                DO.StationInLine stationInLine1 = dl.GetStationInLine(lineId, stationId);
                List<DO.StationInLine> stationInLines1 = new List<DO.StationInLine>();


                // שליפת כל תחנות הקו של קו ספציפי
                List<DO.StationInLine> stationInLines = dl.GetAllLineStationsInSpecificLine(lineId).ToList();
                DO.StationInLine stationInLine = dl.GetStationInLine(lineId, stationId);
                dl.DeleteLineStation1(lineId);
                // יצירת יישות אחת חדשה של תחנות עוקבות
                //  עם התחנה לפני התחנה שנמחקה ותחנה אחרי התחנה שנמחקה
                DO.AdjacentStations adjacentStations = new DO.AdjacentStations();
                foreach (DO.StationInLine item in stationInLines.Where(i => i.StationId != stationId))
                {
                    if (item.StationInLineLocation == stationInLine.StationInLineLocation - 1)
                    {
                        adjacentStations.StationId1 = item.StationId;
                    }
                    if (item.StationInLineLocation == stationInLine.StationInLineLocation + 1)
                    {
                        adjacentStations.StationId2 = item.StationId;
                    }
                    if (item.StationInLineLocation > stationInLine.StationInLineLocation)
                    {
                        --item.StationInLineLocation;
                    }
                    dl.AddStationInLine(item);
                }
                // מחיקת התחנת קו מרשימת תחנות הקו הכללית
                if (stationInLine1.IsAvailableStationInLine)
                {
                    dl.AddStationInLine(stationInLine1);
                    dl.DeleteStationInLine(lineId, stationId);
                }
                // הוספת יישות התחנות העוקבות לרשימת תחנות העוקבות הכללית
                if (adjacentStations.StationId1 != 0 && adjacentStations.StationId2 != 0)
                {
                    dl.AddAdjacentStations(adjacentStations);
                }
                
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("Line ID and Station ID do not exist", ex);
            }
        }

        /// <summary>
        ///  שולפת את כל תחנות הקו על ידי קריאה לפונקציה בDAL
        /// </summary>
        public IEnumerable<StationLine> GetAllStationLine()
        {
            try
            {
                IEnumerable<DO.StationInLine> StationLinesList;
                StationLinesList = dl.GetAllStationInLine();
                IEnumerable<StationLine> StationLinesList1 = new List<StationLine>();
                StationLinesList.CopyPropertiesTo(StationLinesList1);
                return StationLinesList1;
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("Line Stations do not exist", ex);
            }


        }

        /// <summary>
        ///  מחזירה כמה תחנות קו יש בקו ספציפי
        /// </summary>
        public int GetNumberStationLine(int lineId)
        {
            try
            {
                 int num = dl.GetNumberStationLine(lineId);
                 return num; 
            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("There are not stations in this line", ex);
            }

        }



        /// <summary>
        ///  מקבלת שני מזהים של תחנת קו ושולפת את התחנה המבוקשת על ידי קריאה לפונקציה בDAL
        /// </summary>

        public StationLine GetStationLine(int lineId, int stationId)
        {
            // תקינות קלט
            try
            {
                DO.StationInLine stationInLine1 = new DO.StationInLine();
                stationInLine1 = dl.GetStationInLine(lineId, stationId);
                StationLine stationInLine = new StationLine();
                stationInLine1.CopyPropertiesTo(stationInLine);
                return stationInLine;

            }
            catch (DO.BadFirstIDSecondIDException ex)
            {
                throw new BO.BadLineIdStationIDException("Line Station does not exist", ex);
            }
        }

        //IEnumerable<StationInLine> GetAllStationInLineBy(Predicate<StationInLine> predicate);
        //void UpdateStationInLine(int id, Action<StationInLine> update);

        #endregion
    
        #region Station

        /// <summary>
        ///  מקבלת תחנה במטרה להוסיף אותה לרשימת התחנות 
        /// </summary>
        public void AddStation(Station station)
        {
            // תקינות קלט
            try
            {
                DO.Station station1 = new DO.Station();
                station.CopyPropertiesTo(station1);
                dl.AddStation(station1);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadStationIdException("Station ID already exist", ex);
            }
        }

        /// <summary>
        ///  מקבלת תחנה במטרה לעדכן אותה ברשימת התחנות 
        /// </summary>
        public void UpdateStation(Station station)
        {
            try
            {
                DO.Station station1 = new DO.Station();
                station.CopyPropertiesTo(station1);
                dl.UpdateStation(station1);
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadStationIdException("Station ID is illegal", ex);
            }
        }

        /// <summary>
        ///  מקבלת תחנה במטרה למחק אותה מרשימת התחנות 
        /// </summary>
        public void DeleteStation(int id)
        {
            try
            {
                try
                {
                    // מחיקת התחנה הפיזית 
                    dl.DeleteStation(id);
                    //  מחזירה את כל הקווים שעוברים בתחנה 
                    List<Line> lines = GetAllLinesInSpecificStation(id).ToList();
                    //עבור כל קו , מוחקים את תחנת הקו שהמספר שלה שווה למספר של התחנה הפיזית עם הפונקציה של מחיקת תחנה מקו 
                    // 
                    foreach (Line item in GetAllLinesInSpecificStation(id))
                    {
                        DeleteStationLine(item.LineId, id);
                    }
                    

                }
                catch (DO.BadFirstIDSecondIDException ex)
                {
                    throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
                }
                catch (DO.BadFirstIDSecondTimeIDException ex)
                {
                    throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
                }
                catch (DO.BadIdException ex)
                {
                    throw new BO.BadLineIdStartingTimeIDException("Leaving Lines do not exist", ex);
                }
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadStationIdException("This Station does not exist", ex);
            }
        }
     
        /// <summary>
        ///  מקבלת מזהה קו ושולפת את כל התחנות הפיזיות שלו על ידי קריאה לפונקציה בDAL
        /// </summary>
        public IEnumerable<BO.Station> GetAllStationInSpecificLine(int lineId)
        {
            try
            {
                IEnumerable<DO.Station> Stations;
                Stations = dl.GetAllStationInSpecificLine(lineId);
                Func<DO.Station, Station> func = item =>
                {
                    Station station = new Station();
                    station.StationId = item.StationId;
                    return station;
                };
                return from station in Stations
                       let p = func(station)
                       select p;
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadStationIdException("There are no stations in this line ", ex);
            }
        }

         
        /// <summary>
        ///  מחזירה את כל מספרי התחנות על ידי קריאה לפונקציה בDAL
        /// </summary>
        public IEnumerable<int> GetAllStations()
        {
            try
            {
                IEnumerable<DO.Station> StationsList;
                StationsList = dl.GetAllStations();

                return from station in StationsList
                       select station.StationId;
            }
            catch (DO.BadIdException ex)
            {
                throw new BO.BadStationIdException("There are no stations in this line ", ex);
            }

        }



        /// <summary>
        ///  מקבלת מזהה תחנה ושולפת את התחנה על ידי קריאה לפונקציה בDAL 
        /// </summary>
        public Station GetStation(int id)
        {
            Station station1 = new Station();
            try
            {
                DO.Station station = new DO.Station();
                station = dl.GetStation(id);

               
                station.CopyPropertiesTo(station1);
                return station1;
           

            }
           
            catch (DO.BadIdException ex)
            {
                throw new BO.BadStationIdException("Station  does not exist", ex);
            }
           
        }



        //IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        //void UpdateStation(int id, Action<Station> update);

        #endregion

        #region BusOnTrip
        //public void AddBusOnTrip(BusOnTrip busOnTrip)
        //{
        //    // תקינות קלט
        //    try
        //    {
        //        DO.BusOnTrip busOnTrip1 = new DO.BusOnTrip();
        //        busOnTrip.CopyPropertiesTo(busOnTrip1);
        //        dl.AddBusOnTrip(busOnTrip1);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        ////void UpdateBusOnTrip(BusOnTrip busOnTrip);
        //public void DeleteBusOnTrip(int id)
        //{

        //}
        ////BusOnTrip GetBusOnTrip(int id);
        ////IEnumerable<BusOnTrip> GetAllBusesOnTrip();

        //// IEnumerable<BusOnTrip> GetAllBusesOnTripBy(Predicate<BusOnTrip> predicate);   
        ////void UpdateBusOnTrip(int id, Action<BusOnTrip> update); 

       #endregion BusOnTrip

        #region User

        /// <summary>
        ///  מקבלת  משתמש במטרה להוסיף אותו לרשימת כל המשתמשים
        /// </summary>
        public void AddUser(User user)
        {
            // תקינות קלט
            try
            {
                DO.User user1 = new DO.User();
                user.CopyPropertiesTo(user1);
                dl.AddUser(user1);
            }
            catch (DO.BadStringIdException ex)
            {
                throw new BO.BadUserIdException("User ID is illegal", ex);
            }
        }

        /// <summary>
        ///  מקבלת  משתמש במטרה למחוק אותו מרשימת כל המשתמשים
        /// </summary>
        public void DeleteUser(string userName)
        {
            try
            {
                dl.DeleteUser(userName);
            }
            catch (DO.BadStringIdException ex)
            {
                throw new BO.BadUserIdException("User does not exist ", ex);
            }
        }

        /// <summary>
        ///  מקבלת  משתמש במטרה לעדכן אותו ברשימת כל המשתמשים
        /// </summary>
        public void UpdateUser(User user)
        {
            try
            {
                DO.User user1 = new DO.User();
                user.CopyPropertiesTo(user1);
                dl.UpdateUser(user1);
            }
            catch (DO.BadStringIdException ex)
            {
                throw new BO.BadUserIdException("User ID is illegal", ex);
            }
        }

        /// <summary>
        ///  מקבלת  שם משתמש במטרה לשלוף אותו מרשימת כל המשתמשים על ידי קריאה לפונקציה בDAL
        /// </summary>
        public User GetUser(string userName)
        {
            // תקינות קלט
            try
            {
                DO.User user1 = new DO.User();
                user1 = dl.GetUser(userName);
                User user = new User();
                user1.CopyPropertiesTo(user);
                return user;

            }
            catch (DO.BadStringIdException ex)
            {

                throw new BO.BadUserIdException("User id  does not exist", ex);
            }
        }

        /// <summary>
        ///  שולפת את כל המשתמשים מרשימת המשתמשים על ידי קריאה לפונקציה בDAL
        /// </summary>
        public IEnumerable<User> GetAllUsers() 
        {
            try
            {
                IEnumerable<DO.User> UsersList;
                UsersList = dl.GetAllUsers();
                IEnumerable<User> UsersList1 = new List<User>().AsEnumerable();
                UsersList.CopyPropertiesTo(UsersList1);
                return UsersList1;
            }
            catch (DO.BadStringIdException ex)
            {
                throw new BO.BadUserIdException("Usersdo not exist", ex);
            }


        }



        // IEnumerable<User> GetAllUsersBy(Predicate<User> predicate);
        //void UpdateUser(int id, Action<User> update);
        #endregion User

        

    }

}


