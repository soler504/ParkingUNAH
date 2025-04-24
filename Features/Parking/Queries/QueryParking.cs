namespace ParkingUNAH.Features.Parking.Queries
{
    public static class QueryParking
    {
        public const string query001 = @"SELECT ISNULL((
                                            SELECT TOP 1 id
                                            FROM tbSector
                                            WHERE {0} BETWEEN LEAST(latitudMin, latitudMax) AND GREATEST(latitudMin, latitudMax)
                                              AND {1} BETWEEN LEAST(longitudMin, longitudMax) AND GREATEST(longitudMin, longitudMax)
                                        ), 0) AS id";
    }
}
