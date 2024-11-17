# **Unity Shop System: Repository & Unit of Work Patterns**

This Unity project is a demonstration of **Repository Pattern** and **Unit of Work Pattern** applied in a practical shop system. It integrates clean code principles, structured data handling with JSON, and dynamic UI updates to offer an educational experience for developers.

---

## **Table of Contents**

1. [Overview](#overview)  
2. [Features](#features)  
3. [Technologies Used](#technologies-used)  
4. [Project Structure](#project-structure)  
5. [Getting Started](#getting-started)  
6. [How It Works](#how-it-works)  
7. [Screenshots](#screenshots)  
8. [Contributing](#contributing)  
9. [License](#license)  

---

## **Overview**

This project showcases a shop system where players can purchase items using in-game currency.  
It is designed to help developers learn and implement:  
- **Repository Pattern**: Simplifies data access logic.  
- **Unit of Work Pattern**: Manages transactions across multiple repositories.  
- **JSON-based Data Storage**: Enables scalable and easy-to-edit data management.  

---

## **Features**

- **Shop System**:
  - Displays a list of purchasable items with their names, prices, and purchase buttons.
  - Updates player's money dynamically after each purchase.
  - Prevents purchases when funds are insufficient.

- **Repository Pattern**:
  - Encapsulates data access to maintain separation of concerns.
  - Handles item loading from JSON and makes the system testable.

- **Unit of Work Pattern**:
  - Coordinates transactions across repositories for consistency.
  - Ensures updates to inventory and wallet happen together.

- **JSON Data Storage**:
  - Item details are stored in a JSON file (`ItemData.json`), making it easy to modify or expand.

---

## **Technologies Used**

- **Unity Engine** (6000.0.25f1)  
- **C# Scripting**  
- **JSON for Data Storage**  
- **TextMeshPro** for polished UI elements  

---

## **Project Structure**

Here’s a breakdown of the project files and folders:

```plaintext
Unity
├── Assets
│   ├── Data
│   │   └── ItemData.json          # JSON file containing item details
│   ├── Prefabs                    # Unity prefabricated assets
│   ├── Scenes                     # Unity scenes
│   ├── Scripts
│   │   ├── Repository Pattern     # Implementation of Repository Pattern
│   │   │   ├── DataContext.cs
│   │   │   ├── GameData.cs
│   │   │   ├── Item.cs
│   │   │   ├── Items.cs
│   │   │   ├── Player.cs
│   │   │   ├── Repository.cs
│   │   │   └── PopulateShop.cs
│   │   ├── Unit of Work Pattern   # Implementation of Unit of Work Pattern
│   │   │   ├── UnitOfWok.cs
│   │   │   ├── UOWDataContext.cs
│   │   │   ├── UOWGameData.cs
│   │   │   ├── UOWItem.cs
│   │   │   ├── UOWItems.cs
│   │   │   ├── UOWPlayer.cs
│   │   │   ├── UOWRepository.cs
│   │   │   └── UOWPopulateShop.cs
│   └── TextMesh Pro               # Fonts and UI text assets
├── Packages                       # Unity package manager dependencies
```
## **How It Works**

### **Repository Pattern**

- **Purpose**: Simplifies data access logic and separates concerns.  
- **Implementation**:  
  - The `Repository` class handles reading data from `ItemData.json`.  
  - **Example Usage**:  
    ```csharp
    var items = repository.GetAllItems();
    ```

---

### **Unit of Work Pattern**

- **Purpose**: Ensures atomic operations across multiple repositories.  
- **Implementation**:  
  - The `UnitOfWok` class manages repositories to ensure consistency during transactions.  
  - **Example Usage**:  
    ```csharp
    using (var unitOfWork = new UnitOfWok())
    {
        unitOfWork.ItemsRepository.BuyItem(item);
        unitOfWork.Complete();
    }
    ```

---

### **JSON Data**

- **Purpose**: Stores data for items in a structured and easily modifiable format.  
- **Data Format** (`ItemData.json`):  
  ```json
  [
      { "id": 1, "name": "Sword", "price": 100 },
      { "id": 2, "name": "Shield", "price": 150 },
      ...
  ]
  ```

### **UI**

- Built using Unity's UI system and enhanced with **TextMeshPro**.  
- Dynamically loads data and displays items in a grid layout.
