# GDIM32-Final
## Check-In
### Team Member Beiduo Jin

During this stage of development, I mainly completed the core control system of the game, including the writing of Player.cs and GameController.cs, as well as the setting of background music in the scenes. In the Player section, I implemented the basic movement and jumping logic, using variables such as moveSpeed and jumpForce, and handled input and physics movement in Update() and FixedUpdate(). I also set up the collision detection for the player (OnCollisionEnter2D, OnTriggerEnter2D), and built the Rigidbody2D and Collider2D components of the Player GameObject in Unity. The GameController section is responsible for managing the game flow. I implemented the GameState enumeration, StartGame(), EndGame(), and AddScore() methods, and made it interact with the UI and Player. In addition, I created a separate BGM Player GameObject and added an AudioSource to enable the background music to play in a loop. 

Reviewing the Proposal and W7 breakdown provided me with an overall direction. However, during the actual development process, I found that the original plan was not detailed enough, especially in terms of the input handling for the Player, the structure of the state machine, and the way UI updates were handled. More details needed to be added when writing the code. Although the architecture was not significantly changed, I did continuously adjust method names, variable structures, and component settings throughout the process. To track progress, I also used a simple task list to record the functions that needed to be completed. In the future, I will write more specifically during the planning stage, such as listing out the methods and variables of each class, as well as the GameObject hierarchy structure required in the scene. This will reduce the occurrence of repeated modifications during development.

Besides, I used a free and open-source piece of music online as the background music. The following is the source: https://mixkit.co/free-stock-music/chillout/

### Team Member Name 2
Put your individual check-in Devlog here.
### Team Member Name 3
Put your individual check-in Devlog here.


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

[Cute Animals](https://assetstore.unity.com/packages/3d/characters/animals/little-friends-cartoon-animals-lite-262505)
