import CartItem from './cart-item'
import FavoriteItem from './favorite-item';
import Product from './product';

export default class Customer {
    private firstName : string;
    private lastName : string;
    private cart : CartItem[];
    private favorites : FavoriteItem[];
    
    constructor(firstName : string, lastName: string){
        this.firstName = firstName;
        this.lastName = lastName;

        this.cart = [];
        this.favorites = [];
    }

    public addToCart(product : Product, amount : number) {
        let cartItem = new CartItem(product, amount, 0);
        this.cart.push(cartItem);
    }

    public addToFavorites(product : Product) {
        let favItem = new FavoriteItem (product);
        this.favorites.push(favItem);
    }

    public addToCartFromFavorites(index : number, amount : number) {
        let favItem = this.favorites[index];
        let cartItem = new CartItem(favItem.getProduct(), amount, favItem.getDiscount());
        this.cart.push(cartItem);
        this.favorites[index] = null;
        this.favorites.splice(index, 1);
    }

    public placeOrder() {
        if(!this.checkAvailability())return;

        console.log('=========Customer details=========');
        console.log(`${this.firstName} ${this.lastName}`);
        console.log('==========Order details==========');
        
        let total = 0;

        for(let item of this.cart){
            let product = item.getProduct();
            let quantity = item.getQuantity();
            let basePrice = product.getPrice();
            let finalPrice = basePrice * (1 - item.getDiscount());
            console.log(`${product.getName()} ..... ${quantity} x ${finalPrice} = ${(quantity * finalPrice)}`);
            total += quantity * finalPrice;
            product.subtractStock(quantity);
            product.incrementLikeability();
        }

        console.log('===========================');
        console.log(`TOTAL: ${total}`);

        this.cart = [];

    }

    public checkAvailability() : boolean {

        let flag = true;

        for(let item of this.cart){
            if(item.getQuantity() > item.getProduct().getQuantity()){
                console.log(`Cannot order ${item.getQuantity()} of ${item.getProduct().getName()}. Only ${item.getProduct().getQuantity()} left in stock.`)
                flag = false;
            }
        }

        return flag;
    }
}