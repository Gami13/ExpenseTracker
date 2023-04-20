namespace BudgetingApp;

using SQLite;

public class Database
{

    public enum sortBy
    {
        DATE, PRICE, SHOP
    }
    static public sortBy selectedSort = sortBy.DATE;
    public const int defaultDays = 19464;
    static public int days = defaultDays;
    static public bool isReverse = false;

    static string sqliteFilename = "budgeting.db3";
    static string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    static string path = Path.Combine(libraryPath, sqliteFilename);
    public static SQLiteConnection conn = new SQLiteConnection(path);
    public static List<Database.ShoppingTrip> shoppingTrips;
    [Table("shoppingTrip")]
    public class ShoppingTrip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Shop { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Double Price { get; set; }
    }

    [Table("purchases")]
    public class Purchase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public int shoppingTripId { get; set; }
    }


    public static void CreateDatabase()
    {
        conn.CreateTable<ShoppingTrip>();
        conn.CreateTable<Purchase>();


    }
    public static List<ShoppingTrip> getAllTrips()
    {
        List<ShoppingTrip> shoppingTrips = conn.Table<ShoppingTrip>().ToList();
        switch (selectedSort)
        {
            case sortBy.DATE:
                if (isReverse)
                {
                    shoppingTrips = shoppingTrips.OrderByDescending(x => x.Date).ToList();
                }
                else
                {
                    shoppingTrips = shoppingTrips.OrderBy(x => x.Date).ToList();
                }
                break;
            case sortBy.PRICE:
                if (isReverse)
                {
                    shoppingTrips = shoppingTrips.OrderByDescending(x => x.Price).ToList();
                }
                else
                {
                    shoppingTrips = shoppingTrips.OrderBy(x => x.Price).ToList();
                }
                break;
            case sortBy.SHOP:
                if (isReverse)
                {
                    shoppingTrips = shoppingTrips.OrderByDescending(x => x.Shop).ToList();
                }
                else
                {
                    shoppingTrips = shoppingTrips.OrderBy(x => x.Shop).ToList();
                }
                break;
            default:
                break;
        }
        //in days
        shoppingTrips = shoppingTrips.Where(x => (DateTime.Now - x.Date).TotalDays < days).ToList();
        Database.shoppingTrips = shoppingTrips;
        return shoppingTrips;
    }
    public static void addTrip(ShoppingTrip trip)
    {
        conn.Insert(trip);
    }

    public static List<Purchase> desuGetAllPurchaches(string id)
    {
        int intid = Int32.Parse(id);
        List<Purchase> pur = conn.Table<Purchase>().Where(x => x.shoppingTripId == intid).ToList();

        return pur;
    }

    public static ShoppingTrip desuGetShoppingTrip(string id)
    {
        int intid = Int32.Parse(id);
        ShoppingTrip pur = conn.Table<ShoppingTrip>().Where(x => x.Id == intid).First();

        return pur;
    }

    public static int getMaxTripId()
    {
        try
        {
            int maxId = conn.Table<ShoppingTrip>().OrderByDescending(x => x.Id).FirstOrDefault().Id;
            return maxId;
        }
        catch
        {
            return 0;
        }
    }
    public static void addPurchase(Purchase purchase)
    {
        conn.Insert(purchase);
    }

}

