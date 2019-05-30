# rent
Equipment Rental Application

There two main parts of the application Frontend and Web Api

**Frontend**

Technology Stack

- MVC
- Angular

Project name is "Equipment.Rental.App"
For running the project you should change address inside the web config where you will host the "Equipment.Rental.WebApi" project.
    <add key="ApiUrl" value="http://127.0.0.1"/>
    
**Backend**

For backend I used rest full api which is called Equipment.Rental.WebApi. You need to host it in somewhere in IIS.

Used frameworks
NLog => for logging
Autofac => IoC / Dependency injection
XUnit => For unit tests (I added several tests to show the my style, in fact should be covered)
NSubstitue => For mocking
Caching => For caching I used device memory but we can use Redis cache as well. I didn't use it for now because it is not fast you to test
