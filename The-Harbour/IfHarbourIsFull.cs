using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen
{
    class IfHarbourIsFull
    {
        public void IfBoatDoesNotFitInHarbour(Boat boat, ref List<Boat> rejectedBoats)
        {
            rejectedBoats.Add(boat);
        }
        public void ShowAllRejectedBoats(List<Boat> rejectedBoats)
        {
            Console.WriteLine($"Total number of rejected boats: {rejectedBoats.Count}");
            Console.WriteLine($"ID of rejected boats: ");

            foreach (var item in rejectedBoats)
            {
                Console.WriteLine(item.Id);
            }

        }
    }
}
