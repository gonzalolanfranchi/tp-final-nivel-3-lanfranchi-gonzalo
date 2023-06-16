function updateImage() {
    var imageUrl = document.getElementById('<%= txtImageUrl.ClientID %>').value;
    document.getElementById('imgArticulo').src = imageUrl;
}