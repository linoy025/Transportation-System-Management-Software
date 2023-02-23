using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLApi
{
    public interface IBL
    {

        #region AdjacentStations

        void AddAdjacentStations(BO.AdjacentStations adjacentStations);

        void UpdateAdjacentStations(BO.AdjacentStations adjacentStations);
 
       // void DeleteAdjacentStations(int id1, int id2);
        IEnumerable<BO.AdjacentStations> GetAllAdjacentStations();

        BO.AdjacentStations adjacentStationDoBoAdapter(DO.AdjacentStations adjacentStationsDO);
        BO.AdjacentStations GetAdjacentStations(int id1, int id2);

        //void UpdateAdjacentStations(int id1, int id2, Action<AdjacentStations> update); 
        //IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        #endregion

        #region Bus
        void AddBus(BO.Bus bus);
        void UpdateBus(BO.Bus bus);
        void DeleteBus(int id);
        BO.Bus GetBus(int id);
        IEnumerable<BO.Bus> GetAllBuses();

        BO.Bus busDoBoAdapter(DO.Bus busDO);

        // IEnumerable<Bus> GetAllBusesBy(Predicate<Bus> predicate);
        //void UpdateBus(int id, Action<Bus> update); 
        #endregion Bus

        #region LeavingLine
        void AddLeavingLine(BO.LeavingLine leavingLine);
        //void UpdateLeavingLine(BO.LeavingLine leavingLine);
        void DeleteLeavingLine(int id, TimeSpan startingtime);
        BO.LeavingLine GetLeavingLine(int id, TimeSpan startingtime);
         IEnumerable<BO.LeavingLine> GetAllLeavingLines();

        IEnumerable<BO.LeavingLine> GetAllLeavingLinesInSpecificLine(int id);

        IEnumerable<BO.HelpLineTrip> HelpCalculateArrivingTimeToStation(int id, int NumberStation, TimeSpan timeSpan1);
        IEnumerable<BO.LineTrip> DigitalPanel(int NumberStation, TimeSpan timeSpan);


        //void UpdateLeavingLine(int id, Action<LeavingLine> update);
        //IEnumerable<LeavingLine> GetAllLeavingLinesBy(Predicate<LeavingLine> predicate);


        #endregion

        #region Line
        void AddLine(BO.Line line);
        void UpdateLine(BO.Line line);
        void DeleteLine(int id);
        IEnumerable<int> GetAllLines();
        BO.Line GetLine(int id);

        IEnumerable<BO.Line> GetAllLinesInSpecificStation(int stationId);


        //IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        //void UpdateLine(int id, Action<Line> update);

        #endregion

        #region StationLine
        IEnumerable<BO.StationLine> StationLineList(int IdLine);
         void AddStationLine(BO.StationLine stationLine);
        //void UpdateStationInLine(BO.StationLine stationLine);
        void DeleteStationLine(int lineId, int stationId);
        IEnumerable<BO.StationLine> GetAllStationLine();
        BO.StationLine GetStationLine(int lineId, int stationId);

       int GetNumberStationLine(int lineId);

        //IEnumerable<StationInLine> GetAllStationInLineBy(Predicate<StationInLine> predicate);
        //void UpdateStationInLine(int id, Action<StationInLine> update);

        #endregion

        #region Station
        void AddStation(BO.Station station);
       void UpdateStation(BO.Station station);
        void DeleteStation(int id);

        IEnumerable<BO.Station> GetAllStationInSpecificLine(int lineId);

        //IEnumerable<BO.Station> GetAllStationNotInSpecificLine(int lineId);
  
        IEnumerable<int> GetAllStations();
        //public IEnumerable<BO.Station> GetAllStations();
        BO.Station GetStation(int id);



        //IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        //void UpdateStation(int id, Action<Station> update);

        #endregion

        #region User
        void AddUser(BO.User user);
        void DeleteUser(string userName);
        //void UpdateUser(User user);
        BO.User GetUser(string userName);
        IEnumerable<BO.User> GetAllUsers();

        // IEnumerable<User> GetAllUsersBy(Predicate<User> predicate);
        //void UpdateUser(int id, Action<User> update);
        #endregion User

        #region BusOnTrip
        //  //void AddBusOnTrip(BO.BusOnTrip busOnTrip);
        //  ////void UpdateBusOnTrip(BusOnTrip busOnTrip);
        //  //void DeleteBusOnTrip(int id);
        //  ////BusOnTrip GetBusOnTrip(int id);
        //  ////IEnumerable<BusOnTrip> GetAllBusesOnTrip();

        //  //// IEnumerable<BusOnTrip> GetAllBusesOnTripBy(Predicate<BusOnTrip> predicate);   
        //  ////void UpdateBusOnTrip(int id, Action<BusOnTrip> update); 

        #endregion BusOnTrip


    }
}




    