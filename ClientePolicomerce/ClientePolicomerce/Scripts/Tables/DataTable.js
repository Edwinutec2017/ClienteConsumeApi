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
function CapturaProduc() {
    var captura= $('#cantidad').val();
    var cantidad = 1;
    var cantidadtotal = parseInt(captura) + cantidad;
    $('#cantidad').val(cantidadtotal);

    var precio = $('#precio').val();
     total = parseFloat(precio) * cantidadtotal;
    $('#total').val(total);
}

function CapturaProducQuitar() {

    var captura= $('#cantidad').val();
    var cantidad = 1;
    if (parseInt(captura)>0 ) {
        var cantidadtotal = parseInt(captura) - cantidad;
        $('#cantidad').val(cantidadtotal);

        var precio = $('#precio').val();
        total = parseFloat(precio) * cantidadtotal;
        $('#total').val(total);
    } 
 
}
function limpiar() {
    $('#cantidad').val("0");
    $('#total').val("0");

}
function LimpiarTotal() {
    $('#totalglobal').val("0")

}
function totalfina() {
    limpiar();
    var totalfinal = parseFloat($('#totalglobal').val()) + total;
    $('#totalglobal').val(totalfinal)
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

