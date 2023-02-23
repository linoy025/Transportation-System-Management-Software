using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public static class DataSource
    {

        public static Random r = new Random();
     
        public static List<Station> ListAllStations; // 
        public static List<AdjacentStations> ListAllAdjacentStations; //
        public static List<Line> ListAllLines; //
        public static List<StationInLine> ListAllStationsInLine; //
        public static List<Bus> ListAllBuses;//
        public static List<User> ListAllUsers;//
        public static List<Admin> ListAllAdmins;//


        public static List<LeavingLine> ListAllLeavingLines;
        public static List<BusOnTrip> ListAllBusesOnTrip;
        
        static DataSource()
        {
            ListAllBuses = new List<Bus>();
            InitAllLists();
        }

        static void InitAllLists()
        {
            ListAllLeavingLines = new List<LeavingLine>
            {
                  #region line 480/1 schedules
                  new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(06, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(06, 30, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(07, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                        new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(07, 30, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(08, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(08, 30, 00),
                    IsAvailableLeavingLine = true
                   },

                        new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(09, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(09, 30, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 1,
                    StartingTime = new TimeSpan(10, 00, 00),
                    IsAvailableLeavingLine = true
                   },
#endregion

                #region line 480/2 schedules
                new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(06, 15, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(06, 45, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(07, 15, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(07, 45, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(08, 15, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(08, 45, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(09, 15, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(09, 45, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 2,
                    StartingTime = new TimeSpan(10, 15, 00),
                    IsAvailableLeavingLine = true
                   },
#endregion

                #region line 20 schedules
                new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(05, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(06, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                           new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(07, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(08, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                  new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(09, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(10, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(11, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(12, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(13, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 3,
                    StartingTime = new TimeSpan(14, 00, 00),
                    IsAvailableLeavingLine = true
                   },
#endregion

                #region line 68 schedules
                new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(09, 10, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(10, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                           new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(11, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(12, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                  new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(13, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(14, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(15, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(16, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(17, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 4,
                    StartingTime = new TimeSpan(18, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    #endregion

                #region line 551 schedules
                new LeavingLine
                   {
                    LineId = 5,
                    StartingTime = new TimeSpan(08, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 5,
                    StartingTime = new TimeSpan(12, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 5,
                    StartingTime = new TimeSpan(16, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 5,
                    StartingTime = new TimeSpan(20, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                    #endregion

                #region line 1 schedules
                new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(06, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                     new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(06, 12, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(06, 24, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(06, 36, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(06, 48, 00),
                    IsAvailableLeavingLine = true
                   },


                   new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(07, 00, 00),
                    IsAvailableLeavingLine = true
                   },

                     new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(07, 12, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(07, 24, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(07, 36, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(07, 48, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(08, 00, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(08, 12, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(08, 24, 00),
                    IsAvailableLeavingLine = true
                   },

                     new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(08, 36, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(08, 48, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 6,
                    StartingTime = new TimeSpan(09, 00, 00),
                    IsAvailableLeavingLine = true
                   },
#endregion

                #region line 82 schedules
                new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(09, 15, 00),
                    IsAvailableLeavingLine = true
                   },

                   new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(10, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                           new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(11, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(12, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                  new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(13, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(14, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(15, 10, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(16, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(17, 15, 00),
                    IsAvailableLeavingLine = true
                   },

                    new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(18, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                   new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(19, 15, 00),
                    IsAvailableLeavingLine = true
                   },
                    new LeavingLine
                   {
                    LineId = 7,
                    StartingTime = new TimeSpan(20, 15, 00),
                    IsAvailableLeavingLine = true
                   },
#endregion

                #region line 4 schedules

                new LeavingLine
            {
                LineId = 8,
                StartingTime = new TimeSpan(00, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 8,
                StartingTime = new TimeSpan(00, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 8,
                StartingTime = new TimeSpan(01, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 8,
                StartingTime = new TimeSpan(01, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 8,
                StartingTime = new TimeSpan(02, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 8,
                StartingTime = new TimeSpan(02, 30, 00),
                IsAvailableLeavingLine = true
            },


            #endregion

            #region line 3 schedules
            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(07, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(08, 45, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(10, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(12, 15, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(13, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(14, 45, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(16, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(18, 15, 00),
                IsAvailableLeavingLine = true
            },


            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(19, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 9,
                StartingTime = new TimeSpan(21, 15, 00),
                IsAvailableLeavingLine = true
            },
            #endregion

            #region line 58 schedules
            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(09, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(10, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(11, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(12, 30, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(13, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(14, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(15, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(16, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(17, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(18, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(19, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(20, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(21, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 10,
                StartingTime = new TimeSpan(22, 00, 00),
                IsAvailableLeavingLine = true
            },
            #endregion

            #region line 50 schedules
            new LeavingLine
            {
                LineId = 11,
                StartingTime = new TimeSpan(10, 20, 00),
                IsAvailableLeavingLine = true
            },


            new LeavingLine
            {
                LineId = 11,
                StartingTime = new TimeSpan(12, 20, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 11,
                StartingTime = new TimeSpan(14, 20, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 11,
                StartingTime = new TimeSpan(16,20, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 11,
                StartingTime = new TimeSpan(18, 20, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 11,
                StartingTime = new TimeSpan(20, 20, 00),
                IsAvailableLeavingLine = true
            },
            #endregion


            #region line 541 schedules
            new LeavingLine
            {
                LineId = 12,
                StartingTime = new TimeSpan(07, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 12,
                StartingTime = new TimeSpan(10, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 12,
                StartingTime = new TimeSpan(13, 00, 00),
                IsAvailableLeavingLine = true
            },

            #endregion

            #region line 464 schedules
            new LeavingLine
            {
                LineId = 13,
                StartingTime = new TimeSpan(12, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 13,
                StartingTime = new TimeSpan(16, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 13,
                StartingTime = new TimeSpan(19, 00, 00),
                IsAvailableLeavingLine = true
            },

            new LeavingLine
            {
                LineId = 13,
                StartingTime = new TimeSpan(22, 00, 00),
                IsAvailableLeavingLine = true
            },

            #endregion

            };

            ListAllStations = new List<Station>
            {

                #region 480 - Jerusalem -> Tel-Aviv

                //new Station
                //{
                //    StationId = 4170,
                //    Logtitude = 35.203715,
                //    Latitude = 31.789467,
                //    StationName = "Jerusalem Central Station 3rd Floor/Docks",
                //    StationAddress = "199 Jaffa Street, Jerusalem",
                //    IsAvailableStation =true

                //},

                 new Station
                 {
                     StationId = 638,
                     Logtitude = 35.12454,
                     Latitude = 31.801002,
                     StationName = "Hemed Interchange",
                     StationAddress = "Hemed Interchange,Mate Yehuda",
                     IsAvailableStation =true

                 },
                 new Station
                 {
                     StationId = 20178,
                     Logtitude = 34.795334,
                     Latitude = 32.083251,
                     StationName = "Tel Aviv Merkaz train station/Alighting",
                     StationAddress = "Al Parashat Drachim, Tel-Aviv-Jaffa",
                      IsAvailableStation =true
                 },
                  #endregion
                  
                #region 480 - Tel-Aviv -> Jerusalem
                 
                new Station
                {
                    StationId = 20001,
                    Logtitude = 34.796091,
                    Latitude = 32.083157,
                    StationName = "Tel Aviv Merkaz station",
                    StationAddress = "Eilat",
                     IsAvailableStation =true

                },



                new Station
                {
                    StationId =640,
                    Logtitude = 35.126238,
                    Latitude = 31.80033,
                    StationName = "Hemed Interchange",
                    StationAddress = "Exit to Road 1 City/Mateh Yehuda",
                     IsAvailableStation =true

                },

                 new Station
                {
                    StationId = 5602,
                    Logtitude = 35.145723,
                    Latitude = 31.798621,
                    StationName = "Har'el interchange",
                    StationAddress = " Exit to Road 1/Mevaseret Zion",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 4170,
                    Logtitude = 35.203715,
                    Latitude = 31.789467,
                    StationName = "Jerusalem Central Station 3rd Floor/Docks",
                    StationAddress = "199 Jaffa Street, Jerusalem",
                     IsAvailableStation =true

                },

                #endregion

                #region 20 - Netanya Central Station/Platforms ‎→ Netanya Central Station/Unloading - Circular route
                 
                new Station
                {
                    StationId = 30136,
                    Logtitude = 34.85874,
                    Latitude = 32.326889,
                    StationName = "Netanya Central Station/Platforms",
                    StationAddress = " Pinsker Street/Netanya",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 30279,
                    Logtitude = 34.889178,
                    Latitude = 32.323745,
                    StationName = "Sha'ar Hefer Junction",
                    StationAddress = "Derech Hasharon 1 Street/ Beit Yitzhak Sha'ar Hefer",
                     IsAvailableStation =true

                },

                 new Station
                {
                    StationId = 30297,
                    Logtitude = 34.893202,
                    Latitude = 32.342733,
                    StationName = "Hefer Road/Sha'ar HaKfar",
                    StationAddress = "Derech Hefer 29 Street, Beit Yitzhak Sha'ar Hefer",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 37837,
                    Logtitude = 34.907167,
                    Latitude = 32.35688,
                    StationName = "HaOgen Junction",
                    StationAddress = "5700 Street, Emek Hefer",
                     IsAvailableStation =true

                },

                  new Station
                {
                    StationId = 30434,
                    Logtitude = 34.911999,
                    Latitude = 32.393824,
                    StationName = "Hibat Tsiyon Junction",
                    StationAddress = "581 Street, Kfar Haroeh",
                     IsAvailableStation =true

                },

                 new Station
                {
                    StationId = 39582,
                    Logtitude = 35.145723,
                    Latitude = 31.798621,
                    StationName = "Cultural Center",
                    StationAddress = "Genesis 44 Street",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 30787,
                    Logtitude = 35.013347,
                    Latitude = 32.350537,
                    StationName = "Bahan Junction",
                    StationAddress = "5714 Street,Emek Hefer",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 30734,
                    Logtitude = 34.986256,
                    Latitude = 32.3122,
                    StationName = "Be'erotayim Junction",
                    StationAddress = " 57 Street, Lev Hasharon",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 30515,
                    Logtitude = 34.924121,
                    Latitude = 32.321476,
                    StationName = "Camp 21 Junction",
                    StationAddress = "Ha'atzmaut 5 Street, Kfar Yona",
                     IsAvailableStation =true

                },


                new Station
                {
                    StationId = 39524,
                    Logtitude = 34.874173,
                    Latitude = 32.324396,
                    StationName = "Neve Itamar Junction",
                    StationAddress = "Jordan Road Street, Netanya",
                     IsAvailableStation =true

                },

                new Station
                {
                    StationId = 39522,
                    Logtitude = 34.85839,
                    Latitude = 32.327128,
                    StationName = "Netanya Central Station/Unloading",
                    StationAddress = "Pinsker Street, Netanya",
                     IsAvailableStation =true

                },
                 #endregion
                
                #region 68  - The Hebrew University/Churchill Blvd -> The National Library
                new Station
                {
                StationId = 1431,
                Logtitude = 35.241777,
                Latitude = 31.796261,
                StationName = "The Hebrew University/Churchill Blvd",
                StationAddress = "Churchill Blvd,Jerusalem",
                 IsAvailableStation =true
                },

                 new Station
                 {
                     StationId = 3850,
                     Logtitude = 35.236591,
                     Latitude = 31.803953,
                     StationName = "HaHagana/Etzel",
                      StationAddress = "5 HaHagana Street,Jerusalem",
                       IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 6066,
                     Logtitude = 35.229801,
                     Latitude = 31.804272,
                     StationName = "Sheshet HaYamim",
                      StationAddress = "31 Sheshet HaYamim,Jerusalem ",
                       IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 4012,
                     Logtitude = 35.218752,
                     Latitude = 31.795253,
                     StationName = "Bar Ilan/Shmu'el HaNavi",
                      StationAddress = "10 Bar Ilan,Jerusalem",
                       IsAvailableStation =true
                 },

                 new Station
                 {
                     StationId = 5949,
                     Logtitude = 35.203674,
                     Latitude = 31.788746,
                      StationName = "Jerusalem Central Station/Yafo(A3)",
                      StationAddress = "224 Yafo,Jerusalem",
                       IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =1540,
                     Logtitude = 35.199372,
                     Latitude = 31.787317,
                     StationName = "Gesher Hameitarim/Herzl Blvd",
                      StationAddress = "4 Herzl Blvd, Jerusalem",
                       IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 3099,
                     Logtitude = 35.199962,
                     Latitude = 31.783621,
                     StationName = "Government Complex/Lorch",
                      StationAddress = "Nathaniel Lorch, Jerusalem",
                       IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =9915,
                     Logtitude = 35.198681,
                     Latitude = 31.779911,
                     StationName = "HaJoint/Balfour Road",
                      StationAddress = "Eliezer Kaplan, Jerusalem",
                       IsAvailableStation =true
                 },

                 new Station
                 {
                     StationId =4190,
                     Logtitude = 35.196199,
                     Latitude = 31.779177,
                      StationName = "Safra Campus/Wise Auditorium",
                      StationAddress = "Balfour Road, Jerusalem",
                       IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 3609,
                     Logtitude = 35.195398,
                     Latitude = 31.7758,
                     StationName = "The National Library",
                      StationAddress = "Balfour Road, Jerusalem",
                       IsAvailableStation =true
                 },
                   #endregion

                #region 551 - Petah Tikva -> Herzliya

                new Station
                {
                    StationId = 35377,
                    Logtitude = 34.863805,
                    Latitude = 32.106362,
                    StationName = "Kiryat Arye Railway Station",
                    StationAddress = "Petah Tikva",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 36899,
                     Logtitude = 34.877315,
                     Latitude = 32.091631,
                     StationName = "Orlov/Krol",
                     StationAddress = "Zeev Orlov 8 Street, Petah Tikva",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 39686,
                     Logtitude = 34.903897,
                     Latitude = 32.12281,
                     StationName = "Yarkon Interchange",
                     StationAddress = "40 Road, Petah Tikva",
                      IsAvailableStation =true

                 },

                new Station
                {
                    StationId =37174,
                    Logtitude = 34.894726,
                    Latitude = 32.14721,
                    StationName = "Yarkona Junction",
                    StationAddress = "115 Ramtaim Road Street, Hod Hasharon",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 35946,
                     Logtitude = 34.893876,
                     Latitude = 32.168135,
                     StationName = "Ein Hai/HaMeyasdim",
                     StationAddress = "Ein Hai 26 Street, Kfar Malal",
                      IsAvailableStation =true

                 },

                new Station
                 {
                     StationId = 37060,
                     Logtitude = 34.88064,
                     Latitude = 32.17926,
                     StationName = "Ahuza/Bialik",
                     StationAddress = " Ahuza 66 Street, Raanana",
                      IsAvailableStation =true

                 },



                new Station
                {
                    StationId = 36614,
                    Logtitude = 34.863588,
                    Latitude = 32.183043,
                    StationName = "Ahuza/Migdal",
                    StationAddress = "Ahuza 210 Street,Raanana",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 26910,
                     Logtitude = 34.851892,
                     Latitude = 32.172463,
                     StationName = "Yerushalayim/Har Sinai",
                     StationAddress = "Jerusalem Road Street, Herzliya",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 26895,
                     Logtitude = 34.841745,
                     Latitude = 32.16117,
                     StationName = "HaRav Kook/Ben Gurion",
                     StationAddress = "Harav Kook 10 Street, Herzliya",
                      IsAvailableStation =true

                 },

                   new Station
                 {
                     StationId = 20167,
                     Logtitude = 34.819187,
                     Latitude = 32.164439,
                     StationName = "Ben Zion Micha'eli/HaRakevet",
                     StationAddress = "Ben Zion Michaeli Street, Herzliya",
                      IsAvailableStation =true

                 },
                      #endregion
                   

                #region 1 - Technion/Hasenat Dormitories ‎→ Hof HaKarmel Central Station/Unloading

                new Station
                {
                    StationId = 41200,
                    Logtitude = 35.020041,
                    Latitude = 32.776736,
                    StationName = "Technion/Hasenat Dormitories",
                    StationAddress = "Sderot David Rose Street, Haifa",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 41205,
                     Logtitude = 35.025582,
                     Latitude = 32.774777,
                     StationName = "Technion/Material engineering",
                     StationAddress =  "Sderot David Rose Street, Haifa",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 43073,
                     Logtitude = 35.028477,
                     Latitude = 32.777223,
                     StationName = "Technion/Biotechnology and Food",
                     StationAddress = "Sderot David Rose Street, Haifa",
                      IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 43022,
                    Logtitude = 35.021166,
                    Latitude = 32.779897,
                    StationName = "Technion/Civil Engineering",
                    StationAddress =  "Sderot David Rose Street, Haifa",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 43015,
                     Logtitude = 35.019648,
                     Latitude = 32.77895,
                     StationName = "Technion/Sports Building",
                     StationAddress =  "Derech Yaakov Dori Street, Haifa",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 42335,
                     Logtitude = 35.013969,
                     Latitude = 32.779816,
                     StationName = "Malal/Komoly",
                     StationAddress = "MLL 3 Street, Haifa",
                      IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 41209,
                    Logtitude = 35.017412,
                    Latitude = 32.784852,
                    StationName = "Trumpeldor/David Square",
                    StationAddress = "27 Trumpeldor Blvd Street, Haifa",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 42506,
                     Logtitude = 34.965229,
                     Latitude = 32.790444,
                     StationName = "Congress Center/Fliman",
                     StationAddress = "Derech Moshe Fliman Street, Haifa",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 42501,
                     Logtitude = 34.958675,
                     Latitude = 32.790898,
                     StationName = "Saharov",
                     StationAddress = "Andrei Sakharov Street, Haifa",
                      IsAvailableStation =true

                 },

                   new Station
                   {
                     StationId = 42657,
                     Logtitude = 34.959587,
                     Latitude = 32.793368,
                     StationName = "Hof HaKarmel Central Station/Unloading",
                     StationAddress = "Central Station, Haifa",
                      IsAvailableStation =true

                    },
                      #endregion
                 
                #region 82 -Kfar Sava ‎→ Karne Shomron

                new Station
                {
                    StationId = 37135,
                    Logtitude = 34.891979,
                    Latitude = 32.175709,
                    StationName = "Court House/Tchernichovsky",
                    StationAddress = "Tchernichovsky 2 Street, Kfar Saba",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 37027,
                     Logtitude = 34.899708,
                     Latitude = 32.177199,
                     StationName = "Weizmann/Gordon",
                     StationAddress =  "Weizmann 30 Street, Kfar Saba",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 37033,
                     Logtitude = 34.909611,
                     Latitude = 32.174907,
                     StationName = "Weizmann/Rothschild",
                     StationAddress = "Weizmann 122 Street, Kfar Saba",
                      IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 39794,
                    Logtitude = 34.917442,
                    Latitude = 32.167612,
                    StationName = "Kefar Saba Nordau Train Station",
                    StationAddress =  "Train Station, Kefar Saba",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 39791,
                     Logtitude = 34.92668,
                     Latitude = 32.170317,
                     StationName = "G Mall Kfar Saba ",
                     StationAddress =  "Weizmann Street, Kfar Saba",
                      IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 63180,
                     Logtitude = 35.072021,
                     Latitude = 32.168286,
                     StationName = "Ma'ale Shomron Industrial Zone",
                     StationAddress = "Ma'ale Shomron",
                      IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 61211,
                    Logtitude = 35.078966,
                    Latitude = 32.171137,
                    StationName = "HaGefen/HaHadas",
                    StationAddress = "Hagefen 50 Street, Karne Shomron",
                     IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 65287,
                     Logtitude = 35.083495,
                     Latitude = 32.16696,
                     StationName = "Alon/HaSavyon Alley",
                     StationAddress = "Alon 54 Street, Karne Shomron",
                     IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 63188,
                     Logtitude = 35.085469,
                     Latitude = 32.170855,
                     StationName = "Alon/Nitsanim",
                     StationAddress = "Alon 13 Street, Karne Shomron",
                     IsAvailableStation =true
                 },

                new Station
                {
                    StationId = 65268,
                    Logtitude = 35.093854,
                    Latitude = 32.175203,
                    StationName = "Rehav'am Boulevard/Karne Shomron",
                    StationAddress =  "Rehav'am Boulevard, Karne Shomron",
                    IsAvailableStation =true
                },

                new Station
                 {
                     StationId = 63203,
                     Logtitude = 35.106944,
                     Latitude = 32.168782,
                     StationName = "Kle Shir/HaPa'amon",
                     StationAddress = "Kle Shir 29 Street, Karne Shomron",
                     IsAvailableStation =true

                 },

                new Station
                   {
                     StationId = 63206,
                     Logtitude = 34.959587,
                     Latitude = 32.793368,
                     StationName = "Pais Youth Club",
                     StationAddress = "Hagitit Street, Karne Shomron",
                     IsAvailableStation =true

                    },

                      #endregion

                  
                #region 4 - HaTayasim Terminal ‎→ Reading

                new Station
                {
                    StationId = 21486,
                    Logtitude = 34.813795,
                    Latitude = 32.049042,
                    StationName = "HaTayasim Terminal",
                    StationAddress = "Pilots Road Street,Tel Aviv-Yafo",
                    IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 21437,
                     Logtitude = 34.899708,
                     Latitude = 32.177199,
                     StationName = "Bar Lev Road/Sheshet HaYamim Blvd",
                     StationAddress =  "Derech Chaim Barlev 197 Street,Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 21574,
                     Logtitude = 34.800032,
                     Latitude = 32.046839,
                     StationName = "Bar Lev Road/Moshe Dayan Road",
                     StationAddress = "Derech Chaim Barlev 111 Street,Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 25663,
                    Logtitude = 34.791655,
                    Latitude = 32.051239,
                    StationName = "Etzel/Hanuch",
                    StationAddress =  "Etchel 49 Street, Tel Aviv-Yafo",
                    IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 25402,
                     Logtitude = 34.774542,
                     Latitude = 32.059067,
                     StationName = "Levinsky/Ha'Aliya",
                     StationAddress =  "Lewinsky 69 Street, Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 23021,
                     Logtitude = 34.771697,
                     Latitude = 32.066605,
                     StationName = "Allenby/Mazeh",
                     StationAddress = "79 Allenby Street, Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 21539,
                    Logtitude = 34.768438,
                    Latitude = 32.073312,
                    StationName = "Ben Yehuda/Allenby",
                    StationAddress = "Ben Yehuda 2 Street,Tel Aviv-Yafo",
                    IsAvailableStation =true

                },

                 new Station
                 {
                     StationId = 23004,
                     Logtitude = 34.770132,
                     Latitude = 32.080352,
                     StationName = "Ben Yehuda/Frishman",
                     StationAddress = "76 Ben Yehuda Street,Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                 new Station
                 {
                     StationId = 23001,
                     Logtitude = 34.773359,
                     Latitude = 32.087763,
                     StationName = "Ben Yehuda/Arlozorov",
                     StationAddress =  "178 Ben Yehuda Street,Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 22999,
                    Logtitude = 34.775016,
                    Latitude = 32.093349,
                    StationName = "Ben Yehuda/Nordau Blvd",
                    StationAddress =  "240 Ben Yehuda Street,Tel Aviv-Yafo",
                    IsAvailableStation =true

                },

                new Station
                 {
                     StationId = 27246,
                     Logtitude = 34.776059,
                     Latitude = 32.096391,
                     StationName = "Dizengoff/Ben Yehuda",
                     StationAddress = "Dizengoff 330 Street, Tel Aviv-Yafo",
                     IsAvailableStation =true

                 },

                new Station
                {
                    StationId = 22927,
                    Logtitude = 34.77995,
                    Latitude = 32.098886,
                    StationName = "Reading",
                    StationAddress = "Reading, Tel Aviv-Yafo",
                    IsAvailableStation =true

                },

                      #endregion

               
                #region 3-Kiryat Malakhi->Malakhi Junction
                 new Station
                 {
                     StationId =15897,
                     Logtitude = 34.738631,
                     Latitude = 31.735669,
                     StationName = "Stadium/Herzl",
                      StationAddress = "70 Herzl,Kiryat Malakhi",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =19516,
                     Logtitude = 34.73991,
                     Latitude = 31.73541,
                     StationName = "Weizmann/Bar Yehuda",
                      StationAddress = "37 Weizmann Blvd,Kiryat Malakhi",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =10720,
                     Logtitude = 34.743587,
                     Latitude = 31.725972,
                     StationName = "Yerushalayim Boulevard/Jabotinsky",
                      StationAddress = "5 Yerushalayim Boulevard,Kiryat Malakhi",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =14831,
                     Logtitude = 34.745021,
                     Latitude = 31.726872,
                     StationName = "Jabotinsky/David Razi'el",
                      StationAddress = "8 Jabotinsky,Kiryat Malakhi",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =14827,
                     Logtitude = 34.746559,
                     Latitude = 31.729869,
                     StationName = "Jabotinsky/David Ben Gurion Blvd",
                      StationAddress = "Jabotinsky,Kiryat Malakhi",
                      IsAvailableStation =true
                 },




                 new Station
                 {
                     StationId =14836,
                     Logtitude = 34.747204,
                     Latitude = 31.731415,
                     StationName = "Jabotinsky/HaGalil",
                      StationAddress = "61 Jabotinsky,Kiryat Malakhi",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =15231,
                     Logtitude = 34.747561,
                     Latitude = 31.734123,
                     StationName = "Jabotinsky/Hacarmel",
                      StationAddress = "60 Jabotinsky,Kiryat Malakhi",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =19385,
                     Logtitude = 34.755354,
                     Latitude = 31.734424,
                     StationName = "Haharoshet/Halutse HaTa'asiya",
                      StationAddress = "9 Haharoshet,Kiryat Malakhi",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =11219,
                     Logtitude = 34.752588,
                     Latitude = 31.731453,
                     StationName = "Menachem Begin/Sha'ar Ha'Ir",
                      StationAddress = "11 Menachem Begin Blvd,Kiryat Malakhi",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =11168,
                     Logtitude = 34.756392,
                     Latitude = 31.731452,
                     StationName = "Malakhi Junction",
                      StationAddress = "Beer Tuvia city",
                      IsAvailableStation =true
                 },
                 #endregion

                #region 58-Givata'yim->Ramat Gan
                 new Station
                 {
                     StationId =26156,
                     Logtitude = 34.816488,
                     Latitude = 32.059937,
                     StationName = "Korazin",
                      StationAddress = "6 Korazin,Givata'yim",
                      IsAvailableStation =true
                 },

                 new Station
                 {
                     StationId =26158,
                     Logtitude = 34.818635,
                     Latitude = 32.061674,
                     StationName = "HaRav Herzog/Tabenkin",
                      StationAddress = "38 HaRav Herzog,Givata'yim",
                      IsAvailableStation =true
                 },

                 new Station
                 {
                     StationId =26084,
                     Logtitude = 34.814362,
                     Latitude = 32.062937,
                     StationName = "Yigal Alon School/Rabbi Herzog",
                      StationAddress = "12 HaRav Herzog,Givata'yim",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =26080,
                     Logtitude = 34.812816,
                     Latitude = 32.058589,
                     StationName = "Aluf Sade/Oded",
                      StationAddress = "Aluf Sade,Ramat Gan",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =20033,
                     Logtitude = 34.808556,
                     Latitude = 32.062645,
                     StationName = "Metzulot Yam/Israel Shapira",
                      StationAddress = "46 Metzulot Yam,Givata'yim",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =20327,
                     Logtitude = 34.812469,
                     Latitude = 32.069747,
                     StationName = "The Kneset/Golomb",
                      StationAddress = "33 The Kneset,Givata'yim",
                      IsAvailableStation =true
                 },




                 new Station
                 {
                     StationId =26107,
                     Logtitude = 34.802974,
                     Latitude = 32.077945,
                     StationName = "Thelma Yellin/Borochov",
                     StationAddress = "7 Borochov,Givata'yim",
                     IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =21139,
                     Logtitude = 34.795453,
                     Latitude = 32.082475,
                     StationName = "Tel Aviv Center Train Station/Al Parashat Drachim",
                     StationAddress = "3 Al Parashat Drachim, Tel Aviv Jaffa",
                     IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 20265,
                     Logtitude = 34.805032,
                     Latitude = 32.088921,
                     StationName = "Avigayil/Ruth",
                     StationAddress = "10 Avigayil,Ramat Gan",
                     IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 26945,
                     Logtitude = 34.825574,
                     Latitude = 32.098936,
                     StationName = "Ayalon Mall",
                     StationAddress = "301 Abba Hillel Silver, Ramat Gan",
                     IsAvailableStation =true
                 },

                #endregion

                #region 50-Ramon Airport/Platforms -> HaTmarim Boulevard/Shfifon
                 new Station
                 {
                     StationId = 12158,
                     Logtitude = 35.006083,
                     Latitude = 29.726226,
                     StationName = "Ramon Airport/Platforms",
                     StationAddress = "Eilat city",
                     IsAvailableStation =true
                 },

                 new Station
                 {
                     StationId = 10378,
                     Logtitude = 34.996958,
                     Latitude = 29.706043,
                     StationName = "Be'er Ora Junction/Ramon Airport",
                     StationAddress = "Eilat city",
                     IsAvailableStation =true
                 },

                 new Station
                 {
                     StationId = 11742,
                     Logtitude = 34.969278,
                     Latitude = 29.581124,
                     StationName = "Rabin Border Crossing/Road 90",
                     StationAddress = "Hevel Eilot Regional Council",
                     IsAvailableStation =true
                 },
                new Station
                {
                    StationId = 10377,
                    Logtitude = 34.967421,
                    Latitude = 29.577247,
                    StationName = "Elot Junction",
                     StationAddress = "Hevel Eilot Regional Council",
                     IsAvailableStation =true
                },
                new Station
                {
                    StationId = 10453,
                    Logtitude = 34.958621,
                    Latitude = 29.552333,
                    StationName = "Tarshish/Dan Panorama Hotel",
                     StationAddress = "20 Tarshish,Eilat",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 10871,
                    Logtitude = 34.962899,
                    Latitude = 29.549918,
                    StationName = "HaYam/Antibes",
                     StationAddress = "HaYam, Eilat",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId =19610,
                    Logtitude = 34.966804,
                    Latitude = 29.54958,
                    StationName = "Herod's Hotel",
                     StationAddress = "Shopron,Eilat",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 19323,
                    Logtitude = 34.966055,
                    Latitude = 29.554866,
                    StationName = "Kampen/Ice Mall",
                     StationAddress = "7 Kampen, Eilat",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 19613,
                    Logtitude = 34.962112,
                    Latitude = 29.556076,
                    StationName = "Kampen/HaMelonot Road",
                     StationAddress = "3 Kampen, Eilat",
                     IsAvailableStation =true
                },


                new Station
                {
                    StationId = 10255,
                    Logtitude = 34.954541,
                    Latitude = 29.55331,
                    StationName = "HaArava Road/HaTmarim Blvd",
                     StationAddress = "HaArava Road, Eilat",
                     IsAvailableStation =true
                },

                #endregion

                #region 541-Afula ‎-> Kiryat Shmona
                new Station
                {
                    StationId = 55637,
                    Logtitude = 35.292233,
                    Latitude = 32.607821,
                    StationName = "Afula Central Station/Platforms",
                     StationAddress = "4 Platform,Afula",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 55400,
                    Logtitude = 35.327759,
                    Latitude = 32.629757,
                    StationName = "Golani Road/Komemiyut",
                     StationAddress = "Golani Road,Afula",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 55340,
                    Logtitude = 35.373189,
                    Latitude = 32.650154,
                    StationName = "Na'ura Junction",
                     StationAddress = "Jezreel Valley",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 56733,
                    Logtitude = 35.419528,
                    Latitude = 32.685437,
                    StationName = "Kfar Tavor Center",
                     StationAddress = "Kfar Tavor",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 54245,
                    Logtitude = 35.40805,
                    Latitude = 32.772432,
                    StationName = "Golani Interchange/Eastbound",
                     StationAddress = "Exit to Route 77 East,Lower Galilee",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 58118,
                    Logtitude = 35.527408,
                    Latitude = 32.797128,
                    StationName = "Shimon Dahan/HaShomer",
                     StationAddress = "17 Shimon Dahan,Tiberias",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 57008,
                    Logtitude = 35.51665,
                    Latitude = 32.845789,
                    StationName = "Kibbutz Ginosar 2",
                     StationAddress = "Jordan valley",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 51410,
                    Logtitude = 35.551334,
                    Latitude = 32.968266,
                    StationName = "Rosh Pina Junction",
                     StationAddress = "Rosh Pina city",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 53408,
                    Logtitude = 35.556268,
                    Latitude = 32.98083,
                    StationName = "Hatsor HaGlilit Central Station/Platforms",
                     StationAddress = "Hatsor HaGlilit Local Council",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 51470,
                    Logtitude = 35.572392,
                    Latitude = 33.112165,
                    StationName = "Agamon Hula",
                     StationAddress = "Upper Galilee",
                     IsAvailableStation =true
                },

                new Station
                {
                    StationId = 51451,
                    Logtitude = 35.569651,
                    Latitude = 33.205323,
                    StationName = "Tel Hai/Uri Ilan",
                    StationAddress = "85 Tel Hai, Kiryat Shmona",
                    IsAvailableStation =true
                },

                #endregion

                #region  464-Jerusalen->Ariel
 


                 new Station
                 {
                     StationId = 6102,
                     Logtitude = 35.232061,
                     Latitude = 31.799032,
                     StationName = "Giv'at Hatachmoshet Light Rail Station",
                     StationAddress = "Zalman Shragai, Jerusalem",
                     IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 2566,
                     Logtitude = 35.240696,
                     Latitude = 31.825373,
                     StationName = "Sayeret Dukhifat/Moshe Dayan",
                     StationAddress = "Sayeret Dukhifat Blvd ,Jerusalem",
                     IsAvailableStation =true
                 },





                 new Station
                 {
                     StationId = 3022,
                     Logtitude = 35.252356,
                     Latitude = 31.827964,
                     StationName = "Sayeret Dukhifat/Hazme Barricade",
                     StationAddress = "Sayeret Dukhifat Blvd, Jerusalem",
                     IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId = 60826,
                     Logtitude = 35.261405,
                     Latitude = 31.864909,
                     StationName = "Sha'ar Binyamin Industrial Zone",
                     StationAddress = "Mateh Binyamin City",
                     IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =61152,
                     Logtitude = 35.260453,
                     Latitude = 31.872953,
                     StationName = "Gas Station/Kokhav Ya'akov",
                      StationAddress = "Mateh Binyamin City",
                      IsAvailableStation =true
                 },





                 new Station
                 {
                     StationId =61350,
                     Logtitude = 35.250008,
                     Latitude = 31.911904,
                     StationName = "Giv'at Assaf Junction/Road 60",
                      StationAddress = "Mateh Binyamin Regional Council",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =60901,
                     Logtitude = 35.256997,
                     Latitude = 31.955625,
                     StationName = "Ofra/Exit",
                      StationAddress = "Hameyasdim ,Ofra",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =60499,
                     Logtitude = 35.290424,
                     Latitude = 32.048149,
                     StationName = "Shilo Junction",
                      StationAddress = "Mateh Binyamin Regional Council",
                      IsAvailableStation =true
                 },



                 new Station
                 {
                     StationId =65260,
                     Logtitude = 35.171607,
                     Latitude = 32.105963,
                     StationName = "Bet Hachayal/HaNahshonim Road",
                      StationAddress = "43 Nahshonim Road,Ariel",
                      IsAvailableStation =true
                 },


                 new Station
                 {
                     StationId =63231,
                     Logtitude = 35.17337,
                     Latitude = 32.102254,
                     StationName = "Ganim/HaKalaniot",
                      StationAddress = " 41 Ganim,Ariel",
                      IsAvailableStation =true
                 },

                  #endregion


            };

            ListAllLines = new List<Line>
            {

                #region  Line  480 / 1
                   new Line
                   {
                        LineId = 1,
                        LineNumber= 480 ,
                        Area = Enums.AREA.EXPRESS,
                        FirstStationId =  4170,
                        LastStationId =  20178,
                        IsNightLine = false ,
                        IsAvailableLine = true,
                        IsUrbanLine = false
                    },
                   #endregion

                #region  Line 480 /2
                     new Line
                    {
                    LineId = 2,
                    LineNumber= 480 ,
                    Area = Enums.AREA.EXPRESS,
                    FirstStationId =  20001,
                    LastStationId =  4170,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = false

                    },
                      #endregion
                   
                #region  Line 20
                     new Line
                    {
                        LineId = 3,
                        LineNumber= 20 ,
                        Area = Enums.AREA.HASHRON,
                        FirstStationId =  30136,
                        LastStationId =  39522,
                        IsNightLine = false ,
                        IsAvailableLine = true,
                        IsUrbanLine = true

                    },
                      #endregion

                #region  Line 68
                    new Line
                    {
                        LineId = 4,
                        LineNumber= 68 ,
                        Area = Enums.AREA.JerusalemAndSurroundings,
                        FirstStationId = 1431,
                        LastStationId = 3609,
                        IsNightLine = false ,
                        IsAvailableLine = true,
                        IsUrbanLine = true

                    },
                    #endregion

                 #region  Line 551
                 new Line
                 {
                    LineId = 5,
                    LineNumber= 551 ,
                    Area = Enums.AREA.HASHRON,
                    FirstStationId =  35377,
                    LastStationId =   20167,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = false

                  },
                  #endregion
                
                 #region  Line 1
                 new Line
                 {
                    LineId = 6,
                    LineNumber= 1 ,
                    Area = Enums.AREA.NORTH ,
                    FirstStationId =  41200,
                    LastStationId =   42657,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = true

                  },
                     #endregion

                 #region  Line 82
                 new Line
                 {
                    LineId = 7,
                    LineNumber= 82 ,
                    Area = Enums.AREA.HASHRON ,
                    FirstStationId =  37135,
                    LastStationId =   63206,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = false

                  },
                   #endregion
               
                 #region  Line 4
                 new Line
                 {
                    LineId = 8,
                    LineNumber= 4 ,
                    Area = Enums.AREA.CENTER ,
                    FirstStationId =  21486,
                    LastStationId =   22927,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = true

                  },
                 #endregion

                 #region   Line 3
                new Line
                {
                    LineId = 9,
                    LineNumber =3,
                    Area = Enums.AREA.SOUTH,
                    FirstStationId =15897,
                    LastStationId =11168,
                    IsNightLine = true,
                    IsAvailableLine = true,
                    IsUrbanLine = true

                },
                #endregion
                
                  #region  Line 58
                 new Line
                 {
                    LineId = 10,
                    LineNumber= 58  ,
                    Area = Enums.AREA.CENTER ,
                    FirstStationId =  26156,
                    LastStationId =   26945,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = true

                  },
                 #endregion
                  
                  #region  Line 50
                 new Line
                 {
                    LineId = 11,
                    LineNumber= 50 ,
                    Area = Enums.AREA.SOUTH ,
                    FirstStationId =  12158,
                    LastStationId =   10255,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = true

                  },
                 #endregion                 

             
                  #region  Line 541
                 new Line
                 {
                    LineId = 12,
                    LineNumber= 541 ,
                    Area = Enums.AREA.NORTH ,
                    FirstStationId =  55637,
                    LastStationId =   51451,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = false

                  },
                   #endregion
                  
                 #region  Line 464
                 new Line
                 {
                    LineId = 13,
                    LineNumber= 464 ,
                    Area = Enums.AREA.SOUTH ,
                    FirstStationId =  6102,
                    LastStationId =   63231,
                    IsNightLine = false ,
                    IsAvailableLine = true,
                    IsUrbanLine = false

                  },
                  #endregion
                  
                 
            };

            ListAllAdjacentStations = new List<AdjacentStations>
            {

             #region  Adjacent Stations 480 /1
                   new AdjacentStations
                   {
                      StationId1 = 4170,
                      StationId2 =  638,
                      DistanceBetweenTwoAdjacentSations = 11397.6126662061,
                      AverageTravelTime = 0.142470158327577
                    },



                   new AdjacentStations
                   {
                      StationId1 = 638,
                      StationId2 =  20178,
                      DistanceBetweenTwoAdjacentSations =  66293.9902761625,
                      AverageTravelTime =  0.828674878452031
                    },
                   #endregion

             #region  Adjacent Stations 480 / 2
                   new AdjacentStations
                   {
                      StationId1 = 20001,
                      StationId2 =  640,
                      DistanceBetweenTwoAdjacentSations =  66456.4826659341,
                      AverageTravelTime = 0.830706033324176
                    },



                   new AdjacentStations
                   {
                      StationId1 = 640,
                      StationId2 =  5602,
                      DistanceBetweenTwoAdjacentSations =  2779.19073789709,
                      AverageTravelTime = 0.0347398842237137
                    },

                    new AdjacentStations
                   {
                      StationId1 = 5602,
                      StationId2 =  4170,
                      DistanceBetweenTwoAdjacentSations =  8369.01683746908,
                      AverageTravelTime = 0.104612710468363
                    },
                   #endregion

             #region  Adjacent Stations 20
                   new AdjacentStations
                   {
                      StationId1 = 30136,
                      StationId2 =  30279,
                      DistanceBetweenTwoAdjacentSations =  4325.71084237794,
                      AverageTravelTime = 0.108142771059449
                    },


                   new AdjacentStations
                   {
                      StationId1 = 30279,
                      StationId2 =  30297,
                      DistanceBetweenTwoAdjacentSations =  3220.20547200787,
                     AverageTravelTime =  0.0805051368001968
                    },

                    new AdjacentStations
                   {
                      StationId1 = 30297,
                      StationId2 =  37837,
                      DistanceBetweenTwoAdjacentSations =  3075.07841485126,
                      AverageTravelTime = 0.0768769603712814
                    },

                     new AdjacentStations
                   {
                      StationId1 = 37837,
                      StationId2 =  30434,
                      DistanceBetweenTwoAdjacentSations =  6204.80971487851,
                     AverageTravelTime = 0.155120242871963
                    },

                       new AdjacentStations
                   {
                      StationId1 = 30434,
                      StationId2 =  39582,
                      DistanceBetweenTwoAdjacentSations = 104714.520235552,
                      AverageTravelTime = 2.6178630058888
                    },

                    new AdjacentStations
                   {
                      StationId1 = 39582,
                      StationId2 =  30787,
                      DistanceBetweenTwoAdjacentSations = 94018.4036162145,
                      AverageTravelTime =  2.35046009040536
                    },

                     new AdjacentStations
                   {
                      StationId1 = 30787,
                      StationId2 =  30734,
                      DistanceBetweenTwoAdjacentSations = 7453.90306445629,
                      AverageTravelTime =  0.186347576611407
                    },

                        new AdjacentStations
                   {
                      StationId1 = 30734,
                      StationId2 =  30515,
                      DistanceBetweenTwoAdjacentSations = 8901.64754545812,
                      AverageTravelTime = 0.222541188636453
                    },


                        new AdjacentStations
                        {
                          StationId1 = 30515,
                          StationId2 =  39524,
                          DistanceBetweenTwoAdjacentSations =  7062.96687728454,
                          AverageTravelTime = 0.176574171932114
                        },

                        new AdjacentStations
                        {
                          StationId1 = 39524,
                          StationId2 =  39522,
                          DistanceBetweenTwoAdjacentSations = 2272.65780832223,
                          AverageTravelTime = 0.0568164452080556
                        },

                   #endregion

             #region AdjacentStations 68
                   new AdjacentStations
                   {
                      StationId1 = 1431,
                      StationId2 = 3850 ,
                      DistanceBetweenTwoAdjacentSations = 1479.9383993552,
                      AverageTravelTime =  0.0369984599838801
                    },

                   new AdjacentStations
                   {
                      StationId1 =3850 ,
                      StationId2 = 6066 ,
                      DistanceBetweenTwoAdjacentSations = 964.779617075064,
                      AverageTravelTime = 0.0241194904268766
                    },

                   new AdjacentStations
                    {
                        StationId1 = 6066,
                        StationId2 = 4012,
                        DistanceBetweenTwoAdjacentSations =  2173.53240014602,
                        AverageTravelTime = 0.0543383100036505
                    },

                   new AdjacentStations
                    {
                        StationId1 = 4012,
                        StationId2 = 5949,
                        DistanceBetweenTwoAdjacentSations = 2399.39068209629,
                        AverageTravelTime = 0.0599847670524073
                    },

                   new AdjacentStations
                    {
                        StationId1 = 5949,
                        StationId2 = 1540,
                        DistanceBetweenTwoAdjacentSations =  655.39448876406,
                         AverageTravelTime = 0.0163848622191015
                    },

                   new AdjacentStations
                    {
                        StationId1 = 1540,
                        StationId2 = 3099,
                        DistanceBetweenTwoAdjacentSations = 622.651074897688,
                        AverageTravelTime = 0.0155662768724422
                    },

                   new AdjacentStations
                     {
                         StationId1 = 3099,
                         StationId2 = 9915,
                         DistanceBetweenTwoAdjacentSations =645.460384672776 ,
                       AverageTravelTime =  0.0161365096168194
                     },

                   new AdjacentStations
                    {
                        StationId1 = 9915,
                        StationId2 = 4190,
                        DistanceBetweenTwoAdjacentSations = 372.92391771302,
                         AverageTravelTime = 0.00932309794282551
                    },

                   new AdjacentStations
                     {
                         StationId1 = 4190,
                         StationId2 = 3609,
                         DistanceBetweenTwoAdjacentSations = 575.090241580888,
                         AverageTravelTime = 0.0143772560395222
                     },

                   #endregion

             #region Adjacent Stations 551

                    new AdjacentStations
                   {
                      StationId1 = 35377,
                      StationId2 =  36899,
                      DistanceBetweenTwoAdjacentSations = 3114.08842409046,
                      AverageTravelTime = 0.0389261053011308
                    },

                     new AdjacentStations
                   {
                      StationId1 = 36899,
                      StationId2 =  39686,
                      DistanceBetweenTwoAdjacentSations =  6420.25886856906,
                      AverageTravelTime =  0.0802532358571132
                    },

                     // new
                         new AdjacentStations
                   {
                      StationId1 = 39686,
                      StationId2 =  37174,
                      DistanceBetweenTwoAdjacentSations =  4357.20868900179,
                      AverageTravelTime =  0.0596069900576113
                    },



                       new AdjacentStations
                   {
                      StationId1 = 37174,
                      StationId2 =  35946,
                      DistanceBetweenTwoAdjacentSations =  4274.58317990419,
                      AverageTravelTime =  0.0534322897488024
                    },

                    new AdjacentStations
                    {
                      StationId1 = 35946,
                      StationId2 =  37060,
                      DistanceBetweenTwoAdjacentSations = 3495.20868550179,
                      AverageTravelTime = 0.0436901085687723
                    },

                       new AdjacentStations
                    {
                      StationId1 = 37060,
                      StationId2 =  36614,
                      DistanceBetweenTwoAdjacentSations = 2635.70765186237,
                      AverageTravelTime = 0.0329463456482796
                    },

                    new AdjacentStations
                    {
                      StationId1 = 36614,
                      StationId2 =  26910,
                      DistanceBetweenTwoAdjacentSations = 2418.77156271596,
                      AverageTravelTime = 0.0302346445339495
                    },

                     new AdjacentStations
                    {
                      StationId1 = 26910,
                      StationId2 =  26895,
                      DistanceBetweenTwoAdjacentSations =  2368.5592046089,
                      AverageTravelTime = 0.0296069900576113
                    },

                      new AdjacentStations
                    {
                      StationId1 = 26895,
                      StationId2 =  20167,
                      DistanceBetweenTwoAdjacentSations = 3234.22668229874,
                      AverageTravelTime = 0.0404278335287343
                    },
                    #endregion

             #region Adjacent Stations 1
                  new AdjacentStations
                  {
                     StationId1 = 41200,
                     StationId2 = 41205,
                     DistanceBetweenTwoAdjacentSations = 843.690531140658,
                      AverageTravelTime = 0.0210922632785165
                   },

                   new AdjacentStations
                    {
                        StationId1 = 41205,
                        StationId2 = 43073,
                        DistanceBetweenTwoAdjacentSations =  576.057373332089,
                         AverageTravelTime =  0.0144014343333022
                    },

                   new AdjacentStations
                    {
                        StationId1 = 43073,
                        StationId2 = 43022,
                        DistanceBetweenTwoAdjacentSations =  1119.02441005456,
                         AverageTravelTime = 0.0279756102513639
                    },

                   new AdjacentStations
                    {
                        StationId1 = 43022,
                        StationId2 = 43015,
                        DistanceBetweenTwoAdjacentSations = 265.302179872769,
                         AverageTravelTime = 0.00663255449681921
                    },


                   new AdjacentStations
                   {
                       StationId1 = 43015,
                       StationId2 = 42335,
                       DistanceBetweenTwoAdjacentSations = 810.072731895688,
                       AverageTravelTime =  0.0202518182973922
                   },

                    new AdjacentStations
                    {
                        StationId1 = 42335,
                        StationId2 = 41209,
                        DistanceBetweenTwoAdjacentSations =  969.672920124754,
                                  AverageTravelTime = 0.0242418230031188
                    },

                     new AdjacentStations
                     {
                         StationId1 = 41209,
                         StationId2 = 42506,
                         DistanceBetweenTwoAdjacentSations =  7382.65250846574,
                         AverageTravelTime =  0.184566312711644
                     },

                      new AdjacentStations
                      {
                          StationId1 = 42506,
                          StationId2 = 42501,
                          DistanceBetweenTwoAdjacentSations =  922.878539361511,
                          AverageTravelTime =  0.0230719634840378
                      },

                       new AdjacentStations
                       {
                           StationId1 = 42501,
                           StationId2 = 42657,
                           DistanceBetweenTwoAdjacentSations =  431.738743807658,
                           AverageTravelTime =  0.0107934685951915
                       },
                     
                      #endregion

             #region Adjacent Stations 82


                    new AdjacentStations
                   {
                      StationId1 = 37135,
                      StationId2 =  37027,
                      DistanceBetweenTwoAdjacentSations = 1120.05234644217,
                     AverageTravelTime =  0.0140006543305271
                    },

                     new AdjacentStations
                   {
                      StationId1 = 37027,
                      StationId2 =  37033,
                      DistanceBetweenTwoAdjacentSations =  1450.6389371228,
                     AverageTravelTime = 0.018132986714035
                    },


                     new AdjacentStations
                   {
                      StationId1 = 37033,
                      StationId2 =  39794,
                      DistanceBetweenTwoAdjacentSations = 1645.45231234319,
                     AverageTravelTime =  0.0205681539042898
                    },


                     new AdjacentStations
                   {
                      StationId1 = 39794,
                      StationId2 =  39791,
                      DistanceBetweenTwoAdjacentSations =  1381.30410368361,
                     AverageTravelTime = 0.0172663012960452
                    },


                       new AdjacentStations
                   {
                      StationId1 = 39791,
                      StationId2 =  63180,
                      DistanceBetweenTwoAdjacentSations = 20540.6523391181,
                     AverageTravelTime = 0.256758154238976
                    },

                       new AdjacentStations
                   {
                      StationId1 = 63180,
                      StationId2 =  61211,
                      DistanceBetweenTwoAdjacentSations = 1090.69776086869,
                     AverageTravelTime = 0.0136337220108586
                    },


                       new AdjacentStations
                   {
                      StationId1 = 61211,
                      StationId2 =  65287,
                      DistanceBetweenTwoAdjacentSations = 946.467101227284,
                     AverageTravelTime = 0.011830838765341
                    },

                    new AdjacentStations
                   {
                      StationId1 = 65287,
                      StationId2 =  63188,
                      DistanceBetweenTwoAdjacentSations = 707.525112818211,
                     AverageTravelTime = 0.00884406391022764
                    },

                new AdjacentStations
                   {
                      StationId1 = 63188,
                      StationId2 =  65268,
                      DistanceBetweenTwoAdjacentSations = 1389.47485810212,
                     AverageTravelTime =  0.0173684357262765
                    },

                new AdjacentStations
                   {
                      StationId1 = 65268,
                      StationId2 =  63203,
                      DistanceBetweenTwoAdjacentSations =  2137.81145501823,
                     AverageTravelTime =  0.0267226431877278
                    },


                 new AdjacentStations
                   {
                      StationId1 = 63203,
                      StationId2 =  63206,
                      DistanceBetweenTwoAdjacentSations = 106310.986881206,
                      AverageTravelTime = 1.32888733601507
                    } ,


                       #endregion

             #region Adjacent Stations 4

                    new AdjacentStations
                   {
                      StationId1 = 21486,
                      StationId2 =  21437,
                      DistanceBetweenTwoAdjacentSations = 24602.277635456,
                      AverageTravelTime =  0.615056940886399
                    },

                     new AdjacentStations
                   {
                      StationId1 = 21437,
                      StationId2 =  21574,
                      DistanceBetweenTwoAdjacentSations = 25927.0928295153,
                     AverageTravelTime =  0.648177320737882
                    },

                      new AdjacentStations
                   {
                      StationId1 = 21574,
                      StationId2 =  25663,
                      DistanceBetweenTwoAdjacentSations = 1394.43563424093,
                     AverageTravelTime = 0.0348608908560231
                    },

                     new AdjacentStations
                   {
                      StationId1 = 25663,
                      StationId2 =  25402,
                      DistanceBetweenTwoAdjacentSations =  2751.36788917018,
                     AverageTravelTime = 0.0687841972292546
                    },

                     new AdjacentStations
                   {
                      StationId1 = 25402,
                      StationId2 =  23021,
                      DistanceBetweenTwoAdjacentSations =  1321.16795669275,
                     AverageTravelTime =  0.0330291989173187
                    },


                     new AdjacentStations
                   {
                      StationId1 = 23021,
                      StationId2 =  21539,
                      DistanceBetweenTwoAdjacentSations = 1210.84370989411,
                      AverageTravelTime = 0.0302710927473527
                    },

                    new AdjacentStations
                   {
                      StationId1 = 21539,
                      StationId2 =  23004,
                      DistanceBetweenTwoAdjacentSations = 1199.41134132006,
                     AverageTravelTime = 0.0299852835330015
                    },

                      new AdjacentStations
                   {
                      StationId1 = 23004,
                      StationId2 =  23001,
                      DistanceBetweenTwoAdjacentSations =  1318.67525184784,
                      AverageTravelTime =  0.0329668812961961
                    },

                         new AdjacentStations
                   {
                      StationId1 = 23001,
                      StationId2 =  22999,
                      DistanceBetweenTwoAdjacentSations = 961.503172164196,
                     AverageTravelTime = 0.0240375793041049
                    },

                    new AdjacentStations
                   {
                      StationId1 = 22999,
                      StationId2 =  27246,
                      DistanceBetweenTwoAdjacentSations = 528.809264355521,
                      AverageTravelTime = 0.013220231608888
                    },

                      new AdjacentStations
                   {
                      StationId1 = 27246,
                      StationId2 =  22927,
                      DistanceBetweenTwoAdjacentSations = 690.119936308121,
                     AverageTravelTime = 0.017252998407703
                    },
                   #endregion

             #region Adjacent Stations 3
            new AdjacentStations
                   {
                       StationId1 = 15897,
                       StationId2 = 19516,
                       DistanceBetweenTwoAdjacentSations = 186.664828502512,
                       AverageTravelTime = 0.0023333103562814
            },


                   new AdjacentStations
                   {
                       StationId1 = 19516,
                       StationId2 = 10720,
                       DistanceBetweenTwoAdjacentSations = 1659.79139741565,
                        AverageTravelTime = 0.0207473924676956
                   },

                   new AdjacentStations
                   {
                       StationId1 = 10720,
                       StationId2 = 14831,
                       DistanceBetweenTwoAdjacentSations = 253.045263844818,
                       AverageTravelTime = 0.00316306579806023
                   },

                   new AdjacentStations
                   {
                       StationId1 = 14831,
                       StationId2 = 14827,
                       DistanceBetweenTwoAdjacentSations = 545.891098590472,
                       AverageTravelTime = 0.0068236387323809
                   },


                   new AdjacentStations
                   {
                       StationId1 = 14827,
                       StationId2 = 14836,
                       DistanceBetweenTwoAdjacentSations = 273.850417086875,
                       AverageTravelTime =  0.00342313021358593
                   },
                    new AdjacentStations
                    {
                        StationId1 = 14836,
                        StationId2 = 15231,
                        DistanceBetweenTwoAdjacentSations = 454.896474108737,
                        AverageTravelTime = 0.00568620592635921
                    },
                     new AdjacentStations
                     {
                         StationId1 = 15231,
                         StationId2 = 19385,
                         DistanceBetweenTwoAdjacentSations = 1107.58139461084,
                         AverageTravelTime = 0.0138447674326355
                     },
                      new AdjacentStations
                      {
                          StationId1 = 19385,
                          StationId2 = 11219,
                          DistanceBetweenTwoAdjacentSations = 632.62352940697,
                          AverageTravelTime = 0.00790779411758712
                      },
                       new AdjacentStations
                       {
                           StationId1 = 11219,
                           StationId2 = 11168,
                           DistanceBetweenTwoAdjacentSations = 540.103931825256,
                           AverageTravelTime = 0.0067512991478157
                       },
                       
                      #endregion

             #region Adjacent Stations 58
                 new AdjacentStations
                 {
                     StationId1 = 26156,
                     StationId2 = 26158,
                     DistanceBetweenTwoAdjacentSations = 419.934896468454,
                     AverageTravelTime = 0.00524918620585567
                 },


                   new AdjacentStations
                   {
                       StationId1 = 26158,
                       StationId2 = 26084,
                       DistanceBetweenTwoAdjacentSations = 640.230607842183,
                       AverageTravelTime = 0.00800288259802729
                   },

                   new AdjacentStations
                   {
                       StationId1 = 26084,
                       StationId2 = 26080,
                       DistanceBetweenTwoAdjacentSations = 758.077961191852,
                       AverageTravelTime = 0.00947597451489815
                   },

                   new AdjacentStations
                   {
                       StationId1 = 26080,
                       StationId2 = 20033,
                       DistanceBetweenTwoAdjacentSations = 906.471654871045,
                       AverageTravelTime = 0.0113308956858881
                   },


                   new AdjacentStations
                   {
                       StationId1 = 20033,
                       StationId2 = 20327,
                       DistanceBetweenTwoAdjacentSations = 1308.44852401324,
                       AverageTravelTime = 0.0163556065501654
                   },
                    new AdjacentStations
                    {
                        StationId1 = 20327,
                        StationId2 = 26107,
                        DistanceBetweenTwoAdjacentSations = 1917.52353366608,
                        AverageTravelTime = 0.023969044170826
                    },
                     new AdjacentStations
                     {
                         StationId1 = 26107,
                         StationId2 = 21139,
                         DistanceBetweenTwoAdjacentSations = 1305.21113996328,
                         AverageTravelTime = 0.016315139249541
                     },
                      new AdjacentStations
                      {
                          StationId1 = 21139,
                          StationId2 = 20265,
                          DistanceBetweenTwoAdjacentSations = 1730.17262144909,
                          AverageTravelTime = 0.0216271577681136
                      },
                       new AdjacentStations
                       {
                           StationId1 = 20265,
                           StationId2 = 26945,
                           DistanceBetweenTwoAdjacentSations = 3351.8705553172,
                           AverageTravelTime = 0.041898381941465
                       },
                       
                      #endregion

             #region Adjacent Stations 50
                   new AdjacentStations
                   {
                       StationId1 = 12158,
                       StationId2 = 10378,
                       DistanceBetweenTwoAdjacentSations = 3619.70635353914,
                       AverageTravelTime = 0.0904926588384786
                   },


                   new AdjacentStations
                   {
                       StationId1 = 10378,
                       StationId2 = 11742,
                       DistanceBetweenTwoAdjacentSations = 21236.7126928422,
                       AverageTravelTime = 0.530917817321055
                   },

                   new AdjacentStations
                   {
                       StationId1 = 11742,
                       StationId2 = 10377,
                       DistanceBetweenTwoAdjacentSations = 701.119005889392,
                       AverageTravelTime = 0.0175279751472348
                   },

                   new AdjacentStations
                   {
                       StationId1 = 10377,
                       StationId2 = 10453,
                       DistanceBetweenTwoAdjacentSations = 4350.90957818658,
                       AverageTravelTime = 0.108772739454664
                   },


                   new AdjacentStations
                   {
                       StationId1 = 10453,
                       StationId2 = 10871,
                       DistanceBetweenTwoAdjacentSations = 740.599295887742,
                       AverageTravelTime = 0.0185149823971936
                   },
                    new AdjacentStations
                    {
                        StationId1 = 10871,
                        StationId2 = 19610,
                        DistanceBetweenTwoAdjacentSations = 569.89438289327,
                        AverageTravelTime = 0.0142473595723318
                    },
                     new AdjacentStations
                     {
                         StationId1 = 19610,
                         StationId2 = 19323,
                         DistanceBetweenTwoAdjacentSations = 889.103947773484,
                         AverageTravelTime = 0.0222275986943371
                     },
                      new AdjacentStations
                      {
                          StationId1 = 19323,
                          StationId2 = 19613,
                          DistanceBetweenTwoAdjacentSations = 607.165018359573,
                          AverageTravelTime = 0.0151791254589893
                      },
                       new AdjacentStations
                       {
                           StationId1 = 19613,
                           StationId2 = 10255,
                           DistanceBetweenTwoAdjacentSations = 1192.45462139457,
                           AverageTravelTime = 0.0298113655348642
                       },
                       
                      #endregion

             #region Adjacent Stations 541
                 new AdjacentStations
                 {
                     StationId1 = 55637,
                     StationId2 = 55400,
                     DistanceBetweenTwoAdjacentSations = 6193.66628966178,
                     AverageTravelTime = 0.0774208286207723
                 },


                   new AdjacentStations
                   {
                       StationId1 = 55400,
                       StationId2 = 55340,
                       DistanceBetweenTwoAdjacentSations = 7237.27152247095,
                       AverageTravelTime = 0.0904658940308869
                   },

                   new AdjacentStations
                   {
                       StationId1 = 55340,
                       StationId2 = 56733,
                       DistanceBetweenTwoAdjacentSations = 8780.56636546716,
                       AverageTravelTime = 0.10975707956834
                   },

                   new AdjacentStations
                   {
                       StationId1 = 56733,
                       StationId2 = 54245,
                       DistanceBetweenTwoAdjacentSations = 14611.8098737212,
                       AverageTravelTime = 0.182647623421515
                   },


                   new AdjacentStations
                   {
                       StationId1 = 54245,
                       StationId2 = 58118,
                       DistanceBetweenTwoAdjacentSations = 17251.1722771951,
                       AverageTravelTime = 0.215639653464939
                   },
                    new AdjacentStations
                    {
                        StationId1 = 58118,
                        StationId2 = 57008,
                        DistanceBetweenTwoAdjacentSations = 8262.29842192518,
                        AverageTravelTime = 0.103278730274065
                    },
                     new AdjacentStations
                     {
                         StationId1 = 57008,
                         StationId2 = 51410,
                         DistanceBetweenTwoAdjacentSations = 21015.7816855142,
                         AverageTravelTime = 0.262697271068927
                     },
                      new AdjacentStations
                      {
                          StationId1 = 51410,
                          StationId2 = 53408,
                          DistanceBetweenTwoAdjacentSations = 2208.27883907508,
                          AverageTravelTime = 0.0276034854884386
                      },
                       new AdjacentStations
                       {
                           StationId1 = 53408,
                           StationId2 = 51470,
                           DistanceBetweenTwoAdjacentSations = 22040.3778075989,
                           AverageTravelTime = 0.275504722594987
                       },
                        new AdjacentStations
                        {
                            StationId1 = 51470,
                            StationId2 = 51451,
                            DistanceBetweenTwoAdjacentSations = 15556.1762775277,
                            AverageTravelTime = 0.194452203469096
                        },
                      #endregion

             #region Adjacent Stations 464
                 new AdjacentStations
                 {
                     StationId1 = 6102,
                     StationId2 = 2566,
                     DistanceBetweenTwoAdjacentSations = 4564.70240138957,
                     AverageTravelTime = 0.0570587800173696
                 },


                   new AdjacentStations
                   {
                       StationId1 = 2566,
                       StationId2 = 3022,
                       DistanceBetweenTwoAdjacentSations = 1709.44570649163,
                       AverageTravelTime = 0.0213680713311454
                   },

                   new AdjacentStations
                   {
                       StationId1 = 3022,
                       StationId2 = 60826,
                       DistanceBetweenTwoAdjacentSations = 6299.54307308898,
                       AverageTravelTime = 0.0787442884136122
                   },

                   new AdjacentStations
                   {
                       StationId1 = 60826,
                       StationId2 = 61152,
                       DistanceBetweenTwoAdjacentSations = 1349.60188813943,
                       AverageTravelTime = 0.0168700236017429
                   },


                   new AdjacentStations
                   {
                       StationId1 = 61152,
                       StationId2 = 61350,
                       DistanceBetweenTwoAdjacentSations = 6668.73969646078,
                       AverageTravelTime = 0.0833592462057598
                   },
                    new AdjacentStations
                    {
                        StationId1 = 61350,
                        StationId2 = 60901,
                        DistanceBetweenTwoAdjacentSations = 7365.48200684661,
                        AverageTravelTime = 0.0920685250855826
                    },
                     new AdjacentStations
                     {
                         StationId1 = 60901,
                         StationId2 = 60499,
                         DistanceBetweenTwoAdjacentSations = 16154.2751969738,
                         AverageTravelTime = 0.201928439962172
                     },
                      new AdjacentStations
                      {
                          StationId1 = 60499,
                          StationId2 = 65260,
                          DistanceBetweenTwoAdjacentSations = 19380.7797208996,
                          AverageTravelTime = 0.242259746511245
                      },
                       new AdjacentStations
                       {
                           StationId1 = 65260,
                           StationId2 = 63231,
                           DistanceBetweenTwoAdjacentSations = 667.473163374806,
                           AverageTravelTime =0.00834341454218507
                       },
                       
                      #endregion
 
            };

            ListAllStationsInLine = new List<StationInLine>
            {
              #region  Stations in Line  480 / 1
                 new StationInLine
                 {
                      LineId = 1,
                      StationId =  4170,
                      StationInLineLocation = 0,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                  new StationInLine
                 {
                      LineId = 1,
                      StationId =  638,
                      StationInLineLocation = 1,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                   new StationInLine
                 {
                      LineId = 1,
                      StationId =  20178,
                      StationInLineLocation = 2,
                     DropOffStation = true,
                     UploadStation = false,
                    IsAvailableStationInLine = true
                 },
                     #endregion

              #region   Stations in Line  480 / 2

                   new StationInLine
                 {
                      LineId = 2,
                      StationId =  20001,
                      StationInLineLocation = 0,
                     DropOffStation = false,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                  new StationInLine
                 {
                      LineId = 2,
                      StationId =  640,
                      StationInLineLocation = 1,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                 new StationInLine
                 {
                      LineId = 2,
                      StationId =  5602,
                      StationInLineLocation = 2,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                 new StationInLine
                 {
                      LineId = 2,
                      StationId =  4170,
                      StationInLineLocation = 3,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },
                     #endregion

              #region   Stations in Line  20

                   new StationInLine
                 {
                      LineId = 3,
                      StationId =  30136,
                      StationInLineLocation = 0,
                     DropOffStation = false,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                new StationInLine
                 {
                      LineId = 3,
                      StationId =  30279,
                      StationInLineLocation = 1,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                 new StationInLine
                 {
                      LineId = 3,
                      StationId =  30297,
                      StationInLineLocation = 2,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },


                  new StationInLine
                 {
                      LineId = 3,
                      StationId =  37837,
                      StationInLineLocation = 3,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                    new StationInLine
                 {
                      LineId = 3,
                      StationId =  30434,
                      StationInLineLocation = 4,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                       new StationInLine
                 {
                      LineId = 3,
                      StationId =  39582,
                      StationInLineLocation = 5,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                             new StationInLine
                 {
                      LineId = 3,
                      StationId =  30787,
                      StationInLineLocation = 6,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },


                             new StationInLine
                 {
                      LineId = 3,
                      StationId =  30734,
                      StationInLineLocation = 7,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                                         new StationInLine
                 {
                      LineId = 3,
                      StationId =  30515,
                      StationInLineLocation = 8,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                   new StationInLine
                 {
                      LineId = 3,
                      StationId =  39524,
                      StationInLineLocation = 9,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                     new StationInLine
                 {
                      LineId = 3,
                      StationId =  39522,
                      StationInLineLocation = 10,
                     DropOffStation = true,
                     UploadStation = false,
                    IsAvailableStationInLine = true
                 },
                #endregion

             #region Stations in Line 68
                new StationInLine
                 {
                      LineId = 4,
                      StationId = 1431  ,
                      StationInLineLocation = 0,
                     DropOffStation = false,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },
        new StationInLine
                 {
                      LineId = 4,
                      StationId = 3850 ,
                      StationInLineLocation =1 ,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },
                new StationInLine
                  {
                    LineId = 4,
                    StationId = 6066,
                    StationInLineLocation = 2 ,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                   },
                    new StationInLine
                    {
                        LineId = 4,
                        StationId = 4012,
                        StationInLineLocation = 3,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },    new StationInLine
                    {
                        LineId = 4,
                        StationId = 5949,
                        StationInLineLocation = 4,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },    new StationInLine
                    {
                        LineId = 4,
                        StationId = 1540,
                        StationInLineLocation = 5,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },    new StationInLine
                    {
                        LineId = 4,
                        StationId = 3099,
                        StationInLineLocation = 6,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },    new StationInLine
                    {
                        LineId = 4,
                        StationId = 9915,
                        StationInLineLocation =7 ,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },    new StationInLine
                    {
                        LineId = 4,
                        StationId = 4190,
                        StationInLineLocation = 8,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },    new StationInLine
                    {
                        LineId = 4,
                        StationId = 3609,
                        StationInLineLocation = 9,
                        DropOffStation = true,
                        UploadStation =false,
                        IsAvailableStationInLine = true
                    },

                   #endregion

             #region Stations in Line 551 
                   
               new StationInLine
                {
                    LineId = 5,
                    StationId =  35377,
                    StationInLineLocation = 0,
                    DropOffStation = false,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 5,
                    StationId =  36899,
                    StationInLineLocation = 1,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 5,
                    StationId =  39686,
                    StationInLineLocation = 2,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 5,
                    StationId =  37174,
                    StationInLineLocation = 3,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                 new StationInLine
                {
                    LineId = 5,
                    StationId =  35946,
                    StationInLineLocation = 4,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                  new StationInLine
                {
                    LineId = 5,
                    StationId = 37060,
                    StationInLineLocation = 5,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                 new StationInLine
                {
                    LineId = 5,
                    StationId =  36614,
                    StationInLineLocation = 6,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                  new StationInLine
                {
                    LineId = 5,
                    StationId =  26910,
                    StationInLineLocation = 7,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                     new StationInLine
                {
                    LineId = 5,
                    StationId =  26895,
                    StationInLineLocation = 8,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },
                 new StationInLine
                {
                    LineId = 5,
                    StationId =  20167,
                    StationInLineLocation = 9,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },
                       #endregion

             #region Stations in Line 1 

                 new StationInLine
                {
                    LineId = 6,
                    StationId =  41200,
                    StationInLineLocation = 0,
                    DropOffStation = false,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                   new StationInLine
                {
                    LineId = 6,
                    StationId =  41205,
                    StationInLineLocation = 1,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                       new StationInLine
                {
                    LineId = 6,
                    StationId =  43073,
                    StationInLineLocation = 2,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                       new StationInLine
                {
                    LineId = 6,
                    StationId =  43022,
                    StationInLineLocation = 3,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                               new StationInLine
                {
                    LineId = 6,
                    StationId =  43015,
                    StationInLineLocation = 4,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },


               new StationInLine
                {
                    LineId = 6,
                    StationId =  42335,
                    StationInLineLocation = 5,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                 new StationInLine
                {
                    LineId = 6,
                    StationId =  41209,
                    StationInLineLocation = 6,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                   new StationInLine
                {
                    LineId = 6,
                    StationId =  42506,
                    StationInLineLocation = 7,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },

                    new StationInLine
                {
                    LineId = 6,
                    StationId =  42501,
                    StationInLineLocation = 8,
                    DropOffStation = true,
                    UploadStation = true,
                IsAvailableStationInLine = true
                },


                    new StationInLine
                {
                    LineId = 6,
                    StationId =  42657,
                    StationInLineLocation = 9,
                    DropOffStation = true,
                    UploadStation = false,
                IsAvailableStationInLine = true
                },
                   #endregion

             #region Stations in Line 82 

                 new StationInLine
                 {
                      LineId = 7,
                      StationId =  37135,
                      StationInLineLocation = 0,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                  new StationInLine
                 {
                      LineId = 7,
                      StationId =  37027,
                      StationInLineLocation = 1,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },


                   new StationInLine
                 {
                      LineId = 7,
                      StationId =  37033,
                      StationInLineLocation = 2,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                      new StationInLine
                 {
                      LineId = 7,
                      StationId =  39794,
                      StationInLineLocation = 3,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                           new StationInLine
                 {
                      LineId = 7,
                      StationId =  39791,
                      StationInLineLocation = 4,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

              new StationInLine
                 {
                      LineId = 7,
                      StationId =  63180,
                      StationInLineLocation = 5,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },
               new StationInLine
                 {
                      LineId = 7,
                      StationId =  61211,
                      StationInLineLocation = 6,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                new StationInLine
                 {
                      LineId = 7,
                      StationId =  65287,
                      StationInLineLocation = 7,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },

                 new StationInLine
                 {
                      LineId = 7,
                      StationId =  63188,
                      StationInLineLocation = 8,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },


                   new StationInLine
                 {
                      LineId = 7,
                      StationId =  65268,
                      StationInLineLocation = 9,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },


                       new StationInLine
                 {
                      LineId = 7,
                      StationId =  63203,
                      StationInLineLocation = 10,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },


                new StationInLine
                 {
                      LineId = 7,
                      StationId =  63206,
                      StationInLineLocation = 11,
                     DropOffStation = true,
                     UploadStation = true,
                    IsAvailableStationInLine = true
                 },
                      #endregion

             #region Stations in Line  4

                   new StationInLine
                   {
                       LineId = 8,
                       StationId = 21486,
                       StationInLineLocation = 0,
                       DropOffStation = true,
                       UploadStation = true,
                       IsAvailableStationInLine = true
                   },

                    new StationInLine
                    {
                        LineId =8,
                        StationId = 21437,
                        StationInLineLocation = 1,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },


                new StationInLine
                {
                    LineId = 8,
                    StationId = 21574,
                    StationInLineLocation = 2,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },



                 new StationInLine
                 {
                     LineId = 8,
                     StationId = 25663,
                     StationInLineLocation = 3,
                     DropOffStation = true,
                     UploadStation = true,
                     IsAvailableStationInLine = true
                 },




                 new StationInLine
                 {
                     LineId = 8,
                     StationId = 25402,
                     StationInLineLocation = 4,
                     DropOffStation = true,
                     UploadStation = true,
                     IsAvailableStationInLine = true
                 },

                 new StationInLine
                 {
                     LineId = 8,
                     StationId = 23021,
                     StationInLineLocation = 5,
                     DropOffStation = true,
                     UploadStation = true,
                     IsAvailableStationInLine = true
                 },



                 new StationInLine
                 {
                     LineId = 8,
                     StationId = 21539,
                     StationInLineLocation = 6,
                     DropOffStation = true,
                     UploadStation = true,
                     IsAvailableStationInLine = true
                 },


                  new StationInLine
                  {
                      LineId = 8,
                      StationId = 23004,
                      StationInLineLocation = 7,
                      DropOffStation = true,
                      UploadStation = true,
                      IsAvailableStationInLine = true
                  },

                  new StationInLine
                  {
                      LineId = 8,
                      StationId = 23001,
                      StationInLineLocation = 8,
                      DropOffStation = true,
                      UploadStation = true,
                      IsAvailableStationInLine = true
                  },



                    new StationInLine
                    {
                        LineId = 8,
                        StationId = 22999,
                        StationInLineLocation = 9,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },


                    new StationInLine
                    {
                        LineId = 8,
                        StationId = 27246,
                        StationInLineLocation = 10,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },



                    new StationInLine
                    {
                        LineId = 8,
                        StationId = 22927,
                        StationInLineLocation = 11,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },


                  #endregion

             #region Stations in Line 3
new StationInLine
{
    LineId = 9,
    StationId = 15897,
    StationInLineLocation = 0,
    DropOffStation = false,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 19516,
    StationInLineLocation = 1,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 10720,
    StationInLineLocation = 2,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 14831,
    StationInLineLocation = 3,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 14827,
    StationInLineLocation = 4,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 14836,
    StationInLineLocation = 5,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 15231,
    StationInLineLocation = 6,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 19385,
    StationInLineLocation = 7,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 9,
    StationId = 11219,
    StationInLineLocation = 8,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},


new StationInLine
{
    LineId = 9,
    StationId = 11168,
    StationInLineLocation = 9,
    DropOffStation = true,
    UploadStation = false,
    IsAvailableStationInLine = true
},

#endregion

             #region Stations in Line 58

                new StationInLine
                {
                    LineId = 10,
                    StationId = 26156,
                    StationInLineLocation = 0,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },

                  new StationInLine
                  {
                      LineId = 10,
                      StationId = 26158,
                      StationInLineLocation = 1,
                      DropOffStation = true,
                      UploadStation = true,
                      IsAvailableStationInLine = true
                  },

                    new StationInLine
                    {
                        LineId = 10,
                        StationId = 26084,
                        StationInLineLocation = 2,
                        DropOffStation = true,
                        UploadStation = true,
                        IsAvailableStationInLine = true
                    },

                        new StationInLine
                        {
                            LineId =10,
                            StationId = 26080,
                            StationInLineLocation = 3,
                            DropOffStation = true,
                            UploadStation = true,
                            IsAvailableStationInLine = true
                        },

                new StationInLine
                {
                    LineId = 10,
                    StationId = 20033,
                    StationInLineLocation = 4,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 10,
                    StationId = 20327,
                    StationInLineLocation = 5,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 10,
                    StationId = 26107,
                    StationInLineLocation = 6,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 10,
                    StationId = 21139,
                    StationInLineLocation = 7,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 10,
                    StationId = 20265,
                    StationInLineLocation = 8,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },

                new StationInLine
                {
                    LineId = 10,
                    StationId = 26945,
                    StationInLineLocation = 9,
                    DropOffStation = true,
                    UploadStation = true,
                    IsAvailableStationInLine = true
                },
               
            #endregion

              #region Stations in Line 50
new StationInLine
{
    LineId = 11,
    StationId = 12158,
    StationInLineLocation = 0,
    DropOffStation = false,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 10378,
    StationInLineLocation = 1,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 11742,
    StationInLineLocation = 2,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 10377,
    StationInLineLocation = 3,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 10453,
    StationInLineLocation = 4,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 10871,
    StationInLineLocation = 5,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 19610,
    StationInLineLocation = 6,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 19323,
    StationInLineLocation = 7,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 11,
    StationId = 19613,
    StationInLineLocation = 8,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},


new StationInLine
{
    LineId = 11,
    StationId = 10255,
    StationInLineLocation = 9,
    DropOffStation = true,
    UploadStation = false,
    IsAvailableStationInLine = true
},

#endregion

             #region Stations in Line 541 
new StationInLine
{
    LineId = 12,
    StationId = 55637,
    StationInLineLocation = 0,
    DropOffStation = false,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 55400,
    StationInLineLocation = 1,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 55340,
    StationInLineLocation = 2,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 56733,
    StationInLineLocation = 3,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 54245,
    StationInLineLocation = 4,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 58118,
    StationInLineLocation = 5,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 57008,
    StationInLineLocation = 6,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 51410,
    StationInLineLocation = 7,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},
new StationInLine
{
    LineId = 12,
    StationId = 53408,
    StationInLineLocation = 8,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},


new StationInLine
{
    LineId = 12,
    StationId = 51470,
    StationInLineLocation = 9,
    DropOffStation = true,
    UploadStation = true,
    IsAvailableStationInLine = true
},


new StationInLine
{
    LineId = 12,
    StationId = 51451,
    StationInLineLocation = 10,
    DropOffStation = true,
    UploadStation = false,
    IsAvailableStationInLine = true
},

#endregion

            #region  Stations in Line 464 
            new StationInLine
            {
                LineId = 13,
                StationId = 6102,
                StationInLineLocation = 0,
                DropOffStation = false,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 2566,
                StationInLineLocation = 1,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 3022,
                StationInLineLocation = 2,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 60826,
                StationInLineLocation = 3,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 61152,
                StationInLineLocation = 4,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 61350,
                StationInLineLocation = 5,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 60901,
                StationInLineLocation = 6,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 60499,
                StationInLineLocation = 7,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },
            new StationInLine
            {
                LineId = 13,
                StationId = 65260,
                StationInLineLocation = 8,
                DropOffStation = true,
                UploadStation = true,
                IsAvailableStationInLine = true
            },


            new StationInLine
            {
                LineId = 13,
                StationId = 63231,
                StationInLineLocation = 9,
                DropOffStation = true,
                UploadStation = false,
                IsAvailableStationInLine = true
            },

            #endregion
            };

            #region  ListAllBuses = new List<Bus>
            {
                //initializing buses with Licensing Date before  2018
            for (int i = 0; i < 10; i++)
                {
                    ListAllBuses.Add(new Bus
                    {
                        LicenseNumber = r.Next(1000000, 9999999),
                        LicensingDate = new DateTime(r.Next(2010, 2018), r.Next(1, 13), 1),
                        DateOfLastCare = new DateTime(r.Next(2020, DateTime.Now.Year + 1), r.Next(1, DateTime.Now.Month + 1), r.Next(1, DateTime.Now.Day + 1)),
                        Km = r.Next(30000, 60000),
                        KmSinceLastCare = r.Next(0, 20001),
                        CurrentFuelContent = r.Next(0, 1201),
                        Status = DO.Enums.STATUS.READY,
                        IsAvailableBus = true,
                        IsAccessible = r.Next(0, 2) > 0,
                        IsFireSafety = r.Next(0, 2) > 0
                    });
                }

                // initializing buses with Licensing Date  after  2018
                for (int i = 0; i < 10; i++)
                {
                    ListAllBuses.Add(new Bus
                    {
                        LicenseNumber = r.Next(10000000, 99999999),
                        LicensingDate = new DateTime(r.Next(2018, 2020), 1, 1),
                        DateOfLastCare = new DateTime(r.Next(2020, DateTime.Now.Year + 1), r.Next(1, DateTime.Now.Month + 1), r.Next(1, DateTime.Now.Day + 1)),
                        Km = r.Next(30000, 60000),
                        KmSinceLastCare = r.Next(0, 20001),
                        CurrentFuelContent = r.Next(0, 1201),
                        Status = DO.Enums.STATUS.NOTREADY,
                        IsAvailableBus = true,
                        IsAccessible = r.Next(0, 2) > 0,
                        IsFireSafety = r.Next(0, 2) > 0
                    });
                }



            }


            #endregion

            ListAllUsers = new List<User>
            {
                  

            new User
            {
                UserName = "elinoy025",
                UserPassword = "#eli1111",              
                IsAvailableUser = true,
            },

            new User
            {
                UserName = "tamara2323",
                 UserPassword = "#tam2222",
                IsAvailableUser = true,
            }


            };

            ListAllAdmins = new List<Admin>
            {
                 new Admin
                   {
                       AdminName = "nuritus",
                       AdminPassword = "Nurit10!",
                       IsAvailableAdmin = true,
                    },

                    new Admin
                   {
                       AdminName = "yairgo",
                       AdminPassword = "Yair10!!",
                       IsAvailableAdmin = true,
                    },

                     new Admin
                   {
                       AdminName = "efratiamar",
                       AdminPassword = "Efrat10!",
                       IsAvailableAdmin = true,
                    },

                      new Admin
                   {
                       AdminName = "adina",
                       AdminPassword = "Adina10!",
                       IsAvailableAdmin = true,
                    },

                       new Admin
                   {
                       AdminName = "dzilbers",
                       AdminPassword = "DanZi10!",
                       IsAvailableAdmin = true,
                    },

                        new Admin
                   {
                       AdminName = "eliezergensburger",
                       AdminPassword = "Elieze1!",
                       IsAvailableAdmin = true,
                    }
            };


        }
    }
}










