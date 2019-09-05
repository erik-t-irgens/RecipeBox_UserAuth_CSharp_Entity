# Recipe Box

#### _A recipe app that allows for recipes to be created and authenticates users - August 2019_

#### _By **Erik Irgens**_

## Description

This application was created with the intention of practicing an MVC application that would create relational database entities, and also study - more in depth - the implementation of Identity into MVC applications. 
### Specs
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **User can create an account** | New account creation | Identity generates a user  |
| **user is authenticated when visiting pages** | Visit create recipe page | User is authenticated to be signed in or not  |
| **User can create a new recipe** | New recipe creation | SQL is updated with user information  |
| **User can view ONLY THEIR creations** | View recipes | Only user's creations are authorized to be viewed  |
| **User should be able to delete, edit, and view details of each Recipe** | Recipe is clicked | Recipe details will appear in the correct path  |

## Setup/Installation Requirements

1. Clone this repository:
    ```
    $ git clone https://github.com/erik-t-irgens/RecipeBox_UserAuth_CSharp_Entity
    ```
2. Update your database (using provided migrations)
    ```
    $ dotnet ef database update
    ```
3. Run the application in the root directory
    ```
    $ dotnet run
    ```
4. Visit the MVC localhost:5000/
    ```
    localhost:5000/
    ```

## Known Bugs
* None at this time

## Technologies Used
* C#/.NET, ASP.NET Core 2.2, MVC architecture, Linq, MySQL and SQL databases, Identity

## Support and contact details

_Please contact Erik Irgens with questions and comments._

### License

*GNU GPLv3*

Copyright (c) 2019 **_Erik Irgens_**
