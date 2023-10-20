# CommanderGraphQL
- [README_Architecture](./README/README_Architecture.md)
In this step-by-step tutorial I take you through how build a GraphQL API using C#9, .NET 5 and the Hot Chocolate framework.
The video covers:

- Application Architecture Overview
- GraphQL theory and core concepts
- Building Queries
- Multi-threaded queries using Pooled DBContextFactory
- Sorting & Filtering
- Building Mutations
- Building Subscriptions (real-time event notifications with Web Sockets)

Level: Intermediate

1 - INTRODUCTION
-  Welcome
-  Demo
-  Course Overview
-  Architecture
-  Ingredients 

2 - THEORY
-  What is GraphQL?
-  GraphQL Core Concepts
-  REST Vs GraphQL
-  GraphQL Frameworks in .NET

3 - CODING PART 1
-  Environment Setup
-  Project Setup
-  Setup SQL Server with Docker
-  Configuration & Dependency Injection
-  Set up our 1st Model
-  Setup DB Context & Connection String
-  Migrate to DB
-  Create GraphQL Query
-  Configuring GraphQL Services (Startup Class)
-  Configuring GraphQL in Request Pipeline ()
-  Querying our endpoint with Banana Cake Pop & Insomnia
-  Setting up and using GraphQL Voyager
-  Concurrent quering issue
-  Introducing the Pooled DbContext Factory

4 - CODING PART 2 - EXTENDING OUR QUERIES
-  Adding our 2nd Model
-  Update DBContext & Migrate
-  Querying with multi-model - using projection
-  Adding a Commands Query
-  Adding in-line documentation to our API
-  Annotation Vs Code First approaches
-  Adding a Platform Type with Resolver
-  Adding a Command Type with Resolver
-  Sorting & Filtering capabilities 

5 - CODING  3 - MUTATIONS & SUBSCRIPTIONS
-  Introducing Mutations & Adding Platforms
-  Testing our Platform Mutation
-  Adding a Commands Mutation
-  Testing our Commands Mutation
-  Adding Subscriptions (Real-time events)
-  Testing our Subscription

6 - WRAP UP
-  Wrap up and Final thoughts
-  Patreon Supporter Credits
