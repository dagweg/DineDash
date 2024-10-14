# Api Documentation

## Registration

### Register Request

```
{
    "firstName": "",
    "lastName": "",
    "email": "",
    "password": ""
}
```

### Register Response

`201`

```
{
    "id": "",
    "firstName": "",
    "lastName": "",
    "email": "",
    "token": ""
}
```

## Login

### Login Request

```
{
    "email": "",
    "password: ""
}
```

### Login Response

`200`

```
{
    "id": "",
    "accessToken": ""
}
```
