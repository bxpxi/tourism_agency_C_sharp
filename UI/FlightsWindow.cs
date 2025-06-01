using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Domain;
using Service;
using Service.observer;

namespace UI
{
    public partial class FlightsWindow : AppForm, IObserver
    {
        public FlightsWindow(IAppService appService) : base(appService)
        {
            Login();
            InitializeComponent();

            FlightsBinding = new BindingList<Flight>(Flights);
            FlightsView.DataSource = FlightsBinding;

            FilteredFlightsBinding = new BindingList<FilteredFlight>(FilteredFlights);
            FilteredFlightsView.DataSource = FilteredFlightsBinding;

            ShowFlights(AppService.FindFlights());
            DatePicker.Value = DateTime.Now.Date;
        }

        Employee Employee;
        List<Flight> Flights = new List<Flight>();
        BindingList<Flight> FlightsBinding;
        List<FilteredFlight> FilteredFlights = new List<FilteredFlight>();
        BindingList<FilteredFlight> FilteredFlightsBinding;

        void Login()
        {
            var loginForm = new LoginWindow(AppService, this);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Employee = loginForm.ConnectedEmployee;
            }
        }

        void ShowFlights(IEnumerable<Flight> flights)
        {
            Flights.Clear();
            Flights.AddRange(flights.Where(f => f.AvailableSeats > 0));
            FlightsBinding.ResetBindings();
        }

        void ShowFilteredFlights()
        {
            FilteredFlights.Clear();
            //FilteredFlights.AddRange(flights.Select(s => new FilteredFlight(s)));

            FilteredFlights.AddRange(Flights
                .Where(flight => flight.Destination.Equals(DestinationBox.Text, StringComparison.OrdinalIgnoreCase)
                                 && flight.DepartureDate == DatePicker.Value.Date.ToString("dd-MM-yyyy") && flight.AvailableSeats > 0)
                .Select(f => new FilteredFlight(f)));

            Console.WriteLine($"Found {FilteredFlights.Count} flights");

            FilteredFlightsBinding.ResetBindings();
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowFilteredFlights();
            //ShowFilteredFlights(AppService.FindByDestinationAndDepartureDate(DestinationBox.Text, DatePicker.Value.Date.ToString("dd-MM-yyyy")));
        }

        private void DestinationBox_TextChanged(object sender, EventArgs e)
        {
            ShowFilteredFlights();
            //ShowFilteredFlights(AppService.FindByDestinationAndDepartureDate(DestinationBox.Text, DatePicker.Value.Date.ToString("dd-MM-yyyy")));
        }

        private void FlightsView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = FlightsView.Rows[e.RowIndex];
            int availableSeats = Convert.ToInt32(row.Cells["availableSeats"].Value);
            /*
            if (availableSeats <= 0)
            {
                //row.Visible = false;
                ShowFilteredFlights();
                ShowFilteredFlights();

            }
            */
        }

        private void FlightsView_SelectionChanged(object sender, EventArgs e)
        {
            if (FlightsView.SelectedCells.Count == 1)
            {
                FlightsView.Rows[FlightsView.SelectedCells[0].RowIndex].Selected = true;
            }
            else if (FlightsView.SelectedRows.Count == 1)
            {

            }
        }

        Flight SelectedFlight
        {
            get
            {
                if (FilteredFlightsView.SelectedRows.Count == 0)
                {
                    return null;
                }

                return (FilteredFlightsView.SelectedRows[0].DataBoundItem as FilteredFlight).Flight;
            }
        }

        private void FilteredFlightsView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = FilteredFlightsView.Rows[e.RowIndex];
            int availableSeats = Convert.ToInt32(row.Cells["availableSeats"].Value);
            /*
            if (availableSeats <= 0)
            {
                //row.Visible = false;
                ShowFilteredFlights();
                ShowFilteredFlights();
            }
            */
        }

        private void FilteredFlightsView_SelectionChanged(object sender, EventArgs e)
        {
            if (FilteredFlightsView.SelectedCells.Count == 1)
            {
                FilteredFlightsView.Rows[FilteredFlightsView.SelectedCells[0].RowIndex].Selected = true;
            }
            else if (FilteredFlightsView.SelectedRows.Count == 1)
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            var clientName = ClientNameBox.Text;
            var noOfSeats = Convert.ToInt32(NoOfSeatsBox.Text);
            var flight = SelectedFlight;

            if (flight == null)
            {
                MessageBox.Show("Please select a flight");
                return;
            }

            if (clientName.Length == 0)
            {
                MessageBox.Show("Please enter a client name");
                return;
            }

            if (noOfSeats <= 0)
            {
                MessageBox.Show("Please enter a valid number of seats");
                return;
            }

            try
            {
                AppService.BuyTicket(flight, clientName, noOfSeats);
                MessageBox.Show("Ticket bought for " + clientName);
                //ShowFlights(AppService.FindFlights());
                //ShowFilteredFlights();
                //ShowFilteredFlights(AppService.FindByDestinationAndDepartureDate(DestinationBox.Text, DatePicker.Value.Date.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateFlight(Flight flight)
        {
            /*
            BeginInvoke(new Action(() =>
            {
                foreach (var f in Flights)
                    if (flight.Id == f.Id)
                    {
                        f.AvailableSeats = flight.AvailableSeats;
                        break;
                    }

                foreach (var f in FilteredFlights)
                {
                    if (flight.Id == f.Flight.Id)
                    {
                        f.Flight.AvailableSeats = flight.AvailableSeats;
                        break;
                    }
                }

                FlightsBinding.ResetBindings();
                FilteredFlightsBinding.ResetBindings();
            }));
            */
            BeginInvoke(new Action(() =>
            {
                // Refacem întreaga listă de zboruri, eliminând cele cu 0 locuri
                ShowFlights(AppService.FindFlights());
                ShowFilteredFlights();
            }));
        }
    }
    
    class FilteredFlight
    {
        public FilteredFlight(Flight flight)
        {
            Flight = flight;
        }

        [Browsable(false)] public Flight Flight { get; }

        //public string Destination => Flight.Destination;
        //public string DepartureDate => Flight.DepartureDate;
        public string DepartureTime => Flight.DepartureTime;
        public string Airport => Flight.Airport;
        public int AvailableSeats => Flight.AvailableSeats;

    }
}