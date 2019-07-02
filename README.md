# Judge #
Basic console app that adds x-example properties in a .json swagger document for use with Dredd for testing APIs

## Usage ##
cli: dotnet <path-to-os-dll> '<swaggerBaseUrl>' '<swaggerPath>' '<file-path-to-save-to>'
cli: dotnet ./Judge/win10-x64/aubit.judge.dll 'http://petstore.swagger.io' 'v2/swagger.json' './swagger.json'

## Results ##
Adds "x-example: <id>" to
* DELETE operations - "x-example: 3"
* All other operations (GET, POST etc) - "x-example: 1"
Where the parameter is a path parameter i.e. "in: path"