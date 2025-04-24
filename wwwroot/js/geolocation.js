$(function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success, error);
    }

    function success(position) {
        rediregirVistaParqueo(position.coords.latitude, position.coords.longitude);
    }

    function error() {
        alert("No se pudo obtener la ubicación");
    }

    function rediregirVistaParqueo(latitud, longitud) {
        try {
            $.ajax({
                type: 'post',
                url: '/parking/rediregirVistaParqueo',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: JSON.stringify({ "latitud": latitud, "longitud": longitud }),
                success: function (response) {
                    const params = new URLSearchParams(window.location.search);
                    const sectorId = params.get("sectorId");

                    if (response.ok && sectorId == undefined && sectorId == null) {
                        window.location.href = response.message;
                    }
                },
                error: function (response) {
                    console.log(response);
                }
            });
        } catch (err) {

        }
    }
});