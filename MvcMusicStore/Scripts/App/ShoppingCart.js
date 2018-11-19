$(function () {
    // link-up remove event handler
    $(".RemoveLink").click(function () {
        // get id
        var recordToDelete = $(this).attr("data-id");

        if (recordToDelete != '') {
            // AJAX POST
            $.post("ShoppingCart/RemoveFromCart", { id: recordToDelete },
                function (data) {
                    // update page
                    if (data.ItemCount == 0) {
                        $('#row-' + data.DeleteId).fadeOut('slow');
                    }
                    else {
                        $('#item-count-' + data.DeleteId).text(data.ItemCount);
                    }

                    $('#cart-total').text(data.CartTotal);
                    $('#update-message').text(data.Message);
                    $('#cart-status').text('Cart (' + data.CartCount + ')');
                });
        }
    });
});

function handleUpdate() {
    // load and deserialise the returned data
    var json = context.get_data();
    var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

    // update elements
    if (data.ItemCount == 0) {
        $('#row-' + data.DeleteId).fadeOut('slow');
    }
    else {
        $('#item-count-' + data.DeleteId).text(data.ItemCount);
    }

    $('#cart-total').text(data.CartTotal);
    $('#update-message').text(data.Message);
    $('#cart-status').text('Cart (' + data.CartCount + ')');
}