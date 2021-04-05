import Product from './product'

export default class CartItem {
    private product : Product;
    private quantity : number;
    private discount : number;

    constructor(product : Product, quantity : number, discount : number){
        this.product = product;
        this.quantity = quantity;
        if(discount > 0 && discount < 1){
            this.discount = discount;
        }
        else {
            this.discount = 0;
        }
    }

    public getProduct () : Product {
        return this.product;
    }

    public setProduct (newProduct : Product) {
        this.product = newProduct;
    }

    public getQuantity() : number {
        return this.quantity;
    }

    public setQuantity (newQuantity : number) {
        this.quantity = newQuantity;
    }

    public getDiscount() : number {
        return this.discount;
    }

    public setDiscount (newDiscount : number) {
        this.discount = newDiscount;
    }

    public getPrice() : number {
        return this.product.getPrice() * this.quantity * (1 - this.discount);
    }
}