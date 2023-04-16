using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest_vehicle_position_find_v2
{
    public class VehiclePosition
    {
        public VehiclePosition(int positionId, string vehicleRegistration, float latitude, float longitude, ulong recordedTimeUTC)
        {
            PositionId = positionId;
            VehicleRegistration = vehicleRegistration;
            Latitude = latitude;
            Longitude = longitude;
            RecordedTimeUTC = recordedTimeUTC;
        }

        public int PositionId { get; set; }
        public string VehicleRegistration { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public ulong RecordedTimeUTC { get; set; }
    }

}
