import { Grid } from "semantic-ui-react";
import { Product } from "../../../app/models/product";
import ProductList from "./ProductList";
import ProductDetails from "../details/ProductDetails";
import ProductForm from "../form/ProductForm";
import React from 'react';


interface Props {
  products: Product[];
  selectedProduct: Product | undefined;
  selectProduct: (id: string) => void;
  cancelSelectProduct: () => void;
  openForm: (id: string) => void;
  closeForm: () => void;
  editMode: boolean;
  createOrEdit: (product: Product) => void;
  deleteProduct: (id: string) => void;
}

export default function ProductDashboard({
  products,
  selectedProduct,
  selectProduct,
  cancelSelectProduct,
  openForm,
  closeForm,
  editMode,
  createOrEdit,
  deleteProduct
}: Props) {
  return (
    <Grid>
      <Grid.Column width='10'>
        <ProductList 
          products={products} 
          selectProduct={selectProduct}
          deleteProduct={deleteProduct} 
        />
      </Grid.Column>
      <Grid.Column width='6'>
        {selectedProduct && !editMode && (
          <ProductDetails
            product={selectedProduct}
            cancelSelectProduct={cancelSelectProduct}
            openForm={openForm}
          />
        )}
        {editMode && (
          <ProductForm 
            closeForm={closeForm} 
            product={selectedProduct} 
            createOrEdit={createOrEdit} 
          />
        )}
      </Grid.Column>
    </Grid>
  );
}


