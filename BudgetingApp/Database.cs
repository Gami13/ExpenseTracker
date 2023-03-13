namespace BudgetingApp;

using Microsoft.Maui.Storage;
using SQLite;
using System.Data.Common;
using System.Runtime.CompilerServices;

public class Database
{
    static string sqliteFilename = "budgeting.db3";
    static string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    static string path = Path.Combine(libraryPath, sqliteFilename);
    public static SQLiteConnection conn = new SQLiteConnection(path);

    [Table("shoppingTrip")]
    public class shoppingTrip
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
        conn.CreateTable<shoppingTrip>();
        conn.CreateTable<Purchase>();
     

    }
    public static List<shoppingTrip> getAllTrips()
    {
        List<shoppingTrip> shoppingTrips = conn.Table<shoppingTrip>().ToList();
       
        return shoppingTrips;
    }
    public static void addTrip(shoppingTrip trip)
    {
        conn.Insert(trip);
    }
    public static int getMaxTripId()
    {
        int maxId = conn.Table<shoppingTrip>().OrderByDescending(x => x.Id).FirstOrDefault().Id;
        return maxId;
    }
    public static void addPurchase(Purchase purchase)
    {
        conn.Insert(purchase);
    }
}

