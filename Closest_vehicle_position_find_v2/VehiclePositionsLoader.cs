using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest_vehicle_position_find_v2
{
    public class VehiclePositionsLoader
    {
        private readonly string _filePath;

        /// <summary>
        /// Constructor for VehiclePositionsLoader class.
        /// </summary>
        /// <param name="filePath">The path of the file to be loaded.</param>
        /// <returns>
        /// An instance of VehiclePositionsLoader.
        /// </returns>
        public VehiclePositionsLoader(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Loads vehicle positions from a binary file.
        /// </summary>
        /// <returns>
        /// An enumerable of VehiclePosition objects.
        /// </returns>
        public IEnumerable<VehiclePosition> Load()
        {
            // Create a memory mapped file from the file path
            using (var mmf = MemoryMappedFile.CreateFromFile(_filePath, FileMode.Open))
            {
                // Create a view accessor from the memory mapped file
                using (var accessor = mmf.CreateViewAccessor())
                {
                    // Initialize the position to 0
                    long position = 0;
                    // Calculate the size of a record
                    int recordSize = sizeof(int) + sizeof(float) * 2 + sizeof(ulong);

                    // Loop through the accessor until the end of the capacity is reached
                    while (position < accessor.Capacity)
                    {
                        // Check if there are enough bytes remaining in the accessor to read a full record
                        if (accessor.Capacity - position < recordSize)
                        {
                            // If not, break out of the loop
                            break;
                        }

                        // Read the position ID from the accessor
                        var positionId = accessor.ReadInt32(position);
                        // Increment the position by the size of an int
                        position += sizeof(int);

                        // Read the vehicle registration from the accessor
                        var vehicleRegistration = Utility.ReadNullTerminatedString(accessor, ref position, Encoding.ASCII);

                        // Read the latitude from the accessor
                        var latitude = accessor.ReadSingle(position);
                        // Increment the position by the size of a float
                        position += sizeof(float);

                        // Read the longitude from the accessor
                        var longitude = accessor.ReadSingle(position);
                        // Increment the position by the size of a float
                        position += sizeof(float);

                        // Read the recorded time in UTC from the accessor
                        var recordedTimeUTC = accessor.ReadUInt64(position);
                        // Increment the position by the size of an unsigned long
                        position += sizeof(ulong);

                        // Return a new VehiclePosition object
                        yield return new VehiclePosition(positionId, vehicleRegistration, latitude, longitude, recordedTimeUTC);
                    }
                }
            }
        }






    }

}
