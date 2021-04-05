"use strict";
exports.__esModule = true;
var CartItem = /** @class */ (function () {
    function CartItem(product, quantity, discount) {
        this.product = product;
        this.quantity = quantity;
        if (discount > 0 && discount < 1) {
            this.discount = discount;
        }
        else {
            this.discount = 0;
        }
    }
    CartItem.prototype.getProduct = function () {
        return this.product;
    };
    CartItem.prototype.setProduct = function (newProduct) {
        this.product = newProduct;
    };
    CartItem.prototype.getQuantity = function () {
        return this.quantity;
    };
    CartItem.prototype.setQuantity = function (newQuantity) {
        this.quantity = newQuantity;
    };
    CartItem.prototype.getDiscount = function () {
        return this.discount;
    };
    CartItem.prototype.setDiscount = function (newDiscount) {
        this.discount = newDiscount;
    };
    CartItem.prototype.getPrice = function () {
        return this.product.getPrice() * this.quantity * (1 - this.discount);
    };
    return CartItem;
}());
exports["default"] = CartItem;
