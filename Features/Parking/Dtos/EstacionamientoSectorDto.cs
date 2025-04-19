namespace ParkingUNAH.Features.Parking.Dtos
{
    public class EstacionamientoSectorDto
    {
        public int EstacionamientoId { get; set; }
        public int Posicion { get; set; }
        public bool EstaOcupado { get; set; }
        public string? DescripcionSector { get; set; }
        public string? CodigoSector { get; set; }
    }
}
