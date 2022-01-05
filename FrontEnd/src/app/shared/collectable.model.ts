export class collectable {
    public position: number;
    public name: string;
    public weight: number;
    public symbol: string;

    constructor( position: number,  name: string,  weight: number,  symbol: string ){
        this.position = position;
        this.name = name;
        this.weight = weight;
        this.symbol = symbol;
    }
}