namespace BudgetingApp;

using SQLite;

public class Database
{
    static string sqliteFilename = "budgeting.db3";
    static string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    static string path = Path.Combine(libraryPath, sqliteFilename);
    public static SQLiteConnection conn = new SQLiteConnection(path);

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

