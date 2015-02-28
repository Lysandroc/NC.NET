
$(document).ready(function() {
    $("#DescricaoCategoria").autocomplete({
        source: function(request, response) {
            var customer = new Array();
            $.ajax({
                url: "@(Url.Action("ConsultaProdutoCategoria", "Global"))",
                type: "POST",
                minLength: 3,
                async: false,
                cache: false,
                dataType: "json",
                data: { term: request.term },
                success: function(data) {
                    for (var i = 0; i < data.length; i++) {
                        customer[i] = { label: data[i].Value, Key: data[i].Key };
                    }
                }
            });
            response(customer);
        },
        messages: {
            noResults: "",
            results: ""
        },
        select: function(event, ui) {
            $("#CodigoCategoria").val(ui.item.Key);
        }

    });
});