import Product from "./product";

export default class FavoriteItem {
    private product : Product;
    private discount : number;

    constructor(product : Product) {
        this.product = product;
        if(product.getPrice() > 1000){
            this.discount = 0.1;
        }
        else {
            this.discount = 0;
        }
    }

    public getProduct() : Product {
        return this.product;
    }

    public getDiscount() : number {
        return this.discount;
    }
}