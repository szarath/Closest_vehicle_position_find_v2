using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest_vehicle_position_find_v2
{
    public static class Utility
    {

        /// <summary>
        /// Reads a null-terminated string from a MemoryMappedViewAccessor.
        /// </summary>
        /// <param name="accessor">The MemoryMappedViewAccessor to read from.</param>
        /// <param name="position">The position in the MemoryMappedViewAccessor to start reading from.</param>
        /// <param name="encoding">The encoding to use when converting the bytes to a string.</param>
        /// <returns>The string read from the MemoryMappedViewAccessor.</returns>
        public static string ReadNullTerminatedString(MemoryMappedViewAccessor accessor, ref long position, Encoding encoding)
        {
            // Create a list of bytes to store the string
            var buffer = new List<byte>();

            // Read a byte from the MemoryMappedViewAccessor
            byte b;
            // Loop until the byte is equal to 0 (null-terminated)
            while ((b = accessor.ReadByte(position)) != 0)
            {
                // Add the byte to the list
                buffer.Add(b);
                position++;
            }

            // Increment the position to skip the null-terminator
            position++;

            // Return the string from the list of bytes
            return encoding.GetString(buffer.ToArray());
        }
    }
}
