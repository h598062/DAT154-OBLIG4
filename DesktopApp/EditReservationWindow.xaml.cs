using System;
using System.Windows;
using DatabaseLibrary.Models;

namespace DesktopApp
{
    public partial class EditReservationWindow : Window
    {
        public Bookingdata SelectedReservation { get; set; }

        public EditReservationWindow(Bookingdata selectedReservation)
        {
            InitializeComponent();

            SelectedReservation = selectedReservation;
            this.DataContext = SelectedReservation;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate.HasValue)
            {
                SelectedReservation.Startdato = StartDatePicker.SelectedDate.Value;
            }

            if (EndDatePicker.SelectedDate.HasValue)
            {
                SelectedReservation.Sluttdato = EndDatePicker.SelectedDate.Value;
            }

            if (!string.IsNullOrEmpty(AntallSengeplasserTextBox.Text))
            {
                SelectedReservation.AntallPersoner = int.Parse(AntallSengeplasserTextBox.Text);
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}