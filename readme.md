
# Commander Project

This project intend to show the core concepts about `.Net Core` / `Asp.Net Core`.

The project is a commander reminder. The user is capable to save a `howTo` (description about the command), `line` (cli command) and `plataform` (the platform from the command were executed) on the database with this api and fetch this data later.

## I've learned:

* Model-View-Controller
* Dependency Injection
* Migrations
* Entity Framework
* MySql Entity Framework connection

## Prerequisites

* .Net Core
* MySql server (see `appsettings.json -> ConnectionStrings:Default`)

## Run Locally

```bash
git clone https://github.com/MuriloGon/commander-dotnet
```

Go to the project directory

```bash
cd commander-dotnet
```

Run the migration

```bash
  dotnet database update
```

Start the server

```bash
  dotnet run
```


## API Reference

#### Get all commands

```http
  GET /api/commands
```

#### Get a command

```http
  GET /api/commands/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of item to fetch |

#### Create a command

```http
  POST /api/commands/
```

| Body Fields | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `howTo`      | `string` | **Required**. |
| `Line`      | `string` | **Required**.  |
| `Plataform`      | `string` | **Required**. |

#### Full Update Command

```http
  PUT /api/commands/
```

| Body Fields | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `howTo`      | `string` | **Required**. |
| `Line`      | `string` | **Required**.  |
| `Plataform`      | `string` | **Required**. |


#### Partial Update Command

```http
  PATCH /api/commands/
```

| Body Fields | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `howTo`      | `string` | **Required**. |
| `Line`      | `string` | **Required**.  |
| `Plataform`      | `string` | **Required**. |


#### DELETE Command

```http
  DELETE /api/commands/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of item to be deleted|

## Acknowledgements

* This project was idealized by **Les Jackson**.
  * [.NET Core 3.1 MVC REST API - Full Course](https://www.youtube.com/watch?v=fmvcAzHpsk8)
  * [Github](https://github.com/binarythistle)
