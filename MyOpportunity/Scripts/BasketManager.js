$(function () {

    
    ClearBasket = function () {
        localStorage.removeItem("ProductList");
        RefreshBasketHtml();
    };


    ShowBasketPopup = function () {
        alert("Display ake offer Popup");
    }

    var AddToBasket = function () {
        $button = $(this);

        var objProductItem = new Object();
        objProductItem.ID = $button.attr("data-product-id");
        objProductItem.Name = $button.attr("data-product-name");
        objProductItem.Price = $button.attr("data-product-price");
        objProductItem.Count = $("input[id=" + $button.attr("data-spin-product-id") + "]").val();

        // add product to localstorage
        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);
            objProductList.products.push(objProductItem);
            localStorage.ProductList = JSON.stringify(objProductList)
        }
            // create product in localStorage
        else {
            var productList = {
                products: []
            };

            productList.products.push(objProductItem);
            localStorage.ProductList = JSON.stringify(productList)
        }

        RefreshBasketHtml();
    };

    var RefreshBasketHtml = function () {
        var productsCount = 0;
        var productsPrice = 0.0;

        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);

            for (var i in objProductList.products) {
                var product = objProductList.products[i];
                var count = Number(product.Count);
                productsPrice += parseFloat(count * product.Price)
                productsCount += Number(product.Count);
            }
        }

        if (productsCount > 0) {
            var html = "<p class='text-muted basket'>В вашей корзине продукции на сумму <span class='BasketPrice'>" + productsPrice + "</span> грн. </p>";
            html += "<div class='float-left'><button type='button' class='btn btn-default btn-sm' id='clear-basket' onclick='ClearBasket();'>Очистить</button></div>";
            html += "<div class='float-right'><button type='button' class='btn btn-danger btn-sm' id='divOffer' onclick='ShowBasketPopup();'>Оформить заказ <span class='badge'>" + productsCount + "</span></button></div>";

            $("#divBasket").html(html);


        }
        else {
            $("#divBasket").html("<p class='text-muted basket'>Ваша корзина пуста</p>");
        }
    };


    // find all buttons 'Купить', they market with id = "basket_[PRODUCT_ID]"
    $("button[name='basket']").on("click", AddToBasket);

    //refresh basket HTML section
    RefreshBasketHtml();

    })