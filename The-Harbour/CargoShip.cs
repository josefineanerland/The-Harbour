namespace Hamnen
{
    class CargoShip : Boat
    {
        public CargoShip()
        {
            Id = "C-" + GenerateRandomId();
            Type = "Cargoship";
            HarbourDock = 4;
            DaysInHarbour = 6;
        }
    }
}
