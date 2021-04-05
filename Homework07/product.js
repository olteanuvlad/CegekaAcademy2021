"use strict";
exports.__esModule = true;
var Product = /** @class */ (function () {
    function Product(name, price, quantity, discount, likeability) {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.discount = discount;
        this.likeability = likeability;
    }
    Product.prototype.getName = function () {
        return this.name;
    };
    Product.prototype.setName = function (newName) {
        this.name = newName;
    };
    Product.prototype.getPrice = function () {
        return this.price * (1 - this.discount);
    };
    Product.prototype.setPrice = function (newPrice) {
        this.price = newPrice;
    };
    Product.prototype.getQuantity = function () {
        return this.quantity;
    };
    Product.prototype.subtractStock = function (amount) {
        if (amount > 0)
            this.quantity -= amount;
    };
    Product.prototype.refillStock = function (amount) {
        if (amount > 0)
            this.quantity += amount;
    };
    Product.prototype.getDiscount = function () {
        return this.discount;
    };
    Product.prototype.setDiscount = function (newDiscount) {
        if (newDiscount > 0 && newDiscount < 1)
            this.discount = newDiscount;
    };
    Product.prototype.getLikeability = function () {
        return this.likeability;
    };
    Product.prototype.incrementLikeability = function () {
        this.likeability += 1;
    };
    return Product;
}());
exports["default"] = Product;
