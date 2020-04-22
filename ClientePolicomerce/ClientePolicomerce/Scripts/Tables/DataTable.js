$(document).ready(function () {
    $('#productotb').DataTable();
    $(document).on('click', '.prodt', function () {

        var table = $('#productotb').DataTable();
        var data = table.row($(this).closest('tr')).data();
   
        $('#cod').html('CODIGO  : ' + data[0]);
        $('#nombre').html('NOMBRE  : ' + data[1]);
        $('#categoria').html('CATEGORIA  : ' + data[2]);
        $('#precio').html('PRECIO  $ : ' + data[4]);
        $('#imgpp').html('<td><img id="imgprod" src="data:image/png;base64,' + data[6] + '" width="200" height="100" /></td>');

    });

});


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

