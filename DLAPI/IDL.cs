using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DLAPI
{
    //CRUD Logic
    public interface IDL
    {
        #region AdjacentStations

        void AddAdjacentStations(AdjacentStations adjacentStations);
        void UpdateAdjacentStations(AdjacentStations adjacentStations);
        //void DeleteAdjacentStations(int id1, int id2);
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
       AdjacentStations GetAdjacentStations(int id1 , int id2);

         //IEnumerable<AdjacentStations> GetAllLineAdjacentStationsInSpecificLine(int lineId);

        //void UpdateAdjacentStations(int id1, int id2, Action<AdjacentStations> update); 
        //IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        #endregion

        #region Bus
        void AddBus(Bus bus);
        void UpdateBus(Bus bus);
        void DeleteBus(int idl);
        Bus GetBus(int id);
        IEnumerable <Bus> GetAllBuses();

        // IEnumerable<Bus> GetAllBusesBy(Predicate<Bus> predicate);
        //void UpdateBus(int id, Action<Bus> update); 
        #endregion Bus

        #region LeavingLine
        void AddLeavingLine(LeavingLine leavingLine);
        // void UpdateLeavingLine(LeavingLine leavingLine);
        void DeleteLeavingLine(int id, TimeSpan startingtime);
         LeavingLine GetLeavingLine(int id, TimeSpan startingtime);
        IEnumerable<LeavingLine> GetAllLeavingLines();

        IEnumerable<LeavingLine> GetAllLeavingLinesInSpecificLine(int id);

        //void UpdateLeavingLine(int id, Action<LeavingLine> update);
        //IEnumerable<LeavingLine> GetAllLeavingLinesBy(Predicate<LeavingLine> predicate);


        #endregion

        #region Line
        int AddLine(Line line);
        void UpdateLine(Line line);
        void DeleteLine(int id);
        IEnumerable<Line> GetAllLines();
        IEnumerable<StationInLine> GetAllLineStationsInSpecificLine(int lineId);

      
        //IEnumerable<AdjacentStations> GetAllAdjacentStationsInSpecificLine(int lineId);
        Line GetLine(int id);

        //IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        //void UpdateLine(int id, Action<Line> update);

        #endregion

        #region StationInLine

        int GetNumberStationLine(int lineId);
        void AddStationInLine(StationInLine stationInLine);
        void UpdateStationInLine(StationInLine stationInLine);
        void DeleteStationInLine(int lineId, int stationId);
        IEnumerable<StationInLine> GetAllStationInLine();       
        StationInLine GetStationInLine(int lineId, int stationId);

        void DeleteLineStation1(int NumberLine);

        //IEnumerable<StationInLine> GetAllStationInLineBy(Predicate<StationInLine> predicate);
        //void UpdateStationInLine(int id, Action<StationInLine> update);

        #endregion

        #region Station
        void AddStation(Station station);
        void UpdateStation(Station station);
        void DeleteStation(int id);
        IEnumerable<Station> GetAllStations();
        IEnumerable<Line> GetAllLinesInSpecificStation(int stationId);

        IEnumerable<Station> GetAllStationInSpecificLine(int lineId);

        //IEnumerable<Station> GetAllStationNotInSpecificLine(int lineId);
        Station GetStation(int id);

        //IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        //void UpdateStation(int id, Action<Station> update);

        #endregion

        //#region BusOnTrip
        //void AddBusOnTrip(BusOnTrip busOnTrip);
        //void UpdateBusOnTrip(BusOnTrip busOnTrip);
        //void DeleteBusOnTrip(int id);
        //BusOnTrip GetBusOnTrip(int id);
        //IEnumerable<BusOnTrip> GetAllBusesOnTrip();

        //// IEnumerable<BusOnTrip> GetAllBusesOnTripBy(Predicate<BusOnTrip> predicate);   
        ////void UpdateBusOnTrip(int id, Action<BusOnTrip> update); 

        //#endregion BusOnTrip

        #region User
        void AddUser(User user);
        void DeleteUser(string userName);
        void UpdateUser(User user);
        User GetUser(string userName);
        IEnumerable<User> GetAllUsers();

        // IEnumerable<User> GetAllUsersBy(Predicate<User> predicate);
        //void UpdateUser(int id, Action<User> update);
        #endregion User


    }
}

