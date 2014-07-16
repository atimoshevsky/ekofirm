$(function () {

    ClearBasket = function () {
        localStorage.removeItem("ProductList");
        RefreshBasketHtml();
    };

    makeOrderAjaxSubmit = function () {
        $form = $(this);

        var $iName = $("#iName");
        var $iEmail = $("#iEmail");
        var $iPhone = $("#iPhone");

        var productData = [];

        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);
            for (var i in objProductList) {
                productData.push({ "Quantity": objProductList[i].Count, "Price": objProductList[i].PricePerItem, "ProductID": objProductList[i].ID });
            }
        }

        var order = {
            "Buyer":
                {
                    "Name": $iName.val(),
                    "Email": $iEmail.val(),
                    "PhoneNumber": $iPhone.val()
                },
            "OrderDetails": productData
        }

        var options = {dataType: 'json',
            type: $form.attr("method"),
            url: $form.attr("action"),
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(order)
        };


        $.ajax(options).done(function (data) {
            if (data.Result == "OK") {
                localStorage.clear();
                RefreshBasketHtml();
                $('#MakeOfferDialog').modal('hide')

            }
        });

        return false;
    }

    var FindItemByKey = function (key) {
        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);
            for (var i in objProductList) {
                if (objProductList[i].ID == key) {
                    return objProductList[i];
                }
            }
        }
        return null;
    };

    var ChangeLocalStorage = function (item, mode) {
        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);
            for (var i in objProductList) {
                if (objProductList[i].ID == item.ID) {
                    // update existing
                    if (mode == "add") {
                        objProductList[i].Count += item.Count;
                    }
                    else {
                        objProductList[i].Count = item.Count;
                    }

                    objProductList[i].PricePerItem = item.PricePerItem;
                    localStorage.ProductList = JSON.stringify(objProductList);
                    return;
                }
            }
            // new one
            objProductList.push(item);
            localStorage.ProductList = JSON.stringify(objProductList);
        }
        else {
            // init storage, first time
            var productList = [];
            productList.push(item);
            localStorage.ProductList = JSON.stringify(productList);
        }
    };

    var AddToBasket = function () {
        $button = $(this);

        var productCount = Number($("input[id=" + $button.attr("data-spin-product-id") + "]").val());

        var objProductItem = {
            ID: $button.attr("data-product-id"),
            Name: $button.attr("data-product-name"),
            PricePerItem: parseFloat($button.attr("data-product-price")),
            Count: productCount
        };

        ChangeLocalStorage(objProductItem, "add");
        RefreshBasketHtml();
    };

    var RefreshBasketHtml = function () {
        var productsCount = 0;
        var productsPrice = 0.0;

        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);
            for (var i in objProductList) {
                var product = objProductList[i];
                var intProductCount = Number(product.Count);
                productsPrice += intProductCount * parseFloat(product.PricePerItem);
                productsCount += intProductCount;
            }
        }

        if (productsCount > 0) {
            var html = "<p class='text-muted basket'>В вашей корзине продукции на сумму <span class='BasketPrice'>" + productsPrice + "</span> грн. </p>";
            html += "<div class='float-left'><button type='button' class='btn btn-default btn-sm' id='clear-basket' onclick='ClearBasket();'>Очистить</button></div>";
            html += "<div class='float-right'><button type='button' class='btn btn-danger btn-sm' id='divOffer' data-toggle='modal' data-target='#MakeOfferDialog'>Оформить заказ <span class='badge'>" + productsCount + "</span></button></div>";

            $("#divBasket").html(html);
        }
        else {
            $("#divBasket").html("<p class='text-muted basket'>Ваша корзина пуста</p>");
        }
    };

    $('#MakeOfferDialog').on('show.bs.modal', function (e) {

        $("#divBasketProductList").html('<table cellpadding="0" cellspacing="0" border="0" class="display" id="productBasket"></table>');

        if (localStorage.ProductList) {
            var objProductList = jQuery.parseJSON(localStorage.ProductList);


            $('#productBasket').dataTable({
                "paging":   false,
                "ordering": false,
                "info": false,
                "filter": false,
                "data": objProductList,
                "columns": [
                    { "data": "ID", "title": "ID" },
                    { "data": "Name", "title": "Продукт" },
                    { "data": "Count", "title": "Количество", },
                    { "data": "PricePerItem", "title": "Цена, грн." }
                ],
                "columnDefs": [
                    {
                        "targets": 0,
                        "visible": false,
                        "searchable": false
                    },
                    {
                        "render": function (data, type, row) {
                            return "<input type='text' data-spin-basket-product-price='" + row.PricePerItem + "' data-spin-basket-product-id='" + row.ID + "' id='basket_spin_@(item.ProductID)' value='" + data + "' />"
                        },
                        "targets": 2
                    },
                    {
                        "render": function (data, type, row) {
                            return "<span id='price_span_" + row.ID + "'>" + (row.PricePerItem * row.Count) + "</span>"
                        },
                        "targets": 3
                    }

                ]
            });
        }

        $("input[data-spin-basket-product-id]").each(
           function () {
               $input = $(this);
               $input.spinedit({
                   minimum: 1,
                   maximum: 100,
                   step: 1,
                   numberOfDecimals: 0
               });
           });

        $("input[data-spin-basket-product-id]").change(
           function () {
               $input = $(this);

               var productID = $input.attr("data-spin-basket-product-id");
               var intProductCount = Number($input.val());
               var floatProductPrice = parseFloat($input.attr("data-spin-basket-product-price"));
               var floatTotalPrice = intProductCount * floatProductPrice;

               var productInfo = {
                   ID: productID,
                   Count: intProductCount,
                   PricePerItem: floatProductPrice
               };

               ChangeLocalStorage(productInfo, "update");
               $("#price_span_" + productID).html(floatTotalPrice);
               RefreshBasketHtml();
           });
    });

    // find all buttons 'Купить', they market with id = "basket_[PRODUCT_ID]"
    $("button[name='basket']").on("click", AddToBasket);

    $("form[data-basket-ajax='true']").submit(makeOrderAjaxSubmit);
    

    //refresh basket HTML section
    RefreshBasketHtml();

})