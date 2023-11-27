<p align="left"><img src="https://github.com/effedib/mars-attack/actions/workflows/dotnet.yml/badge.svg?branch=main" alt="shields"><img src="https://img.shields.io/codecov/c/github/effedib/mars-attack" alt="shields"></p>
<h1 align="center" id="title">mars-attack</h1>

<p align="center"><img src="https://socialify.git.ci/effedib/mars-attack/image?language=1&amp;name=1&amp;owner=1&amp;theme=Light" alt="project-image"></p>

<p id="description">Project developed for the Mars exploration mission through the deployment of remotely controlled vehicles on the planet's surface. The API translates commands sent from Earth into instructions executable by the rover.</p>
  
  
<h2>🧐 Features</h2>

Here're some of the project's best features:

*   Sends commands remotely using Json format
*   Report if obstacles have been encountered
*   Report current position.
*   Report current direction.

<h2>🛠️ Installation Steps:</h2>

<p>1. Clone the repository</p>

```
cd C:\path\to\mars-attack-folder
git clone https://github.com/effedib/mars-attack.git
cd mars-attack\RoverCommandService
```

<p>2. Install the dependencies</p>

```
dotnet restore
```

<p>3. Build the project</p>

```
dotnet build
```

<p>4. Run the project only http</p>

```
dotnet run
```

<p>5. Run the project http and https</p>

```
dotnet run --launch-profile https
```

<p>6. How Run Tests</p>

```
dotnet test --no-build
```


## API Reference

#### Send Commands

 <summary><code>POST</code> <code><b>/</b></code> <code>commandrover</code></summary>

##### Parameters

> | name      |  type     | data type               | description                                                           |
> |-----------|-----------|-------------------------|-----------------------------------------------------------------------|
> | "commands" |  required | object (JSON )   | Unique key in Json data  |


##### Response

> | http code     | content-type                      | response                                                            |
> |---------------|-----------------------------------|---------------------------------------------------------------------|
> | `200`         | `text/plain;charset=UTF-8`        | `obstacle detection, current position, current location` |


## cURL Examples

```bash
curl -X POST https://localhost:7015/commandrover
      -H 'Content-Type:application/json'
      -d "{'commands': 'fff'}"

curl -X POST http://localhost:5197/commandrover
      -H 'Content-Type:application/json'
      -d "{'commands': 'fff'}"

```

## Response Example

```bash
Obstacle detected at position: (0, 1)
Current position: (0, 2)
Current direction: N

No obstacle detected!
Current position: (0, 9)
Current direction: N
```

## Bad cURL Examples

```bash
curl -X POST https://localhost:7015/commandrover
      -H 'Content-Type:application/json'
      -d "{'': 'fff'}"

curl -X POST http://localhost:5197/commandrover
      -H 'Content-Type:application/json'
      -d "{'commands': ''}"

```

## Response Example

```bash
No commands received
```

  
<h2>💻 Built with</h2>

Technologies used in the project:

*   C#
*   .NET 8.0
*   xUnit.net

<h2>🛡️ License:</h2>

This project is licensed under the MIT License
