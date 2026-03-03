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
Put your group Devlog here.


### Team Member Name 1
Put your individual final Devlog here.
### Team Member Name 2
Put your individual final Devlog here.
### Team Member Name 3
Put your individual final Devlog here.

## Open-Source Assets
[Pot Asset](https://www.cgtrader.com/items/5036369/download-page)

[Terrain texture](https://assetstore.unity.com/packages/tools/terrain/stampit-collection-free-heightmaps-for-unity-6-microverse-gaia-t-218286?clickref=1100lC35LG7U&utm_source=partnerize&utm_medium=affiliate&utm_campaign=unity_affiliate)

[Grass and Vegetation](https://assetstore.unity.com/packages/3d/environments/low-poly-trees-and-vegetation-pack-265300)

[Cute Animals Player and NPC](https://assetstore.unity.com/packages/3d/characters/animals/little-friends-cartoon-animals-lite-262505)

[Chicken png](https://www.kindpng.com/imgv/TmhwRhm_minecraft-7-chuckles-the-chicken-minecraft-hd-png/)

[Cow png](https://www.kindpng.com/imgv/TRoJTJT_raw-beef-plush-minecraft-hd-png-download/)
