This is an application for Renting University equipment.
The user first needs to be registered in the system and then they can rent whatever they want as long as These conditions apply:
1. the user hasn't exceded the maximum number of rentals for their user category.
2. the user has no debt to the University
The user can rent a piece of equipment for up to 30 days.
After the due date has passed the user is charged for every day after the deadline an amount dependent on the equipment category rented.
The user can return the equipment for free but he has to pay his debt to be able to rent again.
The application allows Adding users, Adding items, Adding a rental for a user, returning of equipment, confirming the payment of the debt, displpaying available items and displaying current rentals for a user through a command line interface.
The project addresses cohesion and coupling by splitting the application into 3 layers integrated in the RentalSystem Class through DI:
1. Presentation layer - implemented with the CLI - handles interactions with the user of the application and sends requests to Service layer
2. Service Layer - implemented by ItemService and UserService - handles the operations, business logic and heavy tasks in the application.
3. Data Layer - implemented by the Repositories - handles saving state information and fetching the data for the service layer.

Each layer could be replaced with a different implementation and the application would still work. For example The Data layer could be replaced with one thats connected to a database and the CLI could be Replace with a GUI or a web interface.
I decided to opt for this design because it seemed clear, concise and customizable. THe division makes sense because all the layers interact only with their responsibilities - the Presentation layer doesnt work on the data but just presents them, the Control layer doesnt Print anything and doesnt interact with csv files, and the Data layer doesnt do operations - it just fetches the data (sometimes after filtering).

RUN INSTRUCTION:
run the main method in the RentalSystem.cs file. the rest will be clear with the CLI.
dotnet build && dotnet run
