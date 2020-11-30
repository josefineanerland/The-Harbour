using System;
using System.Collections.Generic;
using System.Linq;

namespace Hamnen
{
    class Harbour
    {
        public int CurrentDay { get; set; } = 1;

        public void RegisterNewBoats()
        {
            int PbIndex = 1;
            int SbIndex = 2;
            int CgIndex = 3;
            int BoatsPerDay = 5;
            Register register = new Register();
            Random rnd = new Random();
            ConsoleKey key;
            Boat[] harbourList = new Boat[25];
            List<Boat> boatRejected = new List<Boat>();

            do
            {
                for (int i = 0; i < BoatsPerDay; i++)
                {
                    int boatIndex = rnd.Next(1, 4);

                    if (boatIndex == PbIndex)
                    {
                        register.AddPowerBoatArrival(harbourList, boatRejected, CurrentDay);
                    }
                    else if (boatIndex == SbIndex)
                    {
                        register.AddSailBoatArrival(harbourList, boatRejected, CurrentDay);
                    }
                    else if (boatIndex == CgIndex)
                    {
                        register.AddCargoShipArrival(harbourList, boatRejected, CurrentDay);
                    }
                }

                BoatsLeavingHarbour(harbourList, CurrentDay);
                PrintAllBoatsInHarbour(harbourList);
                Console.WriteLine("");
                ifHarbourIsFull.ShowAllRejectedBoats(boatRejected);
                key = Console.ReadKey().Key;
            }
            while (key == ConsoleKey.Enter);
        }

        public int SearchForEmptyHarbourDock(Boat[] harbour, int searchIndex = 0)
        {
            int harbourDock = 0;
            Boat findDock = harbour.Where(x => x == null).FirstOrDefault();

            if (searchIndex == 0)
            {
                harbourDock = Array.IndexOf(harbour, findDock);
            }
            else
            {
                harbourDock = Array.IndexOf(harbour, findDock, searchIndex);
            }

            return harbourDock;
        }

        public void BoatsLeavingHarbour(Boat[] harbour, int currentDay)
        {
            for (int i = 0; i < harbour.Length; i++)
            {
                Boat boat = harbour[i];

                if (boat != null)
                {
                    if (boat.DayToLeave == currentDay)
                    {
                        harbour[i] = null;
                    }
                }
            }
        }

        public bool CheckIfBoatFitsInHarbour(Boat[] harbourList, List<Boat> rejectedBoats, Boat boat, ref int emptyDock)
        {
            for (int i = 0; i < boat.HarbourDock; i++)
            {
                int harbourDockIndex = emptyDock + i;

                if (harbourDockIndex == -1 || harbourDockIndex >= 25)
                {
                    ifHarbourIsFull.IfBoatDoesNotFitInHarbour(boat, ref rejectedBoats);
                    return false;
                }

                if (harbourList[harbourDockIndex] != null)
                {
                    emptyDock = SearchForEmptyHarbourDock(harbourList, harbourDockIndex);

                    if (emptyDock < 25)
                    {
                        i = -1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public void PrintAllBoatsInHarbour(Boat[] harbour)
        {
            Console.Clear();
            Console.WriteLine($"Current Day: Day {CurrentDay++}");
            Console.WriteLine("");
            Console.WriteLine($"{"Dock",-5} {"Boat",-15} {"Boat ID",-15}");
            int dock = 1;

            foreach (var item in harbour)
            {
                if (item != null)
                {
                    Console.WriteLine($"{dock,-5} {item.Type,-15} {item.Id,-15}");
                }
                else
                {
                    Console.WriteLine($"{dock,-5} {" "}");
                }
                dock++;
            }

            Console.WriteLine("Press enter to skip to the next day.");
        }

        IfHarbourIsFull ifHarbourIsFull = new IfHarbourIsFull();
    }
}