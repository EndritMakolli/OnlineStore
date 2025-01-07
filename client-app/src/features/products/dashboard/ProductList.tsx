
import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Product } from "../../../app/models/product";
import React from 'react';

interface Props {
  products: Product[];
  selectProduct: (id: string) => void;
  deleteProduct: (id: string) => void;
}

export default function ProductList({ products, selectProduct, deleteProduct }: Props) {
  return (
    <Segment>
      <Item.Group divided>
        {products.map(product => (
          <Item key={product.id}>
            <Item.Content>
              <Item.Header as='a'>{product.name}</Item.Header> {/* Corrected closing tag */}
              <Item.Meta>{product.brand}</Item.Meta> {/* Corrected closing tag */}
              <Item.Description>
                <div>{product.description}</div>
                <div>{product.price}</div> {/* Removed incorrect syntax */}
              </Item.Description>
              <Item.Extra>
                <Button
                  floated='right'
                  content='View'
                  color='blue'
                  onClick={() => selectProduct(product.id)}
                />
                <Button
                  floated='right'
                  content='Delete'
                  color='red'
                  onClick={() => deleteProduct(product.id)}
                />
                <Label basic content={product.description} />
              </Item.Extra>
            </Item.Content>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
