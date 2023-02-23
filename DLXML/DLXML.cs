
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{

    sealed class DLXML : IDL    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() {
        }// static ctor to ensure instance init is done just before first usage
        DLXML(){ } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region DS XML Files
        public static string configPath = @"ConfigXml.xml"; //XMLSerializer
        public static string stationsPath = @"StationsPathXml.xml"; //XMLSerializer
        public static string usersPath = @"UsersXml.xml"; //XMLSerializer
        public static string busesPath = @"BuseXml.xml"; //XMLSerializer
        public static string linesPath = @"LinesXml.xml"; //XMLSerializer
        public static string lineStationsPath = @"LineStationsXml.xml"; //XMLSerializer       
        public static string adjacentStationsPath = @"AdjacentStationsXml.xml"; //XMLSerializer
        public static string leavingLinesPath = @"LeavingLinesXml.xml"; //XElement
        public static string busesOnTripPath = @"BusesOnTripXml.xml"; //XElement

        #endregion

        #region Station
        public DO.Station GetStation(int id)
        {
            List<Station> ListAllStations = XMLTOOLS.LoadListFromXMLSerializer<Station>(stationsPath);
            DO.Station station = ListAllStations.Find(station1 => station1.StationId == id);
            return station ?? throw new DO.BadIdException(id, $"bad  id: {id}");
        }


        public void AddStation(DO.Station station)
        {
            List<Station> ListAllStations = XMLTOOLS.LoadListFromXMLSerializer<Station>(stationsPath);

            if (ListAllStations.Exists(station1 => station1.StationId == station.StationId && station1.IsAvailableStation))
                throw new DO.BadIdException(station.StationId, "Duplicate station ID");

            ListAllStations.Add(station);

            XMLTOOLS.SaveListToXMLSerializer(ListAllStations, stationsPath);

        }



        public void DeleteStation(int id)
        {
            List<Station> ListAllStations = XMLTOOLS.LoadListFromXMLSerializer<Station>(stationsPath);
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            List<AdjacentStations> ListAllAdjacentStations = XMLTOOLS.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            int index = ListAllStations.FindIndex(station1 => station1.StationId == id);

            if (index == -1)
            {
                throw new DO.BadIdException(id, $"bad  id: {id}");
            }
            else
            {
                foreach (DO.Station item in ListAllStations)
                {
                    // הוספנו תנאי כדי שלא ימחוק את כל התחנות
                    if (item.StationId == id)
                    {
                        item.IsAvailableStation = false;
                        break;
                    }
                }

                //foreach (DO.StationInLine item in ListAllStationsInLine)
                //{

                //    // הוספנו תנאי כדי שלא ימחוק את כל התחנות
                //    if (item.StationId == id)
                //    {
                //        item.IsAvailableStationInLine = false;
                //    }
                //}
                ListAllAdjacentStations.RemoveAll(station1 => station1.StationId1 == id || station1.StationId2 == id);

                XMLTOOLS.SaveListToXMLSerializer(ListAllStations, stationsPath);
                XMLTOOLS.SaveListToXMLSerializer(ListAllStationsInLine, lineStationsPath);
                XMLTOOLS.SaveListToXMLSerializer(ListAllAdjacentStations, adjacentStationsPath);
            }


        }


        public void UpdateStation(DO.Station station)
        {
            List<Station> ListAllStations = XMLTOOLS.LoadListFromXMLSerializer<Station>(stationsPath);

            int count = ListAllStations.FindIndex(station1 => station1.StationId == station.StationId);
            if (count == -1)
                throw new DO.BadIdException(station.StationId, $"bad station id: {station.StationId}");
            else
            {
                ListAllStations[count] = station;
                XMLTOOLS.SaveListToXMLSerializer(ListAllStations, stationsPath);
            }
        }

        public IEnumerable<DO.Station> GetAllStations()
        {
            List<Station> ListAllStations = XMLTOOLS.LoadListFromXMLSerializer<Station>(stationsPath);
            return from station in ListAllStations
                   where station.IsAvailableStation
                   select station;
        }

        //  עבור מזהה קו , תשלוף את רשימת התחנות הפיזיות שלו
        public IEnumerable<DO.Station> GetAllStationInSpecificLine(int lineId)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            List<Station> ListAllStations = XMLTOOLS.LoadListFromXMLSerializer<Station>(stationsPath);

            return from stationInLine in ListAllStationsInLine
                   where stationInLine.IsAvailableStationInLine && stationInLine.LineId == lineId
                   let temp = stationInLine.StationId
                   from station in ListAllStations
                   where station.IsAvailableStation && station.StationId == temp
                   select station;
        }
 //<AdjacentStations>
 //     <StationId1>37060</StationId1>
 //     <StationId2>36614</StationId2>
 //     <DistanceBetweenTwoAdjacentSations>0</DistanceBetweenTwoAdjacentSations>
 //     <AverageTravelTime>0</AverageTravelTime>
 //   </AdjacentStations>
 //   <AdjacentStations>
 //     <StationId1>36614</StationId1>
 //     <StationId2>26910</StationId2>
 //     <DistanceBetweenTwoAdjacentSations>0</DistanceBetweenTwoAdjacentSations>
 //     <AverageTravelTime>0</AverageTravelTime>
 //   </AdjacentStations>
        #endregion Station

        #region Bus

        public DO.Bus GetBus(int id)
        {
            List<Bus> ListAllBuses = XMLTOOLS.LoadListFromXMLSerializer<Bus>(busesPath);
            DO.Bus bus = ListAllBuses.Find(bus1 => bus1.LicenseNumber == id);
            return bus ?? throw new DO.BadIdException(id, $"bad  id: {id}");
        }




        public void AddBus(DO.Bus bus)
        {
            List<Bus> ListAllBuses = XMLTOOLS.LoadListFromXMLSerializer<Bus>(busesPath);

            if (ListAllBuses.Exists(bus1 => bus1.LicenseNumber == bus.LicenseNumber && bus1.IsAvailableBus))
                throw new DO.BadIdException(bus.LicenseNumber, "Duplicate bus ID");

            ListAllBuses.Add(bus);

            XMLTOOLS.SaveListToXMLSerializer(ListAllBuses, busesPath);

        }

        public void DeleteBus(int id)
        {
            List<Bus> ListAllBuses = XMLTOOLS.LoadListFromXMLSerializer<Bus>(busesPath);

            DO.Bus bus = ListAllBuses.Find(p => p.LicenseNumber == id);

            if (bus != null && bus.IsAvailableBus == true)
            {
                bus.IsAvailableBus = false;
            }

            else
            {
                throw new DO.BadIdException(id, $"bad  id: {id}");
            }

            XMLTOOLS.SaveListToXMLSerializer(ListAllBuses, busesPath);
        }


        public void UpdateBus(DO.Bus bus)
        {
            List<Bus> ListAllBuses = XMLTOOLS.LoadListFromXMLSerializer<Bus>(stationsPath);

            int count = ListAllBuses.RemoveAll(bus1 => bus1.LicenseNumber == bus.LicenseNumber);
            if (count == 0)
                throw new DO.BadIdException(bus.LicenseNumber, $"bad station id: {bus.LicenseNumber}");
            AddBus(bus);

            XMLTOOLS.SaveListToXMLSerializer(ListAllBuses, busesPath);
        }

        public IEnumerable<DO.Bus> GetAllBuses()
        {
            List<Bus> ListAllBuses = XMLTOOLS.LoadListFromXMLSerializer<Bus>(busesPath);
            return from bus in ListAllBuses
                   where bus.IsAvailableBus
                   select bus;
        }



        #endregion Course

        #region  Line

        public DO.Line GetLine(int id)
        {
            List<Line> ListAllLines = XMLTOOLS.LoadListFromXMLSerializer<Line>(linesPath);
            DO.Line line = ListAllLines.Find(line1 => line1.LineId == id);
            return line ?? throw new DO.BadIdException(id, $"bad  id: {id}");
        }


        // לבדק גישה לקונפיג
        public int AddLine(DO.Line line)
        {
            List<Line> ListAllLines = XMLTOOLS.LoadListFromXMLSerializer<Line>(linesPath);
            line.LineId = ListAllLines[ListAllLines.Count - 1].LineId + 1;
            ListAllLines.Add(line);
            XMLTOOLS.SaveListToXMLSerializer(ListAllLines, linesPath);
            return line.LineId;
        }

        public void DeleteLine(int id)
        {
            List<Line> ListAllLines = XMLTOOLS.LoadListFromXMLSerializer<Line>(linesPath);
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);

            DO.Line line = ListAllLines.Find(p => p.LineId == id);

            if (line != null && line.IsAvailableLine == true)
            {
                line.IsAvailableLine = false;

                foreach (DO.StationInLine item in ListAllStationsInLine)
                {
                    if (item.LineId == id)
                    {
                        item.IsAvailableStationInLine = false;
                    }
                }
            }

            else
            {
                throw new DO.BadIdException(id, $"bad  id: {id}");
            }

            XMLTOOLS.SaveListToXMLSerializer(ListAllLines, linesPath);
            XMLTOOLS.SaveListToXMLSerializer(ListAllStationsInLine, lineStationsPath);
        }





        public void UpdateLine(DO.Line line)
        {
            List<Line> ListAllLines = XMLTOOLS.LoadListFromXMLSerializer<Line>(linesPath);
            int count = ListAllLines.FindIndex(line1 => line1.LineId == line.LineId);
            if (count == -1)
                throw new DO.BadIdException(line.LineId, $"bad line id: {line.LineId}");
            else
            {
                ListAllLines[count] = line;
                XMLTOOLS.SaveListToXMLSerializer(ListAllLines, linesPath);
            }
        }


        public IEnumerable<DO.Line> GetAllLines()
        {
            List<Line> ListAllLines = XMLTOOLS.LoadListFromXMLSerializer<Line>(linesPath);
            return from line in ListAllLines
                   where line.IsAvailableLine == true
                   select line;
        }

        // new - רשימת הקווים שעוברים בתחנה פיזית מסויימת
        public IEnumerable<DO.Line> GetAllLinesInSpecificStation(int stationId)
        {
            List<Line> ListAllLines = XMLTOOLS.LoadListFromXMLSerializer<Line>(linesPath);
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);

            return from stationInLineD in ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine && stationInLineD.StationId == stationId
                   let temp = stationInLineD.LineId
                   from LineD in ListAllLines
                   where LineD.IsAvailableLine && LineD.LineId == temp
                   select LineD;

        }



        #endregion

        #region User

        public DO.User GetUser(string userName)
        {
            List<User> ListAllUsers = XMLTOOLS.LoadListFromXMLSerializer<User>(usersPath);
            DO.User user = ListAllUsers.Find(user1 => user1.UserName == userName);
            return user ?? throw new DO.BadStringIdException(userName, $"bad  id: {userName}");

        }


        public void AddUser(DO.User user)
        {

            List<User> ListAllUsers = XMLTOOLS.LoadListFromXMLSerializer<User>(usersPath);

            if (ListAllUsers.Exists(user1 => user1.UserName == user1.UserName && user1.IsAvailableUser))
                throw new DO.BadStringIdException(user.UserName, $"bad  id: {user.UserName}");

            ListAllUsers.Add(user);

            XMLTOOLS.SaveListToXMLSerializer(ListAllUsers, usersPath);

        }

        public void DeleteUser(string userName)
        {
            List<User> ListAllUsers = XMLTOOLS.LoadListFromXMLSerializer<User>(usersPath);

            DO.User user = ListAllUsers.Find(p => p.UserName == userName);

            if (user != null && user.IsAvailableUser)
            {
                user.IsAvailableUser = false;
            }

            else
            {
                throw new DO.BadStringIdException(userName, $"bad  id: {userName}");
            }

            XMLTOOLS.SaveListToXMLSerializer(ListAllUsers, usersPath);
        }




        public void UpdateUser(DO.User user)
        {
            List<User> ListAllUsers = XMLTOOLS.LoadListFromXMLSerializer<User>(usersPath);
            int count = ListAllUsers.RemoveAll(user1 => user1.UserName == user.UserName);
            if (count == 0)
                //throw new DlExceptions("Sorry, This user doesn't exist");
                throw new DO.BadStringIdException(user.UserName, $"bad  id: {user.UserName}");
            AddUser(user);
            XMLTOOLS.SaveListToXMLSerializer(ListAllUsers, usersPath);
        }

        public IEnumerable<DO.User> GetAllUsers()
        {
            List<User> ListAllUsers = XMLTOOLS.LoadListFromXMLSerializer<User>(usersPath);
            return from user in ListAllUsers
                   where user.IsAvailableUser == true
                   select user;
        }


        #endregion User

        #region Line Station


        public DO.StationInLine GetStationInLine(int lineId, int stationId)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            DO.StationInLine stationInLine = ListAllStationsInLine.Find(stationInLine1 => stationInLine1.LineId == lineId &&
                                                                    stationInLine1.StationId == stationId);
            return stationInLine ?? throw new DO.BadFirstIDSecondIDException(lineId, stationId, " This station in line doesn't exists");
        }


        public int GetNumberStationLine(int lineId)
        {
           // int NumberOfStationsInLine = 0;
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            return ListAllStationsInLine.Count(item => item.LineId == lineId);
            //foreach (var item in ListAllStationsInLine)
            //{
            //    if (item.LineId == lineId)
            //        NumberOfStationsInLine++;
            //}
            //return NumberOfStationsInLine;
        }

        public void AddStationInLine(DO.StationInLine stationInLine)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);

            if (ListAllStationsInLine.Exists(stationInLine1 => stationInLine1.LineId == stationInLine.LineId &&
                         stationInLine1.StationId == stationInLine.StationId && stationInLine1.IsAvailableStationInLine))
                throw new DO.BadFirstIDSecondIDException(stationInLine.LineId, stationInLine.StationId, "station ID is already exists in line ID");

            ListAllStationsInLine.Add(stationInLine);

            XMLTOOLS.SaveListToXMLSerializer(ListAllStationsInLine, lineStationsPath);

        }


        public void UpdateStationInLine(DO.StationInLine stationInLine)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            int count = ListAllStationsInLine.RemoveAll(stationInLine1 => stationInLine1.StationId == stationInLine.StationId
                                                                   && stationInLine1.LineId == stationInLine.LineId);
            if (count == 0)
                throw new DO.BadFirstIDSecondIDException(stationInLine.LineId, stationInLine.StationId, " This   station in line  doesn't exists");
            AddStationInLine(stationInLine);
            XMLTOOLS.SaveListToXMLSerializer(ListAllStationsInLine, lineStationsPath);
        }

        public IEnumerable<DO.StationInLine> GetAllStationInLine()
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            return from stationInLine in ListAllStationsInLine
                   where stationInLine.IsAvailableStationInLine == true
                   select stationInLine;
        }

        // מחזירה תחנות קו של קו ספציפי
        public IEnumerable<DO.StationInLine> GetAllLineStationsInSpecificLine(int lineId)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);
            return from stationInLineD in ListAllStationsInLine
                   where stationInLineD.IsAvailableStationInLine && stationInLineD.LineId == lineId
                   select stationInLineD;
        }





        // מוחקת את כל התחנות קו של קו ספציפי
        public void DeleteLineStation1(int NumberLine)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);

            int index = ListAllStationsInLine.FindIndex(stationInLine => stationInLine.LineId == NumberLine && stationInLine.IsAvailableStationInLine);
            _ = index != -1
                ? ListAllStationsInLine.RemoveAll(item => item.LineId == NumberLine)
                : throw new DO.BadFirstIDSecondIDException(NumberLine, NumberLine, "the line isnt exist in the list!!!");
            XMLTOOLS.SaveListToXMLSerializer(ListAllStationsInLine, lineStationsPath);
        }


        public void DeleteStationInLine(int lineId, int stationId)
        {
            List<StationInLine> ListAllStationsInLine = XMLTOOLS.LoadListFromXMLSerializer<StationInLine>(lineStationsPath);


            DO.StationInLine stationInLine = ListAllStationsInLine.Find(p => p.LineId == lineId && p.StationId == stationId && p.IsAvailableStationInLine);

            if (stationInLine != null)
            {

                stationInLine.IsAvailableStationInLine = false;

            }
            else
            {
                // throw new DlExceptions("Sorry, This station in line doesn't exist");
                throw new DO.BadFirstIDSecondIDException(lineId, stationId, " station ID doesn't exists in line ID");
            }
            XMLTOOLS.SaveListToXMLSerializer(ListAllStationsInLine, lineStationsPath);
        }





        #endregion

        #region Adjacent Station

        public DO.AdjacentStations GetAdjacentStations(int id1, int id2)
        {
            List<AdjacentStations> ListAllAdjacentStations = XMLTOOLS.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);
            DO.AdjacentStations adjacentStations = ListAllAdjacentStations.Find(adjacentStations1 => adjacentStations1.StationId1 == id1 &&
                                                               adjacentStations1.StationId2 == id2);
            return adjacentStations ?? throw new DO.BadFirstIDSecondIDException(id1, id2, " This  adjacent stations doesn't exists");
        }

        public void AddAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            List<AdjacentStations> ListAllAdjacentStations = XMLTOOLS.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            if (!ListAllAdjacentStations.Exists(adjacentStations1 => adjacentStations1.StationId1 == adjacentStations.StationId1
                                                        && adjacentStations1.StationId2 == adjacentStations.StationId2))
            {
                ListAllAdjacentStations.Add(adjacentStations);

                XMLTOOLS.SaveListToXMLSerializer(ListAllAdjacentStations, adjacentStationsPath);
            }
                //throw new DO.BadFirstIDSecondIDException(adjacentStations.StationId1, adjacentStations.StationId2, "This adjacent stations already exists");

            

        }

        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            List<AdjacentStations> ListAllAdjacentStations = XMLTOOLS.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);
            int i = ListAllAdjacentStations.FindIndex(item => item.StationId1 == adjacentStations.StationId1 && item.StationId2 == adjacentStations.StationId2);
            if (i != -1)
            {
                ListAllAdjacentStations[i] = adjacentStations;
                XMLTOOLS.SaveListToXMLSerializer(ListAllAdjacentStations, adjacentStationsPath);
            }
            else
            {
                throw new DO.BadFirstIDSecondIDException(adjacentStations.StationId1, adjacentStations.StationId2, " This  adjacent stations doesn't exists");
            }
        }




        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            List<AdjacentStations> ListAllAdjacentStations = XMLTOOLS.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);
            return from adjacentStations in ListAllAdjacentStations
                   select adjacentStations;
        }








        #endregion

        #region Leaving Line

        public void AddLeavingLine(DO.LeavingLine leavingLine)
        {
            XElement leavingLineRootElem = XMLTOOLS.LoadListFromXMLElement(leavingLinesPath);

            XElement leavingLine1 = (from p in leavingLineRootElem.Elements()
                                     where p.Element("LineId").Value == leavingLine.LineId.ToString() && p.Element("StartingTime").Value == leavingLine.StartingTime.ToString()
                                            && p.Element("IsAvailableLeavingLine").Value == leavingLine.IsAvailableLeavingLine.ToString()
                                     select p).FirstOrDefault();
           
            if (leavingLine1 != null)
                throw new DO.BadFirstIDSecondTimeIDException(leavingLine.LineId, leavingLine.StartingTime, "Duplicate leavingLine ID");

            XElement leavingLine2 = new XElement("LeavingLine", new XElement("LineId", leavingLine.LineId),
                               new XElement("StartingTime", leavingLine.StartingTime.ToString()),
                               new XElement("IsAvailableLeavingLine", leavingLine.IsAvailableLeavingLine.ToString()));


            leavingLineRootElem.Add(leavingLine2);

            XMLTOOLS.SaveListToXMLElement(leavingLineRootElem, leavingLinesPath);
        }
        public void DeleteLeavingLine(int id, TimeSpan startingtime)
        {
                XElement leavingLineRootElem = XMLTOOLS.LoadListFromXMLElement(leavingLinesPath);

                LeavingLine leavingLine1 = (from p in leavingLineRootElem.Elements()
                                            where p.Element("LineId").Value == id.ToString() && p.Element("StartingTime").Value == startingtime.ToString()
                                            select new LeavingLine()
                                            {
                                                LineId = int.Parse(p.Element("LineId").Value),
                                                StartingTime = TimeSpan.ParseExact(p.Element("StartingTime").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture),
                                                IsAvailableLeavingLine = false
                                            }).FirstOrDefault();

                XElement leavingLine0 = (from po in leavingLineRootElem.Elements()
                                         where po.Element("LineId").Value == id.ToString() && po.Element("StartingTime").Value == startingtime.ToString()
                                         select po).FirstOrDefault();

                if (leavingLine0 != null)
                {
                    leavingLine0.Remove();
                    XMLTOOLS.SaveListToXMLElement(leavingLineRootElem, leavingLinesPath);
                    AddLeavingLine(leavingLine1);
                }
                else
                {
                    throw new DO.BadFirstIDSecondTimeIDException(id, startingtime, "This leaving Line  doesn't exists");
                }
        }

        //public void UpdatingLineExit(LineExit lineExit)
        //{
        //    XElement element = XMLTools.LoadListFromXMLElement(LineExitXml);
        //    XElement lineExit1 = (from p in element.Elements()
        //                          where p.Element("BusLineID1").Value == lineExit.BusLineID1.ToString() && p.Element("LineStartTime").Value == lineExit.LineStartTime.ToString()
        //                          select p).FirstOrDefault();

        //    if (lineExit1 != null)
        //    {
        //        lineExit1.Element("BusLineID1").Value = lineExit.BusLineID1.ToString();
        //        lineExit1.Element("LineStartTime").Value = lineExit.LineStartTime.ToString();
        //        lineExit1.Element("LineFinishTime").Value = lineExit.LineFinishTime.ToString();
        //        lineExit1.Element("LineFrequency").Value = lineExit.LineFrequency.ToString();
        //        lineExit1.Element("LineFrequencyTime").Value = lineExit.LineFrequencyTime.ToString();
        //        XMLTools.SaveListToXMLElement(element, LineExitXml);
        //    }

        //    else
        //    {
        //        throw new ExceptionLineExit(lineExit.BusLineID1, lineExit.LineStartTime, "The Exit not exist in the compny");
        //    }
        //}
        public DO.LeavingLine GetLeavingLine(int id, TimeSpan startingtime)
        {
            XElement leavingLineRootElem = XMLTOOLS.LoadListFromXMLElement(leavingLinesPath);
            LeavingLine leavingLine = (from p in leavingLineRootElem.Elements()
                                        where int.Parse(p.Element("LineId").Value) == id && p.Element("StartingTime").Value.ToString() == startingtime.ToString()
                                        select new LeavingLine()
                                        {
                                            IsAvailableLeavingLine = bool.Parse(p.Element("IsAvailableLeavingLine").Value),
                                            LineId = int.Parse(p.Element("LineId").Value),
                                            StartingTime = TimeSpan.ParseExact(p.Element("StartingTime").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                                        }).FirstOrDefault();

            return leavingLine ?? throw new DO.BadFirstIDSecondTimeIDException(id, startingtime, "This leaving Line  doesn't exists");
        }
        
        public IEnumerable<DO.LeavingLine> GetAllLeavingLines()
        {
            XElement leavingLineRootElem = XMLTOOLS.LoadListFromXMLElement(leavingLinesPath);
            return from p in leavingLineRootElem.Elements()
                    where bool.Parse(p.Element("IsAvailableLeavingLine").Value)
                    select new LeavingLine()
                    {
                        LineId = int.Parse(p.Element("LineId").Value),
                        StartingTime = TimeSpan.ParseExact(p.Element("StartingTime").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture),
                        IsAvailableLeavingLine = bool.Parse(p.Element("IsAvailableLeavingLine").Value),
                    };         
        }

        public IEnumerable<DO.LeavingLine> GetAllLeavingLinesInSpecificLine(int id)
        {
            XElement leavingLineRootElem = XMLTOOLS.LoadListFromXMLElement(leavingLinesPath);
            return from p in leavingLineRootElem.Elements()
                   where bool.Parse(p.Element("IsAvailableLeavingLine").Value) && int.Parse(p.Element("LineId").Value) == id
                   select new LeavingLine()
                   {
                       IsAvailableLeavingLine = bool.Parse(p.Element("IsAvailableLeavingLine").Value),
                       LineId = int.Parse(p.Element("LineId").Value),
                       StartingTime = TimeSpan.ParseExact(p.Element("StartingTime").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                   };
        }
        #endregion

        #region Bus On Trip


        #endregion Bus On Trip
    }
}