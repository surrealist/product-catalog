# Product catalog

## Development Steps
- Requirements
- API design
  - Resources
  - Endpoint (URL)
  - Request/Response payload
- Develop

## Examples
- Resources: Customer, Order, OrderDetail, Product
- Endpoints:
  - GET /api/v1/customers               // collection
  - GET /api/v1/customers?city=Bangkok  // collection with search condition
  - GET /api/v1/customers/C6601         // item
    - 404 => Not Found
    - 200 => Ok
  - POST /api/v1/customers
    - { name: 'Customer A', address: '1/1' }
    - 400 => Bad Request
    - 201 => Created
      - { id: 'C6602', name: 'Customer A', address: '1/1', createdDate: '...' }
  - PUT /api/v1/customers/C6602
    - { id: 'C6602', name: 'Customer A', address: '2/2' }
    - 400 => Bad Request
    - 204 => No Content (no response payload)
  - DELETE /api/v1/customers/C6602
    - 404 => Not Found
    - 200 => Ok
    
  - GET /api/v1/Customers/C6601/orders 
  - GET /api/v1/Orders?customerId=C6601
   
  - /api/v1/orders/2/lines/5
  - /api/v1/products


## Requirements
จัดเก็บข้อมูลสินค้า มีภาพสินค้าได้

client - server -> database/files <- scada or other systems

## Tech stacks
- .NET 6
- C#
- Entity Framework / MS SQL Server
- REST API

## API Specifications

### Get all products

```
GET /api/v1/products
```

### Get product by Id
```
GET /api/v1/products/{id}
```

### Get Product Picture
```
GET /api/v1/products/{id}/picture
```

### Create a new product
```
POST /api/v1/products
```

### Update product information
```
PUT /api/v1/products/{id}
```

