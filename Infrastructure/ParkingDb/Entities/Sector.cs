namespace ParkingUNAH.Infrastructure.ParkingDb.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public double? LatitudMin { get; set; }
        public double? LongitudMin { get; set; }
        public double? LatitudMax { get; set; }
        public double? LongitudMax { get; set; }
    }
}
