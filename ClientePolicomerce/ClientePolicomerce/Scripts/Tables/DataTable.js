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
    $('#mensaje2').html("");
    $('#txtalerta').html("");
    array = new Array();
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
         "IdEncabezado": 0,
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
            if (resp == "400") {
                Resp("No se Pudo Ingresar el pedido");
              
            } else {
                Resp("EXITO SU CODIGO DE PEDIDO ES : " + resp);
            }
        }

    });
}
function Resp(resp) {
    $('#respuesta').html(resp);
}

function Validar() {
    if (parseInt($('#pago').val()) == 0 || parseInt($('#doc').val()) == 0) {
        $('#txtalerta').html("Eliga un tipo de pago y el documento. ");


    } else if (parseFloat($('#totalglobal').val()) == 0) {

        $('#txtalerta').html("No tiene Ingresado Producto.");
    }
    else {
        $('#txtalerta').html("Confirmar el pedido para guardarlo..");
    }
}
var encabezado;
function RegistrarPedido() {
    console.log(array)

    if (parseInt($('#pago').val()) == 0 || parseInt($('#doc').val()) == 0) {
      

    } else if (parseFloat($('#totalglobal').val()) == 0) {

    } else {
        encabezado = {
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
        $('#cod').val([0]);
        $('#nombre').val(data[1]);
        $('#categoria').val(data[2]);
        $('#precio').val(data[4]);
        $('#imgpp').html('<td><img id="imgser" src="data:image/png;base64,' + data[6] +'" width="200" height="100" /></td>');
        
    });

});
var reque;
$(document).ready(function () {
    $('#detallePedido').DataTable();
    $(document).on('click', '.pedidoEncabezado', function () {

        var table = $('#detallePedido').DataTable();
        var data = table.row($(this).closest('tr')).data();

        var id = data[7];
        reque = {
            "Id":id
        }
        $('#mensaje').html("Codigo de pedido a Cancelar : " + data[0]);
      
    });

});

function CancelarPedido() {
    $.ajax({
        type: 'POST',
        url: '/Home/PedidoCancelar',
        data: reque,
        dataType: 'json',
        success: function (resp) {
            if (resp == "200") {
              
                
            } else {
               
            }
        }

    });
}
$(document).ready(function () {
    $('#confirmar').click(function () {
        // Recargo la página
        location.reload();
    });
});