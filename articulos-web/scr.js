function updateImage() {
    var imageUrl = document.getElementById('<%= txtImageUrl.ClientID %>').value;
    document.getElementById('imgArticulo').src = imageUrl;
}

document.addEventListener("DOMContentLoaded", function () {
    var txtPrecio = document.getElementById(txtPrecioID);

    txtPrecio.addEventListener('keydown', function (e) {
        if (e.keyCode == 13) { // 13 es el código de tecla para Enter
            e.preventDefault(); // Evita el comportamiento predeterminado del Enter
            var btnAceptar = document.getElementById(btnAceptarID);
            btnAceptar.click(); // Simula un click en el botón btnAceptar
            return false; // Agrega esta línea para asegurarte de que el postback no ocurra
        }
    });

    // Este código adicional es para evitar que el form se envíe cuando presionas Enter
    if (txtPrecio.form) {
        txtPrecio.form.onsubmit = function () {
            return false;
        };
    }
});

