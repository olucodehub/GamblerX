## Auth

### Register

```js
POST {{host}}/auth/register
```

### Register Request

```json
{
  "firstname": "Oluwatomi",
  "lastname": "Oluwatomi",
  "email": "Oluwatomi@gmail.com",
  "password": "Oluwatomi"
}
```

### Register Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3b-4075",
  "firstname": "Oluwatomi",
  "lastname": "Oluwatomi",
  "email": "Oluwatomi@gmail.com",
  "token": "eyjhbgsfh...zfgskFdT"
}
```

### Login

```js
POST {{host}}/auth/login
```

### Login Request

```json
{
  "email": "Oluwatomi@gmail.com",
  "password": "Oluwatomi"
}
```

### Login Response

```js
200 OK
```

```json
{
  "id": "d89c2d9a-eb3b-4075",
  "firstname": "Oluwatomi",
  "lastname": "Oluwatomi",
  "email": "Oluwatomi@gmail.com",
  "token": "eyjhbgsfh...zfgskFdT"
}
```
