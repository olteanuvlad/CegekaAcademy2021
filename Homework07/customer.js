"use strict";
exports.__esModule = true;
var cart_item_1 = require("./cart-item");
var favorite_item_1 = require("./favorite-item");
var Customer = /** @class */ (function () {
    function Customer(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.cart = [];
        this.favorites = [];
    }
    Customer.prototype.addToCart = function (product, amount) {
        var cartItem = new cart_item_1["default"](product, amount, 0);
        this.cart.push(cartItem);
    };
    Customer.prototype.addToFavorites = function (product) {
        var favItem = new favorite_item_1["default"](product);
        this.favorites.push(favItem);
    };
    Customer.prototype.addToCartFromFavorites = function (index, amount) {
        var favItem = this.favorites[index];
        var cartItem = new cart_item_1["default"](favItem.getProduct(), amount, favItem.getDiscount());
        this.cart.push(cartItem);
        this.favorites[index] = null;
        this.favorites.splice(index, 1);
    };
    Customer.prototype.placeOrder = function () {
        if (!this.checkAvailability())
            return;
        console.log('=========Customer details=========');
        console.log(this.firstName + " " + this.lastName);
        console.log('==========Order details==========');
        var total = 0;
        for (var _i = 0, _a = this.cart; _i < _a.length; _i++) {
            var item = _a[_i];
            var product = item.getProduct();
            var quantity = item.getQuantity();
            var basePrice = product.getPrice();
            var finalPrice = basePrice * (1 - item.getDiscount());
            console.log(product.getName() + " ..... " + quantity + " x " + finalPrice + " = " + (quantity * finalPrice));
            total += quantity * finalPrice;
            product.subtractStock(quantity);
            product.incrementLikeability();
        }
        console.log('===========================');
        console.log("TOTAL: " + total);
        this.cart = [];
    };
    Customer.prototype.checkAvailability = function () {
        var flag = true;
        for (var _i = 0, _a = this.cart; _i < _a.length; _i++) {
            var item = _a[_i];
            if (item.getQuantity() > item.getProduct().getQuantity()) {
                console.log("Cannot order " + item.getQuantity() + " of " + item.getProduct().getName() + ". Only " + item.getProduct().getQuantity() + " left in stock.");
                flag = false;
            }
        }
        return flag;
    };
    return Customer;
}());
exports["default"] = Customer;
