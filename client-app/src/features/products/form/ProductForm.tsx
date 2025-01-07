import { ChangeEvent, useState } from 'react';
import { Button, Form, Segment } from "semantic-ui-react";
import { Product } from '../../../app/models/product';
import React from 'react';

interface Props {
  product: Product | undefined;
  closeForm: () => void;
  createOrEdit: (product: Product) => void;
}

export default function ProductForm({ product: selectedProduct, closeForm, createOrEdit }: Props) {
  const initialState = selectedProduct ?? {
    id: '',
    name: '',
    description: '',
    price: 0,
    pictureUrl: '',
    type: '',
    brand: '',
    quantityInStock: 0,
    isSuccess: false
  };

  const [product, setProduct] = useState(initialState);

  function handleSubmit() {
    createOrEdit(product);
  }

  function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
    const { name, value } = event.target;
    setProduct({ ...product, [name]: name === 'price' || name === 'quantityInStock' ? +value : value });
  }

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete='off'>
        <Form.Input 
          placeholder='Name' 
          value={product.name} 
          name='name' 
          onChange={handleInputChange} 
        />
        <Form.TextArea 
          placeholder='Description' 
          value={product.description} 
          name='description' 
          onChange={handleInputChange} 
        />
        <Form.Input 
          placeholder='Price' 
          value={product.price} 
          name='price' 
          type='number'
          onChange={handleInputChange} 
        />
        <Form.Input 
          placeholder='Picture URL' 
          value={product.pictureUrl} 
          name='pictureUrl' 
          onChange={handleInputChange} 
        />
        <Form.Input 
          placeholder='Type' 
          value={product.type} 
          name='type' 
          onChange={handleInputChange} 
        />
        <Form.Input 
          placeholder='Brand' 
          value={product.brand} 
          name='brand' 
          onChange={handleInputChange} 
        />
        <Form.Input 
          placeholder='Quantity In Stock' 
          value={product.quantityInStock} 
          name='quantityInStock' 
          type='number'
          onChange={handleInputChange} 
        />
        <Button 
          floated='right' 
          positive 
          type='submit' 
          content='Submit' 
        />
        <Button 
          onClick={closeForm} 
          floated='right' 
          type='button' 
          content='Cancel' 
        />
      </Form>
    </Segment>
  );
}
