# Unity_client

Unity_client is an application used to pick and store coordinates points on a 3D model.  
It use [Django_server](https://github.com/Elchma/django_server) to store the coordinates in a database.

## Installation

### Unity

I used unity 2021 to make this application, but if you use an older version, like 2019, it's ok.

## Usage

### Introduction

When you start the application, you can see a placeholder of a 3D model.  
You can rotate the camera and zoom/unzoom.
You also can pick a point to save it in the database. The X must be >= 0 and Y <= 125. There is a popup to confirm the action.

### Controls

```
Left click (HOLD) : Enter rotation mode, move the mouse to rotate around the model
Right click : Calculate the coordinates of a point based on the mouse cursor's position
Mouse wheel : Zoom/Unzoom
```

### Store data

To store the data, you need to run the server.  
Download the project [Django_server](https://github.com/Elchma/django_server) and read the instructions to start it.