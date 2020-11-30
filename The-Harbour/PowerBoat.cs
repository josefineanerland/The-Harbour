namespace Hamnen
{
    class PowerBoat : Boat
    {
        public PowerBoat()
        {
            Id = "P-" + GenerateRandomId();
            Type = "Powerboat";
            HarbourDock = 1;
            DaysInHarbour = 3;
        }
    }
}
