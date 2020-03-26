
//funcion para llamar la api 
function Llamando_Api()
{
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/ords/policomerce/policomerce/municipios/1',
        data: '',
        dataType: "json",
        success: function (datos) {
            console.log(datos);
        },
    })

}

function CargarMunicipios() {
    var departamento = document.getElementById('Departamento').value;

    var municipio = document.getElementById('IdMunicipio')
    municipio.innerHTML = '<option value="">Seleccione un Municipio...</option>'
 
    if (municipio !== '') {

        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/ords/policomerce/policomerce/municipios/' + departamento,
            dataType:'json',
            success: function (resp) {
                console.log(resp);
                var $select = $('#IdMunicipio')
                $.each(resp, function (CODIGO, NOMBRE) {
                    $select.append('<option value=' + NOMBRE.CODIGO + '>' + NOMBRE.NOMBRE + '</option>');
                });

            },
            error: function () {
                console.log('error respuesta');
            }
        });

    }
}

