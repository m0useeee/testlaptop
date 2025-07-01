using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    public class Transport<TType, TRoute>
    {
        public TType TransportTypeCode { get; set; }
        public string TransportTypeName { get; set; }
        public string VehicleNumber { get; set; }
        public TRoute RouteNumber { get; set; }
        public double RouteLength { get; set; }
        public int DriverBadgeNumber { get; set; }
        public DateTime DepartureDate { get; set; }

        public Transport()
        {
            TransportTypeCode = default;
            TransportTypeName = "Не указано";
            VehicleNumber = "Не указан";
            RouteNumber = default;
            RouteLength = 0.0;
            DriverBadgeNumber = 0;
            DepartureDate = DateTime.Now;
        }
        static public double CalculateTotalKilometers(List<Transport<int, string>> data)
        {
            double totalKilometers = 0;
            foreach (Transport<int, string> transport in data)
            {
                totalKilometers += transport.RouteLength;
            }
            return totalKilometers;
        }
    }
}
