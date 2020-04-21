$(document).ready(function () {
    $('#example').DataTable();
    $(document).on('click', '.prodt', function () {

        var table = $('#example').DataTable();
        var data = table.row($(this).closest('tr')).data();
    

        $('#cod').html('Codigo  : ' + data[0]);
        codigo = "";
       
    });

});

