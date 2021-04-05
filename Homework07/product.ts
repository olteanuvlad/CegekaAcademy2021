export default class Product{
    private name: string;
    private price: number;
    private quantity: number;
    private discount: number;
    private likeability: number;

    constructor(name: string, price: number, quantity: number, discount: number, likeability: number){
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.discount = discount;
        this.likeability = likeability;
    }

    public getName() : string {
        return this.name;
    }

    public setName(newName: string) {
        this.name = newName;
    }

    public getPrice() : number {
        return this.price * (1 - this.discount);
    }

    public setPrice(newPrice : number) {
        this.price = newPrice;
    }

    public getQuantity() : number {
        return this.quantity;
    }

    public subtractStock (amount : number) {
        if(amount > 0)this.quantity -= amount;
    }

    public refillStock (amount : number) {
        if(amount > 0)this.quantity +=amount;
    }

    public getDiscount() : number {
        return this.discount;
    }

    public setDiscount(newDiscount : number) {
        if(newDiscount > 0 && newDiscount < 1)this.discount = newDiscount;
    }

    public getLikeability() : number {
        return this.likeability;
    }

    public incrementLikeability () {
        this.likeability += 1;
    }
    
}