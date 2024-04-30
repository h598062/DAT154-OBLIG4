using System.Windows;
using DatabaseLibrary.Context;
using DatabaseLibrary.Models;

namespace DesktopApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<Maintenance_requests> MaintenanceRequestsList { get; set; }
    public List<Cleaning> CleaningList { get; set; }
    public List<Roomservice_requests> RoomserviceRequestsList { get; set; }
    
    public MainWindow()
    {
        InitializeComponent();

        using (var context = new Oblig4Context())
        {
            MaintenanceRequestsList = context.Maintenance_requests.ToList();
            CleaningList = context.Cleaning.ToList();
            RoomserviceRequestsList = context.Roomservice_requests.ToList();
        }

        DataContext = this;
    }

    private void AddRoom_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EditRoom_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DeleteRoom_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddReservation_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EditReservation_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DeleteReservation_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddRequest_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EditRequest_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DeleteRequest_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddCleaning_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EditCleaning_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DeleteCleaning_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddRoomServiceRequest_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EditRoomServiceRequest_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DeleteRoomService_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}