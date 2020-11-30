namespace Hamnen
{
    class SailBoat : Boat
    {
        public SailBoat()
        {
            Id = "S-" + GenerateRandomId();
            Type = "Sailboat";
            HarbourDock = 2;
            DaysInHarbour = 4;
        }
    }
}
