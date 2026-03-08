# Family Tree App

A full-stack family tree web application inspired by [Family Echo](https://www.familyecho.com), built with **ASP.NET Core C# (backend)** and **HTML/CSS/JS (frontend)**.

## Features

- Interactive canvas-based family tree visualization
- - Drag & drop nodes to rearrange the tree
  - - Pan the canvas and zoom in/out (mouse wheel or slider)
    - - Add, edit, and delete family members
      - - Personal details: given names, surname, gender, birth date, living status
        - - Contact details: email, phone, notes
          - - Relationships: parent, spouse, sibling — displayed as color-coded bezier curves
            - - Data persisted as JSON on the server
              - - Family Echo-inspired beige/dark-red/navy color scheme
               
                - ## Tech Stack
               
                - | Layer    | Technology            |
                - |----------|-----------------------|
                - | Backend  | ASP.NET Core 8 (C#)   |
                - | Frontend | HTML5 Canvas + CSS    |
                - | Storage  | JSON file (server-side) |
               
                - ## Project Structure
               
                - ```
                  family-tree-app/
                  └── FamilyTreeApi/
                      ├── Controllers/
                      │   └── FamilyTreeController.cs   # REST API endpoints
                      ├── Models/
                      │   └── FamilyMember.cs           # Data models
                      ├── Services/
                      │   └── FamilyTreeService.cs      # Business logic + JSON persistence
                      ├── wwwroot/
                      │   └── index.html                # Full frontend (HTML + CSS + JS)
                      ├── Program.cs                    # App entry point
                      ├── appsettings.json
                      └── FamilyTreeApi.csproj
                  ```

                  ## Getting Started

                  ### Prerequisites
                  - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
                 
                  - ### Run Locally
                 
                  - ```bash
                    git clone https://github.com/rsaiteja/family-tree-app.git
                    cd family-tree-app/FamilyTreeApi
                    dotnet run
                    ```

                    Then open your browser at `http://localhost:5000`

                    ## API Endpoints

                    | Method | Endpoint                        | Description             |
                    |--------|---------------------------------|-------------------------|
                    | GET    | /api/FamilyTree                 | Get full tree           |
                    | GET    | /api/FamilyTree/members         | List all members        |
                    | POST   | /api/FamilyTree/members         | Add a member            |
                    | PUT    | /api/FamilyTree/members/{id}    | Update a member         |
                    | DELETE | /api/FamilyTree/members/{id}    | Delete a member         |
                    | GET    | /api/FamilyTree/relationships   | List all relationships  |
                    | POST   | /api/FamilyTree/relationships   | Add a relationship      |
                    | DELETE | /api/FamilyTree/relationships/{id} | Delete a relationship |

                    ## Usage

                    1. Click **+ Add Person** to add your first family member
                    2. 2. Click a node on the canvas to select and edit their details in the sidebar
                       3. 3. Drag nodes to arrange the tree layout
                          4. 4. Click **+ Add Relationship** to connect two people
                             5. 5. Scroll to zoom, drag the background to pan
                               
                                6. ## Design
                               
                                7. Inspired by the clean, warm beige aesthetic of Family Echo:
                                8. - Beige/tan backgrounds (`#e8ddd2`, `#f8f2ec`)
                                   - - Dark red accents (`#8b0000`) for the title and delete actions
                                     - - Navy blue (`#4a4a8a`) for tabs, buttons, and relationship lines
                                       - - White cards with colored gender-indicator stripes (blue=Male, pink=Female, grey=Other)
                                         - 
