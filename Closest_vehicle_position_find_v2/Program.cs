using NetTopologySuite.Geometries;
using NetTopologySuite.Index.KdTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Closest_vehicle_position_find_v2
{

    class Program
    {
        static void Main(string[] args)
        {
            var totalStopwatch = Stopwatch.StartNew();
            string filePath = "VehiclePositions.dat";
            float[,] coordinates = {
        { 34.544909f, -102.100843f },
        { 32.345544f, -99.123124f },
        { 33.234235f, -100.214124f },
        { 35.195739f, -95.348899f },
        { 31.895839f, -97.789573f },
        { 32.895839f, -101.789573f },
        { 34.115839f, -100.225732f },
        { 32.335839f, -99.992232f },
        { 33.535339f, -94.792232f },
        { 32.234235f, -100.222222f }
    };
            var loadDataStopwatch = Stopwatch.StartNew();
            var data = new VehiclePositionsLoader(filePath);
            NearestVehiclePositionFinder finder = new NearestVehiclePositionFinder(data.Load());

            // Stop stopwatch for loading data
            loadDataStopwatch.Stop();

            // Start stopwatch for finding positions
            var findPositionsStopwatch = Stopwatch.StartNew();


            int[] nearestPositions = new int[coordinates.GetLength(0)];
            // Stop stopwatch for finding positions
            findPositionsStopwatch.Stop();

            // Calculate total execution time
           

            for (int i = 0; i < coordinates.GetLength(0); i++)
            {
                VehiclePosition nearestPosition = finder.FindNearestPosition(coordinates[i, 0], coordinates[i, 1]);
                nearestPositions[i] = nearestPosition.PositionId;
            }

            for (int i = 0; i < nearestPositions.Length; i++)
            {
                Console.WriteLine($"Position {i + 1}: {nearestPositions[i]}");
            }

            // Stop total stopwatch
            totalStopwatch.Stop();

            // Output timings
            Console.WriteLine($"Data load time: {loadDataStopwatch.Elapsed}");
            Console.WriteLine($"Position finding time: {findPositionsStopwatch.Elapsed}");
            Console.WriteLine($"Total execution time: {totalStopwatch.Elapsed}");
        }

    }

}
