function cargarProvincias() {
    var array = ["Cantabria", "Asturias", "Galicia", "Andalucia", "Extremadura"];
    array.sort();
    addOptions("Departamento", array);
}


//Función para agregar opciones a un <select>.
function addOptions(domElement, array) {
    var selector = document.getElementsByName(domElement)[0];
    for (provincia in array) {
        var opcion = document.createElement("option");
        opcion.text = array[provincia];
        // Añadimos un value a los option para hacer mas facil escoger los pueblos
        opcion.value = array[provincia].toLowerCase()
        selector.add(opcion);
    }
}



function cargarPueblos() {
    // Objeto de provincias con pueblos
    var listaPueblos = {
        cantabria: ["Laredo", "Gama", "Solares", "Castillo", "Santander"],
        asturias: ["Langreo", "Villaviciosa", "Oviedo", "Gijon", "Covadonga"],
        galicia: ["Tui", "Cambados", "Redondella", "Porriño", "Ogrove"],
        andalucia: ["Dos Hermanas", "Écija", "Algeciras", "Marbella", "Sevilla"],
        extremadura: ["Caceres", "Badajoz", "Plasencia", "Zafra", "Merida"]
    }

    var provincias = document.getElementById('Departamento')
    var pueblos = document.getElementById('IdMunicipio')
    var provinciaSeleccionada = provincias.value

    // Se limpian los pueblos
    pueblos.innerHTML = '<option value="">Seleccione un Pueblo...</option>'

    if (provinciaSeleccionada !== '') {
        // Se seleccionan los pueblos y se ordenan
        provinciaSeleccionada = listaPueblos[provinciaSeleccionada]
        provinciaSeleccionada.sort()

        // Insertamos los pueblos
        provinciaSeleccionada.forEach(function (pueblo) {
            let opcion = document.createElement('option')
            opcion.value = pueblo
            opcion.text = pueblo
            pueblos.add(opcion)
        });
    }

}
// Iniciar la carga de provincias solo para comprobar que funciona
cargarProvincias();