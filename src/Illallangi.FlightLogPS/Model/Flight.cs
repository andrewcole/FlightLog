// <copyright file="FlightRepository.cs" company="Illallangi Enterprises">Copyright Illallangi Enterprises 2013</copyright>
// <summary>A repository of Flight objects.</summary>

namespace Illallangi.FlightLog.Model
{
    /// <summary>Represents a Flight entity.</summary>
    public sealed class Flight
    {
        public int Id { get; set; }

        /// <summary>
        /// Time and Date of the flights departure at the origin
        /// </summary>
        public string Departure { get; set; }

        /// <summary>
        /// Time and Date of the flights arrival at the destination
        /// </summary>
        public string Arrival { get; set; }

        public int OriginId { get; set; }

        public string OriginName { get; set; }

        public int DestinationId { get; set; }

        public string DestinationName { get; set; }
    }
}