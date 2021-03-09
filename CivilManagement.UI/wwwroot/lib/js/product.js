class Product {
    SKU;
    Description;
    ColorCode;
    ItemDim1Code;
    CreatedDate;
    CreatedUserName;
    Qty1;
    Qty2;
    constructor(SKU, Description, ColorCode, ItemDim1Code, CreatedDate, CreatedUserName, Qty1, Qty2) {
        this.SKU = SKU;
        this.Description = Description;
        this.ColorCode = ColorCode;
        this.ItemDim1Code = ItemDim1Code;
        this.CreatedDate = CreatedDate;
        this.CreatedUserName = CreatedUserName;
        this.Qty1 = Qty1;
        this.Qty2 = Qty2;
    }
}