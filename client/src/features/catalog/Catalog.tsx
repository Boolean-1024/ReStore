import { Product } from "../../app/models/product";
import { Typography } from "@mui/material";
import ProductList from "./ProductList";
import { useState, useEffect } from "react";



export default function Catalog() {
    const [products, setProducts] = useState<Product[]>([]);
    // leave the second parameter with blank [] to make sure it is rendered only once when the component is mounted
    useEffect(() => {
        fetch('http://localhost:5000/api/products')
            .then(response => response.json())
            .then(data => setProducts(data))
    }, [])

    /*   function addProduct (){
        setProducts([...products, {name : 'product3', price : 300.00}])
      } */


    // function addProduct() {
    //     setProducts(prevState =>
    //         [...prevState,
    //         {
    //             id: prevState.length + 101,
    //             name: 'product' + (prevState.length + 1),
    //             price: prevState.length * 100,
    //             brand: 'Some Brand',
    //             description: 'some description',
    //             pictureUrl: 'http://picsum.photos/200'
    //         }
    //         ]
    //     )
    // }
    return (
        <>
            <Typography variant='h1'>Catalog</Typography>
            <ProductList products={products} />
            {/* <Button variant='contained' onClick={addProduct}>Add product</Button> */}
        </>
    )

} 