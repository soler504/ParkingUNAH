namespace ParkingUNAH.Infrastructure.ParkingDb.Dtos
{
    public class EstadisticasSectorDto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int TotalDesocupados { get; set; }
        public int TotalOcupados { get; set; }
    }
}
