# Carguero API

## This is a programming chalange, where I developed an API where you can register a User and an Address associated with a user.</p>

## Installation

Install [docker](https://www.docker.com/products/docker-desktop), then execute the command below at the project root.
```bash
docker-compose up -d
```

Create a new database named *Carguero*, then your are ready to run the api using the commande below

```bash
dotnet run --project carguero
```

## Tests
To run test execute
```bash
dotnet test
```

## Api Endpoints

###  Register an user
* **Endpoint**

  http://localhost:5000/users

* **Method:**
  

`POST` 
 

* **Data Params**
```
{
    "username": "data"
}
```

###  Register an address
* **Endpoint**

  http://localhost:5000/addresses

* **Method:**
  

`POST` 
 

* **Data Params**
```
{
  "zipCode": "data",
  "number": data,
  "city": "data",
  "district": "data",
  "state": "data",
  "userId": data
}
```

###   List all users
* **Endpoint**

  http://localhost:5000/users

* **Method:**
  

`POST` 


###  Register an address
* **Endpoint**

  http://localhost:5000/addresses

* **Method:**
  

`POST` 
 

* **Data Params**
```
{
  "zipCode": "data",
  "number": data,
  "city": "data",
  "district": "data",
  "state": "data",
  "userId": data
}
```

###  Update an address
* **Endpoint**

  http://localhost:5000/addresses/{id}

* **Method:**
  

`PUT` 
 

* **Data Params**
```
{
  "zipCode": "data",
  "number": data,
  "city": "data",
  "district": "data",
  "state": "data",
  "userId": data
}
```

###  Get addresses by username
* **Endpoint**

  http://localhost:5000/addresses/search/{username}

* **Method:**
  

`GET` 
 

###  Delete address by id
* **Endpoint**

  http://localhost:5000/addresses/{id}

* **Method:**

`GET` 
