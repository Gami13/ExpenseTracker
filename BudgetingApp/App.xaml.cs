using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace BudgetingApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Database.CreateDatabase();
        MainPage = new AppShell();
        LiveCharts.Configure(config =>
               config.AddSkiaSharp()

                   // adds the default supported types
                   // OPTIONAL but highly recommend
                   .AddDefaultMappers()

                   // select a theme, default is Light
                   // OPTIONAL
                   .AddDarkTheme()
               //.AddLightTheme()




               );

    }
}
