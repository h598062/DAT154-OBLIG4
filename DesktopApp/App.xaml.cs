using System.Configuration;
using System.Data;
using System.Windows;
using DatabaseLibrary.Context;
using Microsoft.EntityFrameworkCore;

namespace DesktopApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    
    public static Oblig4Context DbContext { get; private set; }
    public App()
    {
        var optionsBuilder = new DbContextOptionsBuilder<Oblig4Context>();
        optionsBuilder.UseSqlServer("Server=tcp:dat154-2024-gruppe13.database.windows.net,1433;Initial Catalog=oblig4;Persist Security Info=False;User ID=bigggusdikkus;Password=Belletiss2024!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        DbContext = new Oblig4Context(optionsBuilder.Options);
        this.DispatcherUnhandledException += OnDispatcherUnhandledException;
    }

    void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        string errorMessage = string.Format("An unhandled exception occurred: {0} - Inner Exception: {1}", e.Exception.Message, e.Exception.InnerException?.Message);
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        e.Handled = true;
    }
}