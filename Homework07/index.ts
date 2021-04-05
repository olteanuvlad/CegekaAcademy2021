import Customer from "./customer";
import Product from "./product";

class ProductP {
    name: string;
    price: number;
    quantity: number;
    discount: number;
    likeability: number;
}

import fs = require('fs');
let rawData = fs.readFileSync("sources.json", "utf-8");

let jsonProducts = JSON.parse(rawData) as ProductP[];

var products : Product[] = [];

for(let i in jsonProducts){
    products.push(new Product(
        jsonProducts[i].name, 
        jsonProducts[i].price, 
        jsonProducts[i].quantity,
        jsonProducts[i].discount,
        jsonProducts[i].likeability
        ));    
}

let product = products[0];
let anotherProduct = products[1];
let yetAnotherProduct = products[2];

let customer = new Customer('Vlad', 'Olteanu');

console.log("=============================================");
console.log("Add to cart, place order, update stock and likeability");
console.log("=============================================");

console.log(`[BEFORE]: [${product.getName()}] [Price: ${product.getPrice()}] [Stock: ${product.getQuantity()}] [Discount: ${product.getDiscount()}] [Likeability: ${product.getLikeability()}]`);
customer.addToCart(product, 3);
customer.placeOrder(); 
console.log(`[AFTER]: [${product.getName()}] [Price: ${product.getPrice()}] [Stock: ${product.getQuantity()}] [Discount: ${product.getDiscount()}] [Likeability: ${product.getLikeability()}]`);

console.log("");

console.log("=============================================");
console.log("Refill stock and add 10% discount to product");
console.log("=============================================");
console.log(`[BEFORE]: [${product.getName()}] [Price: ${product.getPrice()}] [Stock: ${product.getQuantity()}] [Discount: ${product.getDiscount()}] [Likeability: ${product.getLikeability()}]`);
product.refillStock(3);
product.setDiscount(product.getDiscount() + 0.1);
console.log(`[AFTER]: [${product.getName()}] [Price: ${product.getPrice()}] [Stock: ${product.getQuantity()}] [Discount: ${product.getDiscount()}] [Likeability: ${product.getLikeability()}]`);

console.log("");

console.log("=============================================");
console.log("Add product to favorites, add to cart from favorites and place order");
console.log("=============================================");

console.log(`[BEFORE]: [${yetAnotherProduct.getName()}] [Price: ${yetAnotherProduct.getPrice()}] [Stock: ${yetAnotherProduct.getQuantity()}] [Discount: ${yetAnotherProduct.getDiscount()}] [Likeability: ${yetAnotherProduct.getLikeability()}]`);

customer.addToFavorites(yetAnotherProduct);
customer.addToCartFromFavorites(0, 1);
customer.placeOrder(); 

console.log(`[AFTER]: [${yetAnotherProduct.getName()}] [Price: ${yetAnotherProduct.getPrice()}] [Stock: ${yetAnotherProduct.getQuantity()}] [Discount: ${yetAnotherProduct.getDiscount()}] [Likeability: ${yetAnotherProduct.getLikeability()}]`);
