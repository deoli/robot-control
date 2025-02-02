# Robot Control App
Welcome to the Robot Control App! This project was originally designed to respond to a technical test for a software company.

It is a first proof of concept for an interface to control cleaning robots on a factory floor.
## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Choices](#choices)
- [Contact](#contact)
## Installation
To run this project locally, I suggest opening the folder in VS Code and leveraging the DevContainer configuration. 

## Usage
After installation, use VS Code's inbuilt functionality to run and/or debug the application (F5).

To test the functionality do a POST on URL `http://localhost:5059/robot/control` with a payload in JSON format, for example `{"command": "5 5\\n1 2 N\\nLMLMLMLMM\\n3 3 E\\nMMRMMRMRRM"}`.
## Features
Apart from the functionality described in the test document, I have implemented the following functionalities:
- When a robot faces a wall, it will not move forward.
- After each movement, a check is done to determine whether any robots have collided with each other. It would obviously be better to do a similar check before moving the robot. This could be achieved by calculating the movement beforehand, and only commiting it if deemed safe.
## Choices
Although it was suggested to use Java for this test, I ended up chosing .NET. I did not have the necessary dependencies installed on my computer for Java development, and since .NET resembles Java considerably, I thought it a good alternative.

To speed up testing and development, I chose to wrap the functionality behind a JSON API, but the code could easily be adapted to run with a different input method - via console for example.
## Contact
For any questions or inquiries, please contact [Oliver Underwood](mailto:o.underwood@outlook.com).

