
/*llamada de methodos*/
function CargarMunicipios() {
    var departamento = document.getElementById('Departamento').value;

    var municipio = document.getElementById('IdMunicipio')
    municipio.innerHTML = '<option value="">Seleccione un Municipio...</option>'
 
    if (municipio !== '') {
        var muni = {
            "iddep": departamento
        };

        $.ajax({
            type: 'POST',
            url: '/Registro/Municipios',
            data:muni,
            dataType:'json',
            success: function (resp) {
                var $select = $('#IdMunicipio')
                $.each(resp, function (obje, NOMBRE) {
                    $select.append('<option value=' + NOMBRE.Codigo + '>' + NOMBRE.Nombre + '</option>');
                });

            }
       
        });
    }
}
function ValidarUsuario() {
    var campo = document.getElementById('USUARIO').value;
    if (campo !== '') {
        var usuario = {
            "usuario": campo
        };

        $.ajax({
            type: 'POST',
            url: '/Registro/ValidarUsuario',
            data: usuario,
            dataType: 'json',
            success: function (resp) {
                if (resp == 200) {
                    AccionUsuario(0);
                } else if (resp == 400) {
                    AccionUsuario(1);
                }
            }

        });
    }
}
    function AccionUsuario(accion) {

        if (accion == 0) {
            document.getElementById('USUARIO').style.backgroundColor = 'yellow';
            document.getElementById('conte').innerHTML = 'Usuario Ya existe';
            $('#USUARIO').val('');
            $('#CLAVE').val('');
            $('#pass2').val('');
            document.getElementById('pass2').style.backgroundColor = 'white';
            OcultarBoton();
        } else if (accion == 1) {
            document.getElementById('conte').innerHTML = 'Usuario valido ';
            document.getElementById('pass2').style.backgroundColor = 'green';

        }

    }
    function OcultarBoton() {
        $("#reg").hide();

    }
    function MostrarBoton() {
        var pass1 = document.getElementById('CLAVE').value;
        var pass2 = document.getElementById('pass2').value;
        if (pass1 == pass2) {
            $("#reg").show();
            document.getElementById('pass2').style.backgroundColor = 'green';
            ValidarUsuario();
            document.getElementById('conte').innerHTML = '';
        } else {
            OcultarBoton();
            document.getElementById('pass2').style.backgroundColor = 'yellow';
            document.getElementById('conte').innerHTML = 'Contraseñas Incorrectas';
        }
    }



