namespace UrbanProperties
{
    public class Space
    {
        public string Name { get; set; }
        public int SquareFeet { get; set; }
        public int Type { get; set; }

        public virtual int CalculatePrice()
        {
            int sum = 0;
            sum = SquareFeet * PriceSettings.Default.PerSquareFeet;
            return sum;
        }

    }

    public class CommercialSpace :Space
    {
        public int No_of_floors { get; set; }
        public int No_of_seats { get; set; }
        public int No_of_cabins { get; set; }
        public int No_of_toilets { get; set; }

        public override int CalculatePrice()
        {
            int sum = 0;
            sum = SquareFeet * PriceSettings.Default.PerSquareFeet;
            sum += No_of_floors * PriceSettings.Default.PerFloorCost;
            sum += No_of_seats * PriceSettings.Default.PerSeatCost;
            sum += No_of_cabins * PriceSettings.Default.PerCabinCost;
            sum += No_of_toilets * PriceSettings.Default.PerToiletCost;
            return sum;
        }

    }

    public class ResidentialSpace : Space
    {
        public int No_of_floors { get; set; }
        public int No_of_rooms { get; set; }
        public int No_of_kitchens { get; set; }
        public int No_of_toilets { get; set; }

        public override int CalculatePrice()
        {
            int sum = 0;
            sum = SquareFeet * PriceSettings.Default.PerSquareFeet;
            sum += No_of_floors * PriceSettings.Default.PerFloorCost;
            sum += No_of_rooms * PriceSettings.Default.PerRoomCost;
            sum += No_of_kitchens * PriceSettings.Default.PerKitchenCost;
            sum += No_of_toilets * PriceSettings.Default.PerToiletCost;
            return sum;
        }

    }


}