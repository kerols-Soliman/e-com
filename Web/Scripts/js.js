$(document).ready(function(){
    
    

    $(".size").click(function () {
        $(".size").removeClass("sizeclicked")
        $(this).addClass("sizeclicked")
    })

    var currentProduct;

    
    $(".btn-Decrease").click(function () {
        var quent = parseInt($(".Quantity").val())
        if (quent > 1) {
            $(".Quantity").val(quent - 1)
        }
    })
    $(".btn-Increase").click(function () {
        var quent = parseInt($(".Quantity").val())
        var max = $(".Quantity").attr("maxProductAvailable");
        alert(max);
        if (quent<max)
            $(".Quantity").val(quent + 1)
    })

})

