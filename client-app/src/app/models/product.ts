export interface Product {
    id: string; // Unique identifier for the product
    name: string; // Name of the product
    description: string; // Description of the product
    price: number; // Price of the product
    pictureUrl: string; // URL of the product's image
    type: string; // Type/category of the product
    brand: string; // Brand of the product
    quantityInStock: number; // Quantity available in stock
    isSuccess: boolean; // Indicates if the product operation is successful
    value?: any; // Optional property not mapped to the database
  }