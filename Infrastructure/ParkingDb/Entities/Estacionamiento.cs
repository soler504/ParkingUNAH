namespace ParkingUNAH.Infrastructure.ParkingDb.Entities
{
    public class Estacionamiento
    {
        public int Id { get; set; }
        public int Posicion { get; set; }
        public int SectorId { get; set; }
        public bool EstaOcupado { get; set; }
        public bool EsActivo { get; set; }
    }
}
