namespace UrbanProperties
{
    #region Interfaces
    interface Buildings
    {
        int GetNoOfToilets();
        void SetNoOfToilets(int Value);
        int GetNoOfFloors();
        void SetNoOfFloors(int Value);
    }

    interface Seats
    {
        int GetNoOfSeats();
        void SetNoOfSeats(int Value);
    }

    interface Rooms
    {
        int GetNoOfRooms();
        void SetNoOfRooms(int Value);
    }

    interface Cabins
    {
        int GetNoOfCabins();
        void SetNoOfCabins(int Value);
    }

    interface Kitchens
    {
        int GetNoOfKitchens();
        void SetNoOfKitchens(int Value);
    }
    #endregion

    public abstract class Space
    {
        public string Name { get; set; }
        public int SquareFeet { get; set; }
        public int Type { get; set; }
        public int Price => this.SquareFeet * PriceSettings.Default.PerSquareFeet;

        public abstract int CalculatePrice { get; }
    }

    public class EmptySpace : Space
    {
        public override int CalculatePrice => CalculatePriceforEmptySpace();
        public int CalculatePriceforEmptySpace()
        {
            return this.Price;
        }
    }

    public class CommercialSpace :Space, Buildings, Seats,Cabins
    {
        private int No_of_floors { get; set; }
        private int No_of_seats { get; set; }
        private int No_of_cabins { get; set; }
        private int No_of_toilets { get; set; }
        public override int CalculatePrice => CalculatePriceforCommercialSpace();

        public int GetNoOfToilets() { return No_of_toilets; }       
        public void SetNoOfToilets(int Value) { No_of_toilets = Value; }

        public int GetNoOfSeats() { return No_of_seats; }
        public void SetNoOfSeats(int Value) { No_of_seats = Value; }

        public int GetNoOfCabins() { return No_of_cabins; }
        public void SetNoOfCabins(int Value) { No_of_cabins = Value; }

        public int GetNoOfFloors() { return No_of_floors; }
        public void SetNoOfFloors(int Value) { No_of_floors = Value; }


        private int CalculatePriceforCommercialSpace()
        {           
            int sum = 0;
            sum = this.Price;
            sum += No_of_floors * PriceSettings.Default.PerFloorCost;
            sum += No_of_seats * PriceSettings.Default.PerSeatCost;
            sum += No_of_cabins * PriceSettings.Default.PerCabinCost;
            sum += No_of_toilets * PriceSettings.Default.PerToiletCost;
            return sum;
        }

    }

    public class ResidentialSpace : Space, Buildings,Rooms,Kitchens
    {
        private int No_of_floors { get; set; }
        private int No_of_rooms { get; set; }
        private int No_of_kitchens { get; set; }
        private int No_of_toilets { get; set; }
        public override int CalculatePrice => CalculatePriceforCommercialSpace();

        public int GetNoOfToilets() { return No_of_toilets; }
        public void SetNoOfToilets(int Value) { No_of_toilets = Value; }

        public int GetNoOfRooms() { return No_of_rooms; }
        public void SetNoOfRooms(int Value) { No_of_rooms = Value; }

        public int GetNoOfKitchens() { return No_of_kitchens; }
        public void SetNoOfKitchens(int Value) { No_of_kitchens = Value; }

        public int GetNoOfFloors() { return No_of_floors; }
        public void SetNoOfFloors(int Value) { No_of_floors = Value; }

        public int CalculatePriceforCommercialSpace()
        {
            int sum = 0;
            sum = this.Price;
            sum += No_of_floors * PriceSettings.Default.PerFloorCost;
            sum += No_of_rooms * PriceSettings.Default.PerRoomCost;
            sum += No_of_kitchens * PriceSettings.Default.PerKitchenCost;
            sum += No_of_toilets * PriceSettings.Default.PerToiletCost;
            return sum;
        }

    }


}