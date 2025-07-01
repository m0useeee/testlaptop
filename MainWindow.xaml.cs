using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace zad5
{
    public partial class MainWindow : Window
    {
        private List<Transport<int, string>> transportData = new List<Transport<int, string>>();

        public MainWindow()
        {
            InitializeComponent();
            RouteComboBox.SelectedIndex = 0;
            TransportTypeComboBox.SelectedIndex = 0;
            Transport<int, string> bus1 = new Transport<int, string> { TransportTypeCode = 1, TransportTypeName = "Автобус", VehicleNumber = "AA123BB", RouteNumber = "10", RouteLength = 15.5, DriverBadgeNumber = 101, DepartureDate = DateTime.Now };
            Transport<int, string> tram1 = new Transport<int, string> { TransportTypeCode = 2, TransportTypeName = "Трамвай", VehicleNumber = "CC456DD", RouteNumber = "5", RouteLength = 8.2, DriverBadgeNumber = 202, DepartureDate = DateTime.Now };
            Transport<int, string> bus2 = new Transport<int, string> { TransportTypeCode = 1, TransportTypeName = "Автобус", VehicleNumber = "EE789FF", RouteNumber = "10", RouteLength = 15.5, DriverBadgeNumber = 303, DepartureDate = DateTime.Now };
            Transport<int, string> metro1 = new Transport<int, string> { TransportTypeCode = 3, TransportTypeName = "Метро", VehicleNumber = "GG012HH", RouteNumber = "A", RouteLength = 20.0, DriverBadgeNumber = 404, DepartureDate = DateTime.Now };
            transportData.Add(bus1);
            transportData.Add(tram1);
            transportData.Add(bus2);
            transportData.Add(metro1);

            dataGrid.ItemsSource = transportData;
        }
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedTransportType = (string)TransportTypeComboBox.SelectedItem;
            string selectedRoute = (string)RouteComboBox.SelectedItem;
            string report = "";
            List<Transport<int, string>> filteredData = new List<Transport<int, string>>(transportData);
            if (!string.IsNullOrEmpty(selectedTransportType))
            {
                List<Transport<int, string>> temp = new List<Transport<int, string>>();
                foreach (Transport<int, string> transport in filteredData)
                {
                    if (transport.TransportTypeName == selectedTransportType)
                    {
                        temp.Add(transport);
                    }
                }
                filteredData = temp;
                report += $"Тип транспорта: {selectedTransportType}\n";
            }
            if (!string.IsNullOrEmpty(selectedRoute))
            {
                List<Transport<int, string>> temp = new List<Transport<int, string>>();
                foreach (Transport<int, string> transport in filteredData)
                {
                    if (transport.RouteNumber == selectedRoute)
                    {
                        temp.Add(transport);
                    }
                }
                filteredData = temp;
                report += $"Маршрут: {selectedRoute}\n";
            }
            double totalKilometers = Transport<int, string>.CalculateTotalKilometers(filteredData);
            report += $"Общий километраж (по выбранным критериям): {totalKilometers:F2}\n\n";
            double selectedTransportKilometers = 0;
            if (!string.IsNullOrEmpty(selectedTransportType))
            {
                List<Transport<int, string>> transportTypeData = new List<Transport<int, string>>();
                foreach (Transport<int, string> transport in transportData)
                {
                    if (transport.TransportTypeName == selectedTransportType)
                    {
                        transportTypeData.Add(transport);
                    }
                }
                selectedTransportKilometers = Transport<int, string>.CalculateTotalKilometers(transportTypeData);
                report += $"Общий километраж для типа транспорта {selectedTransportType}: {selectedTransportKilometers:F2} км\n";
            }
            else
            {
                report += "Тип транспорта не выбран.\n";
            }
            double selectedRouteKilometers = 0;
            if (!string.IsNullOrEmpty(selectedRoute))
            {
                List<Transport<int, string>> routeData = new List<Transport<int, string>>();
                foreach (Transport<int, string> transport in transportData)
                {
                    if (transport.RouteNumber == selectedRoute)
                    {
                        routeData.Add(transport);
                    }
                }
                selectedRouteKilometers = Transport<int, string>.CalculateTotalKilometers(routeData);
                report += $"Общий километраж для маршрута {selectedRoute}: {selectedRouteKilometers:F2} км\n";
            }
            else
            {
                report += "Маршрут не выбран.\n";
            }

            textBoxRep.Text = report;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> transportTypes = new List<string>();
            foreach (Transport<int, string> transport in transportData)
            {
                if (!transportTypes.Contains(transport.TransportTypeName))
                {
                    transportTypes.Add(transport.TransportTypeName);
                }
            }
            TransportTypeComboBox.ItemsSource = transportTypes;
            List<string> routes = new List<string>();
            foreach (Transport<int, string> transport in transportData)
            {
                if (!routes.Contains(transport.RouteNumber))
                {
                    routes.Add(transport.RouteNumber);
                }
            }
            RouteComboBox.ItemsSource = routes;
        }
    }
}