using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest_vehicle_position_find_v2
{
    public class NearestVehiclePositionFinder
    {
        private readonly List<VehiclePosition> _vehiclePositions;

        /// <summary>
        /// Constructor for NearestVehiclePositionFinder class which takes a list of VehiclePosition objects as input.
        /// </summary>
        /// <param name="vehiclePositions">List of VehiclePosition objects</param>
        /// <returns>NearestVehiclePositionFinder object</returns>
        public NearestVehiclePositionFinder(IEnumerable<VehiclePosition> vehiclePositions)
        {
            _vehiclePositions = vehiclePositions.ToList();
        }

        /// <summary>
        /// Finds the nearest VehiclePosition from the given latitude and longitude.
        /// </summary>
        /// <param name="latitude">The latitude of the position to search from.</param>
        /// <param name="longitude">The longitude of the position to search from.</param>
        /// <returns>The nearest VehiclePosition.</returns>
        // Rewritten code with comments
        public VehiclePosition FindNearestPosition(float latitude, float longitude)
        {
            // Initialize minDistanceSquared to the maximum possible float value
            var minDistanceSquared = float.MaxValue;
            // Initialize nearestPosition to null
            VehiclePosition nearestPosition = null;
            // Iterate through each position in _vehiclePositions
            foreach (var position in _vehiclePositions)
            {
                // Calculate the difference between the given latitude and the current position's latitude
                var xDifference = latitude - position.Latitude;
                // Calculate the difference between the given longitude and the current position's longitude
                var yDifference = longitude - position.Longitude;
                // Calculate the distance squared between the given coordinates and the current position
                var distanceSquared = xDifference * xDifference + yDifference * yDifference;
                // If the distance squared is less than the current minDistanceSquared
                if (distanceSquared < minDistanceSquared)
                {
                    // Set minDistanceSquared to the new distance squared
                    minDistanceSquared = distanceSquared;
                    // Set nearestPosition to the current position
                    nearestPosition = position;
                }
            }
            // Return the nearest position
            return nearestPosition;
        }

        /// <summary>
        /// Calculates the squared distance between two points.
        /// </summary>
        /// <param name="lat1">The latitude of the first point.</param>
        /// <param name="lon1">The longitude of the first point.</param>
        /// <param name="lat2">The latitude of the second point.</param>
        /// <param name="lon2">The longitude of the second point.</param>
        /// <returns>The squared distance between the two points.</returns>
        private static float CalculateDistanceSquared(float lat1, float lon1, float lat2, float lon2)
        {
            var latDiff = lat2 - lat1;
            var lonDiff = lon2 - lon1;
            return latDiff * latDiff + lonDiff * lonDiff;
        }
    }

}
