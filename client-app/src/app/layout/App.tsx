import { useEffect, useState } from 'react';
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { Product } from '../models/product';
import NavBar from './NavBar';
import ProductDashboard from '../../features/products/dashboard/ProductDashboard';
import { v4 as uuid } from 'uuid';

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [selectedProduct, setSelectedProduct] = useState<Product | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios.get<Product[]>('http://localhost:5000/api/products')
      .then(response => {
        setProducts(response.data);
      })
  }, [])

  function handleSelectProduct(id: string) {
    setSelectedProduct(products.find(x => x.id === id));
  }

  function handleCancelSelect() {
    setSelectedProduct(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectProduct(id) : handleCancelSelect();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleDeleteProduct(id: string) {
    setProducts([...products.filter(x => x.id !== id)])
  }

  function handleCreateOrEditProduct(product: Product) {
    product.id
      ? setProducts([...products.filter(x => x.id !== product.id), product])
      : setProducts([...products, { ...product, id: uuid() }]);
    setEditMode(false);
    setSelectedProduct(product);
  }

  return (
    <>
    <h1>Hellooooooo</h1>
      <NavBar openForm={handleFormOpen} />
      <Container style={{ marginTop: '7em' }}>
        <ProductDashboard
          products={products}
          selectedProduct={selectedProduct}
          selectProduct={handleSelectProduct}
          cancelSelectProduct={handleCancelSelect}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEdit={handleCreateOrEditProduct}
          deleteProduct={handleDeleteProduct}
        />
      </Container>
    </>
  );
}

export default App;
