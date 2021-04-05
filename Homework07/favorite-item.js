"use strict";
exports.__esModule = true;
var FavoriteItem = /** @class */ (function () {
    function FavoriteItem(product) {
        this.product = product;
        if (product.getPrice() > 1000) {
            this.discount = 0.1;
        }
        else {
            this.discount = 0;
        }
    }
    FavoriteItem.prototype.getProduct = function () {
        return this.product;
    };
    FavoriteItem.prototype.getDiscount = function () {
        return this.discount;
    };
    return FavoriteItem;
}());
exports["default"] = FavoriteItem;
