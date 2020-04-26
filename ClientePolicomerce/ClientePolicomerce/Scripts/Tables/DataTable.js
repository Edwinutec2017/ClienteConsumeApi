$(document).ready(function () {
    $('#productotb').DataTable();
    $(document).on('click', '.prodt', function () {

        var table = $('#productotb').DataTable();
        var data = table.row($(this).closest('tr')).data();

        $('#cod').val(data[0]);
        $('#nombre').val( data[1]);
        $('#categoria').val(data[2]);
        $('#precio').val(data[4]);
        $('#imgpp').html('<td><img id="imgprod" src="data:image/png;base64,' + data[6] + '" width="200" height="100" /></td>');

    });

});

var total = 0;
var cantidadfinal = 0;
var array = new Array;
var codigo = 0;
var precio 
function CapturaProduc() {
    var captura= $('#cantidad').val();
    var cantidad = 1;
    cantidadfinal = parseInt(captura) + cantidad;
    $('#cantidad').val(cantidadfinal);
    codigo = parseInt($('#cod').val());

    precio = parseFloat($('#precio').val());
    total = parseFloat(precio) * cantidadfinal;
    $('#total').val(total);
}

function CapturaProducQuitar() {

    captura= $('#cantidad').val();
    var cantidad = 1;
    if (parseInt(captura)>0 ) {
        cantidadfinal = parseInt(captura) - cantidad;
        $('#cantidad').val(cantidadfinal);

        var precio = $('#precio').val();
        total = parseFloat(precio) * cantidadfinal;
        $('#total').val(total);
    } 
 
}

function limpiar() {
    $('#cantidad').val("0");
    $('#total').val("0");
   

}
function LimpiarTotal() {
    $('#totalglobal').val("0")
    $('#productocant').val("0");
    $('#mensaje').html("");

}
function totalfinal() {
   
    var totalfinal = parseFloat($('#totalglobal').val()) + total;
    $('#totalglobal').val(totalfinal);
    var finalcantidad = parseInt($('#productocant').val()) + cantidadfinal;
    $('#productocant').val(finalcantidad);
    ProductoAdquiridos(total, cantidadfinal);
    limpiar();
   
  
}
function ProductoAdquiridos(total,cantidad) {
    
    var reques = {
         "CodigoArticulo": codigo,
         "Cantidad": cantidad,
         "Precio": precio,
         "TotalArticulo": total
    };
    array.push(reques);

}



function Pedido() {
    $.ajax({
        type: 'POST',
        url: '/Home/Pedido',
        data: { array,encabezado },
        dataType: 'json',
        success: function (resp) {
            if (resp == 200) {
                
              
            } else if (resp == 400) {
                
            }
        }

    });
}
var encabezado;
function RegistrarPedido() {
    console.log(array)

    if (parseInt($('#pago').val()) == 0 || parseInt($('#doc').val()) == 0) {
        $('#mensaje').html("Ojo:  Elija un Tipo de Pago ");
        $('#mensaje2').html("y un tipo de Documento ");

    } else if (parseFloat($('#totalglobal').val()) == 0) {

        $('#mensaje').html("No a Ingresado ningun Producto ");
    } else {
        encabezado = {
            "CodigoPedido": "",
            "FechaPedido": $('#pedidofecha').val(),
            "IdUser": parseInt($('#codclien').html()),
            "IdTipoPago": parseInt($('#pago').val()),
            "IdTipoDoc": parseInt($('#doc').val()),
            "MontoTotal": parseFloat($('#totalglobal').val())
        };
        $('#mensaje').html("Ingresado Con Exito");
        Pedido();
        LimpiarTotal(); 
    }
  
    
}


$(document).ready(function () {
    $('#serviciostb').DataTable();
    $(document).on('click', '.servi', function () {

        var table = $('#serviciostb').DataTable();
        var data = table.row($(this).closest('tr')).data();
        $('#cod').html('CODIGO  : ' + data[0]);
        $('#nombre').html('NOMBRE  : ' + data[1]);
        $('#categoria').html('CATEGORIA  : ' + data[2]);
        $('#precio').html('PRECIO  $ : ' + data[4]);
        $('#imgserv').html('<td><img id="imgser" src="data:image/png;base64,' + data[6] +'" width="200" height="100" /></td>');
        
    });

});

