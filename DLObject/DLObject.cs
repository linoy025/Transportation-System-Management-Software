using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
//using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDL
    {

        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static IDL Instance { get => instance; }// The public Instance property to use
        #endregion


        #region AdjacentStations


        public void AddAdjacentStations(DO.AdjacentStations adjacentStations) //(line1 => line1.LineId == line.LineId && line1.IsAvailableLine))
        {
            if (DataSource.ListAllAdjacentStations.Exists(adjacentStations1 => adjacentStations1.StationId1 == adjacentStations.StationId1
                                                          && adjacentStations1.StationId2 == adjacentStations.StationId2))
            {
                // throw new DlExceptions("Sorry, This adjacent stations already exists");
                throw new DO.BadFirstIDSecondIDException(adjacentStations.StationId1, adjacentStations.StationId2, "This adjacent stations already exists");
            }
            else
            {
                DataSource.ListAllAdjacentStations.Add(adjacentStations.Clone());
            }
        }

        public void DeleteAdjacentStations(int id1, int id2)
        {
            int index = DataSource.ListAllAdjacentStations.FindIndex(adjacentStations1 => adjacentStations1.StationId1 == id1
                                                                     && adjacentStations1.StationId2 == id2);
            //   Station station = DataSource.ListAllStations.FirstOrDefault(station1 => station1.StationId == id);
            if (index == -1)
            {
               // throw new DlExceptions("Sorry, This adjacent stations doesn't exists");
                throw new DO.BadFirstIDSecondIDException(id1, id2, "This adjacent stations doesn't exists");
            }
            else
            {
                DataSource.ListAllAdjacentStations.RemoveAt(index);
                //DataSource.ListAllStationsInLine.RemoveAll(station1 => station1.StationId == id);
            }
        }

        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            return from item in DataSource.ListAllAdjacentStations
                   select item.Clone();

        }


        public DO.AdjacentStations GetAdjacentStations(int id1, int id2)
        {
            DO.AdjacentStations adjacentStations = DataSource.ListAllAdjacentStations.Find(adjacentStations1 => adjacentStations1.StationId1 == id1 &&
                                                               adjacentStations1.StationId2 == id2);
            //return adjacentStations.Clone() ?? throw new DlExceptions("Sorry, This adjacent stations doesn't exist");
            return adjacentStations.Clone() ??  throw new DO.BadFirstIDSecondIDException(id1, id2, " This  adjacent stations doesn't exists");
        }

        // לברר איך אפשר לשלוף את התחנות העוקבות בדיוק באותו קו בלי שנקבל תחנות עוקבות שאחד מקודי התחנה בכלל בקו אחר
        public IEnumerable<DO.AdjacentStations> GetAllLineAdjacentStationsInSpecificLine(int lineId)
        {
            return from stationInLineD in DataSource.ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine && stationInLineD.LineId == lineId
                   let temp = stationInLineD.StationId
                   from AdjacentStationsD in DataSource.ListAllAdjacentStations
                   where AdjacentStationsD.StationId1 == temp || AdjacentStationsD.StationId2 == temp
                   select AdjacentStationsD.Clone();

        }

        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            int count = DataSource.ListAllAdjacentStations.RemoveAll(adjacentStations1 => adjacentStations1.StationId1 == adjacentStations.StationId1
                                                          && adjacentStations1.StationId2 == adjacentStations.StationId2);
            if (count == 0)
                //throw new DlExceptions("Sorry, This adjacent stations  doesn't exist");
                throw new DO.BadFirstIDSecondIDException(adjacentStations.StationId1, adjacentStations.StationId2, " This  adjacent stations doesn't exists");
            AddAdjacentStations(adjacentStations.Clone());
        }

        //  void IDL.UpdateAdjacentStations(int id1, int id2, Action<AdjacentStations> update);
        //IEnumerable<AdjacentStations> IDL.GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        #endregion

        #region Bus
        public void AddBus(DO.Bus bus)
        {
            if (DataSource.ListAllBuses.Exists(bus1 => bus1.LicenseNumber == bus.LicenseNumber && bus1.IsAvailableBus))
            {
                //throw new DlExceptions("Sorry, This bus already exists");
                throw new DO.BadIdException(bus.LicenseNumber, "Duplicate bus ID");
            }
            else
            {
                DataSource.ListAllBuses.Add(bus.Clone());
            }
        }

        public void DeleteBus(int id1)
        {
            if (DataSource.ListAllBuses.Exists(bus1 => bus1.LicenseNumber == id1 && bus1.IsAvailableBus))
            {
                foreach (DO.Bus item in DataSource.ListAllBuses)
                {
                    if (item.LicenseNumber == id1)
                    {
                        item.IsAvailableBus = false;
                    }
                }
            }
            else
            {
                throw new DO.BadIdException(id1, $"bad  id: {id1}");
                //throw new DlExceptions("Sorry, This bus doesn't exist");
            }
        }

        public DO.Bus GetBus(int id)
        {
            DO.Bus bus = DataSource.ListAllBuses.Find(bus1 => bus1.LicenseNumber == id && bus1.IsAvailableBus);
            //return bus.Clone() ?? throw new DlExceptions("Sorry, This bus doesn't exist");
            return bus.Clone() ??  throw new DO.BadIdException(id, $"bad  id: {id}");
        }

        public IEnumerable<DO.Bus> GetAllBuses()
        {
            return from busD in DataSource.ListAllBuses
                   where busD.IsAvailableBus
                   select busD.Clone();
        }

        public void UpdateBus(DO.Bus bus)
        {
            int count = DataSource.ListAllBuses.RemoveAll(bus1 => bus1.LicenseNumber == bus.LicenseNumber && bus1.IsAvailableBus);
            if (count == 0)
            { 
               
               // throw new DlExceptions("Sorry, This bus doesn't exist");
                throw new DO.BadIdException(bus.LicenseNumber, $"bad  id: {bus.LicenseNumber}");
            }
            else
            {
                AddBus(bus.Clone());
            }
           
        }


        #endregion Bus

        #region LeavingLine

        public void AddLeavingLine(DO.LeavingLine leavingLine)
        {

            if (DataSource.ListAllLeavingLines.Exists(leavingLine1 => leavingLine1.LineId == leavingLine.LineId &&
                                                   leavingLine1.StartingTime == leavingLine.StartingTime && leavingLine1.IsAvailableLeavingLine))
            {
                // throw new DlExceptions("Sorry, This leavingLine already exists");
                
                throw new DO.BadFirstIDSecondTimeIDException(leavingLine.LineId, leavingLine.StartingTime, "This leaving Line already exists");

            }
            else
            {
                DataSource.ListAllLeavingLines.Add(leavingLine.Clone());
            }

        }

        public void UpdateLeavingLine(DO.LeavingLine leavingLine)
        {
            int count = DataSource.ListAllLeavingLines.RemoveAll(leavingLine1 => leavingLine1.LineId == leavingLine.LineId);
            if (count == 0)
                //throw new DlExceptions("Sorry, This line doesn't exist");
                throw new DO.BadFirstIDSecondTimeIDException(leavingLine.LineId, leavingLine.StartingTime, "This leaving Line  doesn't exists");
            AddLeavingLine(leavingLine.Clone());
        }
        public void DeleteLeavingLine(int id, TimeSpan startingtime)
        {
            if (DataSource.ListAllLeavingLines.Exists(leavingLine1 => leavingLine1.LineId == id &&
                                                    leavingLine1.StartingTime == startingtime && leavingLine1.IsAvailableLeavingLine))
            {
                foreach (DO.LeavingLine item in DataSource.ListAllLeavingLines)
                {
                    if (item.LineId == id && item.StartingTime == startingtime)
                    {
                      //DataSource.ListAllLeavingLines.Remove(item);
                        item.IsAvailableLeavingLine = false;
                        break;
                    }
                }
            }
            else
            {
                //throw new DlExceptions("Sorry, This bus doesn't exist");
                throw new DO.BadFirstIDSecondTimeIDException(id, startingtime, "This leaving Line  doesn't exists");
            }
        }
        public IEnumerable<DO.LeavingLine> GetAllLeavingLines()
        {
            return from leavingLineD in DataSource.ListAllLeavingLines
                   where leavingLineD.IsAvailableLeavingLine 
                   select leavingLineD.Clone();
        }
        public DO.LeavingLine GetLeavingLine(int id, TimeSpan startingtime)
        {
            DO.LeavingLine leavingLine = DataSource.ListAllLeavingLines.Find(leavingLine1 => leavingLine1.LineId == id &&
                                                                        leavingLine1.StartingTime == startingtime && leavingLine1.IsAvailableLeavingLine);
            //return leavingLine.Clone() ?? throw new DlExceptions("Sorry, This leaving Line doesn't exist");
            return leavingLine.Clone() ??  throw new DO.BadFirstIDSecondTimeIDException(id, startingtime, "This leaving Line  doesn't exists");
        }



        public IEnumerable<DO.LeavingLine> GetAllLeavingLinesInSpecificLine(int id)
        {
            return from leavingLineD in DataSource.ListAllLeavingLines
                   where leavingLineD.LineId == id && leavingLineD.IsAvailableLeavingLine == true
                   orderby leavingLineD.StartingTime
                   select leavingLineD.Clone();
        }





        //IEnumerable<LeavingLine> GetAllLeavingLinesBy(Predicate<LeavingLine> predicate);
        //void UpdateLeavingLine(LeavingLine leavingLine);
        //void UpdateLeavingLine(int id, Action<LeavingLine> update);

        #endregion

        #region Line

        public int AddLine(DO.Line line)
        {
            line.LineId = Config.lineCounter;
            Config.lineCounter++;
            if (DataSource.ListAllLines.Exists(line1 => line1.LineId == line.LineId && line1.IsAvailableLine))
            {
                //throw new DlExceptions("Sorry, This line already exists");
                throw new DO.BadIdException(line.LineId, "Duplicate line ID");
            }
            else
            {
                DataSource.ListAllLines.Add(line.Clone());
            }
            return line.LineId;
        }

        public void DeleteLine(int id)
        {
            if (DataSource.ListAllLines.Exists(line1 => line1.LineId == id && line1.IsAvailableLine))
            {
                foreach (DO.Line item in DataSource.ListAllLines)
                {
                    if (item.LineId == id)
                    {
                        item.IsAvailableLine = false;
                    }
                }

               // IEnumerable<StationInLine> ListAllLineStationsInSpecificLine = GetAllLineStationsInSpecificLine(id);
                foreach (DO.StationInLine item in DataSource.ListAllStationsInLine)
                {
                    if (item.LineId == id)
                    {
                        item.IsAvailableStationInLine = false;
                    }
                }

            }
            // לעבור על כל התחנות של הקו ולסמו ISAVAILABLE=FALSE
            else
            {
                throw new DO.BadIdException(id, $"bad  id: {id}");
                //throw new DlExceptions("Sorry, This Line doesn't exist");
            }
        }

        public IEnumerable<DO.Line> GetAllLines()
        {
            return from lineD in DataSource.ListAllLines
                   //where lineD.IsAvailableLine
                   where lineD.IsAvailableLine == true
                   select lineD.Clone();
        }

        // new - רשימת הקווים שעוברים בתחנה פיזית מסויימת
        public IEnumerable<DO.Line> GetAllLinesInSpecificStation(int stationId)
        {

            return from stationInLineD in DataSource.ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine && stationInLineD.StationId == stationId
                   let temp = stationInLineD.LineId
                   from LineD in DataSource.ListAllLines
                   where LineD.IsAvailableLine && LineD.LineId == temp
                   select LineD.Clone();


            //return from lineD in DataSource.ListAllLines
            //       where lineD.IsAvailableLine //&&
            //       select lineD.Clone();
        }

        public DO.Line GetLine(int id)
        {
            DO.Line line = DataSource.ListAllLines.Find(line1 => line1.LineId == id && line1.IsAvailableLine);
            return line.Clone() ?? throw new DO.BadIdException(id, $"bad line id: {id}");
            //return line.Clone() ?? throw new DlExceptions("Sorry, This line doesn't exist");

        }

        public void UpdateLine(DO.Line line)
        {
            int count = DataSource.ListAllLines.FindIndex(line1 => line1.LineId == line.LineId && line1.IsAvailableLine);
            if (count == -1)

               // throw new DlExceptions("Sorry, This line doesn't exist");
                throw new DO.BadIdException(line.LineId, $"bad line id: {line.LineId}");
            else
            {
                DataSource.ListAllLines[count] = line.Clone();
            }
        }

        //IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);

        //void UpdateLine(int id, Action<Line> update);

        #endregion

        #region StationInLine

        public int GetNumberStationLine(int lineId)
        {
          
            int NumberOfStationsInLine = 0;

            foreach (var item in DataSource.ListAllStationsInLine)
            {
                if (item.LineId == lineId)
                    NumberOfStationsInLine++;
            }
            return NumberOfStationsInLine;
        }

        public void AddStationInLine(DO.StationInLine stationInLine)
        {
            stationInLine.IsAvailableStationInLine = true;
            if (DataSource.ListAllStationsInLine.Exists(stationInLine1 => stationInLine1.LineId == stationInLine.LineId &&
                  stationInLine1.StationId == stationInLine.StationId && stationInLine1.IsAvailableStationInLine))
            {
                // throw new DlExceptions("Sorry, This station in line already exists");
                throw new DO.BadFirstIDSecondIDException(stationInLine.LineId, stationInLine.StationId, "station ID is already exists in line ID");
            }
            else
            {
                DataSource.ListAllStationsInLine.Add(stationInLine.Clone());
            }
        }
        public void DeleteStationInLine(int lineId, int stationId)
        {

            int count = DataSource.ListAllStationsInLine.FindIndex(stationInLine1 => stationInLine1.LineId == lineId &&
                                                   stationInLine1.StationId == stationId && stationInLine1.IsAvailableStationInLine);
            if (count == -1)

                // throw new DlExceptions("Sorry, This line doesn't exist");
                throw new DO.BadFirstIDSecondIDException(lineId, stationId, " station ID doesn't exists in line ID");
            else
            {
                DataSource.ListAllStationsInLine[count].IsAvailableStationInLine = false;
            }


            //if (DataSource.ListAllStationsInLine.Exists(stationInLine1 => stationInLine1.LineId == lineId &&
            //                                        stationInLine1.StationId == stationId && stationInLine1.IsAvailableStationInLine))
            //{
            //    foreach (DO.StationInLine item in DataSource.ListAllStationsInLine)
            //    {
            //        if (item.LineId == lineId && item.StationId == stationId && item.IsAvailableStationInLine  )
            //        {
            //            item.IsAvailableStationInLine = false;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //   // throw new DlExceptions("Sorry, This station in line doesn't exist");
            //    throw new DO.BadFirstIDSecondIDException(lineId, stationId, " station ID doesn't exists in line ID");
            //}
        }
        public IEnumerable<DO.StationInLine> GetAllStationInLine()
        {
            return from stationInLineD in DataSource.ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine
                   select stationInLineD.Clone();
        }

        // מחזירה תחנות קו של קו ספציפי
        public IEnumerable<DO.StationInLine> GetAllLineStationsInSpecificLine(int lineId)
        {
            return from stationInLineD in DataSource.ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine && stationInLineD.LineId == lineId
                   select stationInLineD.Clone();
        }

        // מוחקת את כל תחנות הקו של הקו הספציפי   
        public void DeleteLineStation1(int NumberLine)
        {
            int index = DataSource.ListAllStationsInLine.FindIndex(lineStation => lineStation.LineId == NumberLine && lineStation.IsAvailableStationInLine);
            _ = index != -1
                ? DataSource.ListAllStationsInLine.RemoveAll(item => item.LineId == NumberLine)
                : throw new DO.BadFirstIDSecondIDException( NumberLine, NumberLine, "The line does not exist in the list");
        }

        //  2 Station list
        // עבור כל קוד תחנה מהתחנות קו, תשלוף את שם התחנה

        //public IEnumerable<Station> GetAllStationInSpecificLine(int lineId)
        //{
        //    return from stationD in DataSource.ListAllStations
        //           where stationD.IsAvailableStation && stationD.LineId == lineId
        //           select stationD.Clone();
        //}

        //  2 Station list



        // 3 AdjacentStations 
        // עבור כל שני קודים של תחנות קו עוקבות, תשלוף את הישויות המתאימות
        //public IEnumerable<AdjacentStations> GetAllAdjacentStationsInSpecificLine(int lineId)
        //{
        //    return from adjacentStationsD in DataSource.ListAllAdjacentStations
        //           select adjacentStationsD.Clone();
        //}






        public DO.StationInLine GetStationInLine(int lineId, int stationId)
        {
            DO.StationInLine stationInLine = DataSource.ListAllStationsInLine.Find(stationInLine1 => stationInLine1.LineId == lineId &&
                                                                  stationInLine1.StationId == stationId && stationInLine1.IsAvailableStationInLine);
            //return stationInLine.Clone() ?? throw new DlExceptions("Sorry, This leaving Line doesn't exist");
            return stationInLine.Clone() ?? throw new DO.BadFirstIDSecondIDException(lineId, stationId, " This station in line doesn't exists");
        }

        public void UpdateStationInLine(DO.StationInLine stationInLine)
        {
            int count = DataSource.ListAllStationsInLine.RemoveAll(stationInLine1 => stationInLine1.StationId == stationInLine.StationId
                                                                   && stationInLine1.LineId == stationInLine.LineId && stationInLine1.IsAvailableStationInLine);
            if (count == 0)
                //throw new DlExceptions("Sorry, This user doesn't exist");
                throw new DO.BadFirstIDSecondIDException(stationInLine.LineId, stationInLine.StationId, " This   station in line  doesn't exists");
            AddStationInLine(stationInLine.Clone());
        }

        //void UpdateStationInLine(int id, Action<StationInLine> update);
        //IEnumerable<StationInLine> GetAllStationInLineBy(Predicate<StationInLine> predicate);


        #endregion

        #region Station

        public void AddStation(DO.Station station)
        {
            if (DataSource.ListAllStations.Exists(station1 => station1.StationId == station.StationId && station1.IsAvailableStation))
            {
                //throw new DlExceptions("Sorry, This station already exists");
                throw new DO.BadIdException(station.StationId, "Duplicate station ID");
            }
            else
            {
                DataSource.ListAllStations.Add(station.Clone());
            }
        }

        public void DeleteStation(int id)
        {
            int index = DataSource.ListAllStations.FindIndex(station1 => station1.StationId == id && station1.IsAvailableStation);
            //   Station station = DataSource.ListAllStations.FirstOrDefault(station1 => station1.StationId == id);
            if (index == -1)
            {
                //throw new DlExceptions("Sorry, This station doesn't exists");
                throw new DO.BadIdException(id, $"bad  id: {id}");
            }
            else
            {

                foreach (DO.Station item in DataSource.ListAllStations)
                {
                    // הוספנו תנאי כדי שלא ימחוק את כל התחנות
                    if (item.StationId == id )
                    {
                        item.IsAvailableStation = false;
                        break; 
                    }
                }
                foreach (DO.StationInLine item in DataSource.ListAllStationsInLine)
                {

                    // הוספנו תנאי כדי שלא ימחוק את כל התחנות
                    if (item.StationId == id)
                    {
                        item.IsAvailableStationInLine = false;
                    }
                }
                DataSource.ListAllAdjacentStations.RemoveAll(station1 => station1.StationId1 == id || station1.StationId2 == id);
            }
        }
        public IEnumerable<DO.Station> GetAllStations()
        {
           // var stlist = DataSource.ListAllStations;
           //var result =  from stationD in DataSource.ListAllStations
           //        where stationD.IsAvailableStation
           //        select stationD.Clone();
           // return result;

            var stlist = DataSource.ListAllStations;
            return from stationD in DataSource.ListAllStations
                         where stationD.IsAvailableStation
                         select stationD.Clone();
            
        }






        public DO.Station GetStation(int id)
        {
            DO.Station station = DataSource.ListAllStations.Find(station1 => station1.StationId == id && station1.IsAvailableStation);
            //return station.Clone() ?? throw new DlExceptions("Sorry, This station doesn't exist");
            return station.Clone() ?? throw new DO.BadIdException(id, $"bad  id: {id}");

        }

        //  עבור מזהה קו , תשלוף את רשימת התחנות הפיזיות שלו
        public IEnumerable<DO.Station> GetAllStationInSpecificLine(int lineId)
        {
            return from stationInLineD in DataSource.ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine && stationInLineD.LineId == lineId
                   let temp = stationInLineD.StationId
                   from stationD in DataSource.ListAllStations
                   where stationD.IsAvailableStation && stationD.StationId == temp
                   select stationD.Clone();
        }




        //public IEnumerable<Station> GetAllStationNotInSpecificLine(int lineId)
        //{
        //    return from stationInLineD in DataSource.ListAllStationsInLine
        //           where stationInLineD.IsAvailableStationInLine && stationInLineD.LineId != lineId
        //           let temp = stationInLineD.StationId
        //           from stationD in DataSource.ListAllStations
        //           where stationD.IsAvailableStation && stationD.StationId == temp
        //           select stationD;
        //}

        public void UpdateStation(DO.Station station)
        {
            int count = DataSource.ListAllStations.RemoveAll(station1 => station1.StationId == station.StationId && station1.IsAvailableStation);
            if (count == 0)
                //throw new DlExceptions("Sorry, This station doesn't exist");
                throw new DO.BadIdException(station.StationId, $"bad station id: {station.StationId}");
            AddStation(station.Clone());
        }



        // void UpdateStation(int id, Action<Station> update);
        //IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        #endregion

        #region BusOnTrip
        public void AddBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            if (DataSource.ListAllBusesOnTrip.Exists(busOnTrip1 => busOnTrip1.BusOnTripId == busOnTrip.BusOnTripId))
            {
                //throw new DlExceptions("Sorry, This bus is on trip already");
                throw new DO.BadIdException(busOnTrip.LicenseNumber, "Duplicate bus on trip ID");
            }
            else
            {
                DataSource.ListAllBusesOnTrip.Add(busOnTrip.Clone());
            }
        }

        public void DeleteBusOnTrip(int id)
        {
            int index = DataSource.ListAllBusesOnTrip.FindIndex(busOnTrip1 => busOnTrip1.BusOnTripId == id);
            //   Station station = DataSource.ListAllStations.FirstOrDefault(station1 => station1.StationId == id);
            if (index == -1)
            {
                //throw new DlExceptions("Sorry,This trip has never been made");
                throw new DO.BadIdException(id, $"bad  id: {id}");
            }
            else
            {
                DataSource.ListAllBusesOnTrip.RemoveAt(index);
            }
        }
        public DO.BusOnTrip GetBusOnTrip(int id)
        {
            DO.BusOnTrip busOnTrip = DataSource.ListAllBusesOnTrip.Find(busOnTrip1 => busOnTrip1.BusOnTripId == id);
             return busOnTrip.Clone() ?? throw new DO.BadIdException(id, $"bad  id: {id}");
            // return busOnTrip.Clone() ?? throw new DlExceptions("Sorry, This trip has never been made");
        }
        public IEnumerable<DO.BusOnTrip> GetAllBusesOnTrip()
        {
            return from busOnTripD in DataSource.ListAllBusesOnTrip
                   select busOnTripD.Clone();
        }
        public void UpdateBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            int count = DataSource.ListAllBusesOnTrip.RemoveAll(busOnTrip1 => busOnTrip1.BusOnTripId == busOnTrip.BusOnTripId);
            if (count == 0)
                //throw new DlExceptions("Sorry, This bus on trip doesn't exist");
           
            AddBusOnTrip(busOnTrip.Clone());
        }


        // IEnumerable<BusOnTrip> GetAllBusesOnTripBy(Predicate<BusOnTrip> predicate);
        //void UpdateBusOnTrip(BusOnTrip busOnTrip);
        //void UpdateBusOnTrip(int id, Action<BusOnTrip> update); 


        #endregion BusOnTrip

        #region User
        public void AddUser(DO.User user)
        {
            if (DataSource.ListAllUsers.Exists(user1 => user1.UserName == user1.UserName && user1.IsAvailableUser))
            {
                // throw new DlExceptions("Sorry, This user already exists");
                throw new DO.BadStringIdException(user.UserName, $"bad  id: {user.UserName}");
            }
            else
            {
                DataSource.ListAllUsers.Add(user.Clone());
            }
        }

        public void DeleteUser(string userName)
        {
            if (DataSource.ListAllUsers.Exists(user1 => user1.UserName == userName && user1.IsAvailableUser))
            {
                foreach (DO.User item in DataSource.ListAllUsers)
                {
                    if (item.UserName == userName)
                    {
                        item.IsAvailableUser = false;
                    }
                }
            }
            else
            {
                //throw new DlExceptions("Sorry, This user doesn't exist");
                throw new DO.BadStringIdException(userName, $"bad  id: {userName}");

            }
        }
        public DO.User GetUser(string userName)
        {
            DO.User user = DataSource.ListAllUsers.Find(user1 => user1.UserName == userName && user1.IsAvailableUser);
            // return user.Clone() ?? throw new DlExceptions("Sorry, This user doesn't exist");
            return user.Clone() ??  throw new DO.BadStringIdException(userName, $"bad  id: {userName}");

        }
        public IEnumerable<DO.User> GetAllUsers()
        {
            return from userD in DataSource.ListAllUsers
                   where userD.IsAvailableUser
                   select userD.Clone();
        }
        public void UpdateUser(DO.User user)
        {
            int count = DataSource.ListAllUsers.RemoveAll(user1 => user1.UserName == user.UserName && user1.IsAvailableUser);
            if (count == 0)
                //throw new DlExceptions("Sorry, This user doesn't exist");
            throw new DO.BadStringIdException(user.UserName, $"bad  id: {user.UserName}");
            AddUser(user.Clone());
        }

        // IEnumerable<User> GetAllUsersBy(Predicate<User> predicate);
        //void UpdateUser(int id, Action<User> update); 

        #endregion User

    }
}























 