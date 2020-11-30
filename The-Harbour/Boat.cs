using System;

namespace Hamnen
{
    abstract class Boat
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int HarbourDock { get; set; }
        public int DaysInHarbour { get; set; }
        public int DayOfArrival { get; set; }
        public int DayToLeave { get; set; }

        public string GenerateRandomId()
        {
            Random random = new Random();
            string Id = "";

            for (int i = 0; i < 3; i++)
            {
                int randomChars = random.Next(65, 91);
                Id += (char)randomChars;
            }

            return Id;
        }
    }
}
