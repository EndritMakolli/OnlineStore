
import { Product } from "../../../app/models/product";
import { Button, Card, Image } from "semantic-ui-react";
import React from 'react';

interface Props {
  product: Product;
  cancelSelectProduct: () => void;
  openForm: (id: string) => void;
}

export default function ProductDetails({ product, cancelSelectProduct, openForm }: Props) {
  return (
    <Card fluid>
      <Image src={`/assets/categoryImages/${product.name}.jpg`} />
      <Card.Content>
        <Card.Header>{product.description}</Card.Header> {/* Fixed closing tag */}
        <Card.Meta>
          <span>{product.type}</span> {/* Fixed closing tag */}
        </Card.Meta>
        <Card.Description>
          {product.description}
        </Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths='2'>
          <Button 
            onClick={() => openForm(product.id)} 
            basic 
            color='blue' 
            content='Edit' 
          />
          <Button 
            onClick={cancelSelectProduct} 
            basic 
            color='grey' 
            content='Cancel' 
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
}
