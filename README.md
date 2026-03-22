# GDIM32-Final
## Check-In

### Group Devlog
We had an issue with our terrain disappearing, so we tried to look through the history to find the commit where the terrain was deleted so we could revert the commit and try and get it back, however we were unable to do so so instead we had to remake the terrain. To avoid issues with stuff getting deleted, we tried not to work on the project at the same time and informed everyone when we made a commit and to make sure to check that nothing was missing. We also ran into a few merge conflicts where we had to store the changes we made so that we could undo the commit and pull changes before commiting again. We were able to diagnose these issues during playtesting when we got the help from another group who also had run into similar problems we were running into. 
#### Team Member : Beiduo Jin

During this stage of development, I mainly completed the core control system of the game, including the writing of Player.cs and GameController.cs, as well as the setting of background music in the scenes. In the Player section, I implemented the basic movement and jumping logic, using variables such as moveSpeed and jumpForce, and handled input and physics movement in Update() and FixedUpdate(). I also set up the collision detection for the player (OnCollisionEnter2D, OnTriggerEnter2D), and built the Rigidbody2D and Collider2D components of the Player GameObject in Unity. The GameController section is responsible for managing the game flow. I implemented the GameState enumeration, StartGame(), EndGame(), and AddScore() methods, and made it interact with the UI and Player. In addition, I created a separate BGM Player GameObject and added an AudioSource to enable the background music to play in a loop. 

Reviewing the Proposal and W7 breakdown provided me with an overall direction. However, during the actual development process, I found that the original plan was not detailed enough, especially in terms of the input handling for the Player, the structure of the state machine, and the way UI updates were handled. More details needed to be added when writing the code. Although the architecture was not significantly changed, I did continuously adjust method names, variable structures, and component settings throughout the process. To track progress, I also used a simple task list to record the functions that needed to be completed. In the future, I will write more specifically during the planning stage, such as listing out the methods and variables of each class, as well as the GameObject hierarchy structure required in the scene. This will reduce the occurrence of repeated modifications during development.

Besides, I used a free and open-source piece of music online as the background music. [audio link](https://mixkit.co/free-stock-music/chillout/)

#### Team Member : Sahasra Vytla
I created the player object and worked on the Player class and coded the basic movement for the player object using the Update method, which was then later tweaked by my teammate. I also coded the camera movement so that the camera follows the player object as it moves, which also was done in the LateUpdate method that runs after all of the other Update methods in Unity runs, including the Update method used for the Player movement which makes the camera move after the player moves. I put this method in a class called CameraMovement that I attached as a component to the Camera. 

I felt like the proposal we came up with was a bit more helpful than our break-down was since in our break down we sorta missed some key classes and objects we needed which we had to add later to the breakdown, an example of this being the CameraController class. The Proposal was able to help us fix our breakdown as we ran into issues since it provided everybody on our team a clear idea of what the project needed to do. Using Trello to organize our tasks was also a big help as we were able to list all of the tasks that needed to be completed and then delegate them to everyone. I think the future when it comes to panning I will try to be as detailed as possible in the ideas that I come up with so that they are interpreted in the way that I wanted them to be and are easier for my teammates to implenet without needing to ask me for clarification. 
#### Team Member Mira Liu
I created the terrain, painted it, imported assets to decorate it, as well as setting up the inventory class and the ui for it. I implemented some of the ingredient assets that are to be collected. I've made a Inventory, Dropped Item, Item Ui, InventoryUI class and Items as a scriptable object. I stored each individual ingredients data as rumpled code, and then attached them to a Dropped Item Prefab. 

The proposal has served as a nice guideline to my coding of the UI, however a description for inventory was not written down, so I kinda had to improvise. None of the features mentioned for the UI have been properly implemented just yet, but I have placed placeholders. The proposal was very organized in the sense that everyone knew their tasks. However, the breakdown was a little more vague. In the future, the breakdown could be a little more detailed and strict so that people know the design of such and can follow it. We used Trello to assign tasks for the week, and I had a clear idea of what I was supposed to do. In the future, I think I could approach the execution with better planning as well as consistent communication. 


## Final Submission
### Group Devlog
Our final project uses three major design patterns—Model–View–Controller (MVC), Finite State Machine (FSM), and the Singleton pattern—to organize player interaction, NPC dialogue, and quest flow.

1. MVC Architecture  
We used MVC to structure both the player controller and the NPC interaction system. Scripts like PlayerMovement.cs and PlayerCamera.cs act as Controllers, processing input and updating the View (the player model and camera). The dialogue UI and interaction prompts form the View, while dialogue data and quest states act as the Model. This separation made it easy to update UI, input, or movement logic without breaking the others.

2. Finite State Machine (FSM)  

We used finite state machine for the pot where the player cooks the pho. We had three states, Empty, Cooking and Done. Using these different states made it easier to code the different stages of the pho cooking since we were able to make it so the players could interact with the pot and put ingredients during the empty state, but they couldn't intereact with the pot when it was in the cooking state but then they could take the pho out of the pot when it was in the done state. During the done state we were also able to code the pot to play a sound when it finished cooking the pho. There was also a text that could be updated to say something different depending on the state the pot was in.

3. Singleton Pattern  
We used Singletons for global systems like the DialogueManager, QuestManager and IngredientSpawner. These managers handle displaying prompts, loading dialogue branches, tracking quest progress, updating NPC responses and respawning ingredients. Having a single shared instance ensured consistent behavior across scenes and allowed any script to access dialogue or quest data without passing references.

Together, these patterns helped us build a clean, modular interaction system where player actions, NPC dialogue, and quests work smoothly as a unified experience.


### Team Member Name: Beiduo Jin

Since the Check‑In, my contributions focused on building core gameplay systems and stabilizing the project. I implemented the StartMenu.cs script, which pauses the game on launch, displays the start menu UI, and resumes gameplay when the player closes the menu. I also imported external UI assets and converted them into usable Unity prefabs, integrating them into the scene and wiring them to the menu logic.

I contributed to the player controller by modifying both PlayerMovement.cs and PlayerCamera.cs. This included adjusting Rigidbody‑based movement, fixing orientation alignment, and correcting mouse‑driven camera rotation to achieve proper FPS controls. I also configured the player prefab in Unity by assigning components such as Rigidbody, camera references, and orientation transforms.

Beyond feature work, I resolved multiple merge conflicts involving player and camera scripts, ensuring our team’s final versions remained consistent. I additionally fixed several runtime errors, including null references caused by missing tags or unassigned variables in scripts like Dialogue.cs.

Overall, my work helped stabilize the project and ensured the core player experience functioned smoothly.

### Team Member Name: Sahasra Vytla

For the Final Project I worked on fixing the mouse movement issues and fine tuning the camera movement and player movement since we had been running into a couple issues where the character wouldn't be able to turn or move properly. To fix the mouse movement I created the PlayerCamera movement that I attached to the Camera object and in it I wrote code to lock the mouse in place as well as added code where if the player presses escape and V they can unlock and lock the mouse so that they could interact with the UI still. I then added variables that took the player's mouse input and then added it the camera's ddirection but used the Math Clamp function so that the Player couldn't turn too far up. I then worked on the quests system, and I tried to use Scriptable Objects at first but then I felt like it was too complicated for there only being two quests so I chose to just use an Enum and C# events. I created Quest, QuestManager and QuestUI classes that all work together to display the quest and the player's progress. I also added code in other classes to update when a task for the quest was completed. 

### Team Member Name: Mira Liu 
For the Final Project, I was tasked with programming the state machine for cooking. I also fixed mouse movement and added a crosshair that detects which ingredients the player is looking at through Raycast by turning green. I also went back to fix the item collection system, replacing the previous PNGs with 3D assets. I created a Pot class, a Player Interaction class, and ScriptableObject for the Recipes. I also created ScriptableObjects for the various ingredients and assigned them to the prefabs I created. To fix the camera issue, I had the object spawn based on the MainCamera position instead of the player position. I created UI to display the state of cooking whenever the state changes. I set up the timer as well as how items disappear when they collide with the pot.

## Open-Source Assets
[Pot Asset](https://www.cgtrader.com/items/5036369/download-page)
[food kit assets](https://kenney.nl/assets/food-kit)
[Terrain texture](https://assetstore.unity.com/packages/tools/terrain/stampit-collection-free-heightmaps-for-unity-6-microverse-gaia-t-218286?clickref=1100lC35LG7U&utm_source=partnerize&utm_medium=affiliate&utm_campaign=unity_affiliate)

[Grass and Vegetation](https://assetstore.unity.com/packages/3d/environments/low-poly-trees-and-vegetation-pack-265300)

[Cute Animals Player and NPC](https://assetstore.unity.com/packages/3d/characters/animals/little-friends-cartoon-animals-lite-262505)

[Background Audio](https://pixabay.com/sound-effects/musical-loop-file-jazz-waltz-34-beat-bpm132-144689/)
