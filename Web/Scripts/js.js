$(document).ready(function () {



    var changedPart = "quentity=1"



    $(".size").click(function () {
        $(".size").removeClass("sizeclicked")
        $(this).addClass("sizeclicked")
    })



    var currentProduct;




    $(".btn-Decrease").click(function () {
        var quent = parseInt($(".Quantity").val())



        if (quent > 1) {
            quent--
            $(".Quantity").val(quent)
        }




        var oldUrl = $("#cart-url").attr("href");
        var newUrl = oldUrl.replace(changedPart, "quentity=" + quent);
        $("#cart-url").attr("href", newUrl);
        changedPart = "quentity=" + quent;




        console.log("old: " + oldUrl);
        console.log("new: " + newUrl);
        //console.log(quent);
    })




    $(".btn-Increase").click(function () {
        var quent = parseInt($(".Quantity").val())
        var max = $(".Quantity").attr("maxProductAvailable");

        if (quent < max) {
            quent++
            $(".Quantity").val(quent)
        }
        var oldUrl = $("#cart-url").attr("href");
        var newUrl = oldUrl.replace(changedPart, "quentity=" + quent);
        $("#cart-url").attr("href", newUrl);
        changedPart = "quentity=" + quent;
    })
    var oldCommet = "comment=";
    //$("#PostBtn").click(function () {
    $("#comment").on("change paste keyup",function () {
        
        
        comment = $("#comment").text();
        oldCommet = comment
        alert(oldCommet)
        $("#PostBtn").attr("href").replace(oldCommet,"comment="+'"'+comment+'"' )
    })


})