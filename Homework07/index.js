"use strict";
exports.__esModule = true;
var customer_1 = require("./customer");
var product_1 = require("./product");
var ProductP = /** @class */ (function () {
    function ProductP() {
    }
    return ProductP;
}());
var fs = require("fs");
var rawData = fs.readFileSync("sources.json", "utf-8");
var jsonProducts = JSON.parse(rawData);
var products = [];
for (var i in jsonProducts) {
    products.push(new product_1["default"](jsonProducts[i].name, jsonProducts[i].price, jsonProducts[i].quantity, jsonProducts[i].discount, jsonProducts[i].likeability));
}
var product = products[0];
var anotherProduct = products[1];
var yetAnotherProduct = products[2];
var customer = new customer_1["default"]('Vlad', 'Olteanu');
console.log("=============================================");
console.log("Add to cart, place order, update stock and likeability");
console.log("=============================================");
console.log("[BEFORE]: [" + product.getName() + "] [Price: " + product.getPrice() + "] [Stock: " + product.getQuantity() + "] [Discount: " + product.getDiscount() + "] [Likeability: " + product.getLikeability() + "]");
customer.addToCart(product, 3);
customer.placeOrder();
console.log("[AFTER]: [" + product.getName() + "] [Price: " + product.getPrice() + "] [Stock: " + product.getQuantity() + "] [Discount: " + product.getDiscount() + "] [Likeability: " + product.getLikeability() + "]");
console.log("");
console.log("=============================================");
console.log("Refill stock and add 10% discount to product");
console.log("=============================================");
console.log("[BEFORE]: [" + product.getName() + "] [Price: " + product.getPrice() + "] [Stock: " + product.getQuantity() + "] [Discount: " + product.getDiscount() + "] [Likeability: " + product.getLikeability() + "]");
product.refillStock(3);
product.setDiscount(product.getDiscount() + 0.1);
console.log("[AFTER]: [" + product.getName() + "] [Price: " + product.getPrice() + "] [Stock: " + product.getQuantity() + "] [Discount: " + product.getDiscount() + "] [Likeability: " + product.getLikeability() + "]");
console.log("");
console.log("=============================================");
console.log("Add product to favorites, add to cart from favorties and place order");
console.log("=============================================");
console.log("[BEFORE]: [" + yetAnotherProduct.getName() + "] [Price: " + yetAnotherProduct.getPrice() + "] [Stock: " + yetAnotherProduct.getQuantity() + "] [Discount: " + yetAnotherProduct.getDiscount() + "] [Likeability: " + yetAnotherProduct.getLikeability() + "]");
customer.addToFavorites(yetAnotherProduct);
customer.addToCartFromFavorites(0, 1);
customer.placeOrder();
console.log("[AFTER]: [" + yetAnotherProduct.getName() + "] [Price: " + yetAnotherProduct.getPrice() + "] [Stock: " + yetAnotherProduct.getQuantity() + "] [Discount: " + yetAnotherProduct.getDiscount() + "] [Likeability: " + yetAnotherProduct.getLikeability() + "]");
