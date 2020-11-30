using System;
using System.Collections.Generic;

namespace Hamnen
{
    class Register
    {
        Harbour harbour = new Harbour();
        IfHarbourIsFull ifHarbourIsFull = new IfHarbourIsFull();
        public void AddPowerBoatArrival(Boat[] harbourList, List<Boat> rejectedBoats, int currentDay)
        {
            PowerBoat powerBoat = new PowerBoat();
            powerBoat.DayOfArrival = currentDay;
            powerBoat.DayToLeave = currentDay + powerBoat.DaysInHarbour;
            RegisterBoat(harbourList, rejectedBoats, powerBoat);
        }
        public void AddSailBoatArrival(Boat[] harbourList, List<Boat> rejectedBoats, int currentDay)
        {
            SailBoat sailBoat = new SailBoat();
            sailBoat.DayOfArrival = currentDay;
            sailBoat.DayToLeave = currentDay + sailBoat.DaysInHarbour;
            RegisterBoat(harbourList, rejectedBoats, sailBoat);
        }
        public void AddCargoShipArrival(Boat[] harbourList, List<Boat> rejectedBoats, int currentDay)
        {
            CargoShip cargoShip = new CargoShip();
            cargoShip.DayOfArrival = currentDay;
            cargoShip.DayToLeave = currentDay + cargoShip.DaysInHarbour;
            RegisterBoat(harbourList, rejectedBoats, cargoShip);
        }
        public void RegisterBoat(Boat[] harbourList, List<Boat> rejectedBoats, Boat boat)
        {
            int emptyDock = harbour.SearchForEmptyHarbourDock(harbourList);

            if (emptyDock == -1)
            {
                ifHarbourIsFull.IfBoatDoesNotFitInHarbour(boat, ref rejectedBoats);
            }
            else if (harbour.CheckIfBoatFitsInHarbour(harbourList, rejectedBoats, boat, ref emptyDock))
            {
                for (int i = 0; i < boat.HarbourDock; i++)
                {
                    harbourList[emptyDock + i] = boat;
                }
            }
        }
    }
}
