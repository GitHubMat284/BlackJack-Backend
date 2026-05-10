# Blackjack Backend

This project is a simple single-player Blackjack API designed to demonstrate clean architecture principles rather than full casino-level gameplay. The game follows standard Blackjack fundamentals: a player competes against a dealer using a standard 52-card deck, aiming to reach a hand value as close to 21 as possible without exceeding it. Number cards are worth their face value, face cards are worth 10, and aces are treated as 11 or 1 depending on what keeps the hand under 21. The player can choose to Hit (draw a card) or Stand (end their turn), after which the dealer plays automatically by drawing until reaching at least 17. The outcome is determined by comparing final hand values, with results including win, loss, bust, or push. Advanced rules such as betting, splitting, doubling down, or multiplayer are intentionally excluded to keep the focus on core game logic and architecture.

# Reference tutorial:
[![Blackjack Tutorial](https://img.youtube.com/vi/xjqTIzYkGdI/0.jpg)](https://www.youtube.com/watch?v=xjqTIzYkGdI)
---

## Architecture Overview

This project follows Clean Architecture (Ports and Adapters) to clearly separate concerns and ensure maintainability.

### Layers

**Domain**
- Contains core business logic and rules
- Entities include Game, Player, Dealer, Hand, and Card
- No dependency on frameworks or external systems

**Application**
- Contains use cases such as StartGame, PlayerHit, and PlayerStand
- Defines interfaces (ports) like `IGameDataGateway`
- Handles request and response models (DTOs)

**Infrastructure**
- Implements interfaces defined in Application
- Current implementation uses in-memory storage
- Can be replaced with cloud storage without changing core logic

**Presentation**
- Azure Functions exposing HTTP endpoints
- Responsible for handling requests, responses, and dependency injection

### Key Principle

Following Single Responsibility Principle and the Dependency rule means all dependencies flow inward:
- Presentation → Application → Domain
- Infrastructure → Application → Domain

This ensures the core logic remains independent and testable. All other additions are simply plug-in details to our system.

---

## API Endpoints

### Start Game

**POST** `/api/StartGame`

#### Request
```json
{
  "playerName": "Matheo"
}
```

#### Response
```json
{
  "gameID": "string",
  "status": "PlayerTurn",
  "playerCards": [
    { "suit": "Hearts", "rank": "Ace", "value": 11 }
  ],
  "dealerCards": [
    { "suit": "Clubs", "rank": "Ten", "value": 10 }
  ]
}
```

### Player Hit

**POST** `/api/PlayerHit`

#### Request
```json
{
  "gameID": "string" // Same as given by StartGame
}
```
#### Response
```json
{
  "gameID": "string",
  "status": "PlayerTurn",
  "playerCards": [
    { "suit": "Hearts", "rank": "Ace", "value": 11 }
  ],
  "dealerCards": [
    { "suit": "Clubs", "rank": "Ten", "value": 10 }
  ]
}
```

### Player Stand

**POST** `/api/PlayerStand`

#### Request
```json
{
  "gameID": "string" // Same as given by StartGame
}
```
#### Response
```json
{
  "gameID": "string",
  "status": "PlayerTurn",
  "playerCards": [
    { "suit": "Hearts", "rank": "Ace", "value": 11 }
  ],
  "dealerCards": [
    { "suit": "Clubs", "rank": "Ten", "value": 10 }
  ]
}
```

## Local Development
### Prerequisites
-   .NET 8 SDK
- Azure Functions Core Tools

## local.settings.json
Create this file in the Functions project root:
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"
  }
}
```

## Run the project
```bash
func start
```
or run the Functions `BlackJack_Backend` from Visual Studio

## Testing
Use Postman or any HTTP client to call the endpoints

## Notes
- The current implementation uses in-memory storage for simplicity
- Game state is lost if the application restarts
- In a production environment, this should be replaced with persistent storage such as Azure Table Storage or Cosmos DB