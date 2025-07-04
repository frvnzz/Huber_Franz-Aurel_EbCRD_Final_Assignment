# Final Assignment for EbCRD

This project uses third party assets like 3D models from the [Unity AssetStore](https://assetstore.unity.com/). All assets are documented in [**ThirdPartyAssets.md**](/ThirdPartyAssets.md).

---

### Project Idea

The project idea that I had for this final assignment was an aim trainer game / indoor shooting range simulator. I initially sketched out a small document that lists MVP, Idea, Scenes and a project structure idea:

![Project Idea Notes](/img/project_notes.png)
---

### How to Run the Program (User Guideline)
1. **Download and Install Unity 6**  
   Ensure you have Unity installed on your system. The project was developed using Unity version `6000.0.50f1`.  

2. **Clone the Repository**  
   Clone the project repository to your local machine with:
   ```bash
   git clone https://github.com/frvnzz/Huber_Franz-Aurel_EbCRD_Final_Assignment.git
   ```

   Alternatively, you can download the repository as a .zip file from 
   [here](https://github.com/frvnzz/Huber_Franz-Aurel_EbCRD_Final_Assignment/archive/refs/heads/main.zip).  

3. **Open the Project**  
   Open Unity Hub, add the folder `src` from the cloned repository, and open the project.  

4. **Run the Scene**  
   Start the Game from the **Main Menu** scene

---

### Logic

#### Score System
- The **ScoreManager.cs** script tracks the player's score throughout the game.
- Each time a target is hit, the score increases by 1 using the `AddScore()` method.
- When the game ends, the final score is saved to the `lastScore` variable and displayed on the Game Over screen.
- When restarting the game (handled through the `StartGame()` method in **MainMenu.cs**), the score gets set to the `startingScore` variable of **GameManager.cs**.

#### Player Health and Target Logic
- The **PlayerHealth.cs** script manages the player's health, which starts at 3 by default.
- Missing a shot (checked via `!isHit` in **TargetScript.cs**) calls the `LoseHealth()` method of **PlayerHealth.cs**.
- If health reaches zero, the game ends automatically by calling the `EndGame()` method of **GameManager.cs**.

#### Timer
- The **Timer.cs** script manages the countdown timer for each round.
- When the game starts, the timer is initialized with `gameDuration` of **GameManager.cs** and started using the `StartTimer()` method.
- The timer counts down in real time, and when it reaches zero, the game ends automatically by calling the `EndGame()` method of **GameManager.cs**.
- The **TimerDisplay.cs** script updates the UI to show the remaining time in the game.

#### Leaderboard
- The **LeaderboardManager.cs** script manages saving and loading the top scores to a persistent .json file (`leaderboard.json`) by using the `Application.persistentDataPath`. When the game ends through `GameManager.EndGame()`, the final score is added to the .json by calling `LeaderboardManager.AddEntry()`. The leaderboard keeps only the top 5 scores and adds a timestamp for when they were achieved.

#### Display Scripts

These display scripts always reflect the current game state, while keeping UI separate from the logic.

- The **ScoreDisplay.cs** script shows the score UI by reading the current score from `ScoreManager`.
- The **PlayerHealthDisplay.cs** script shows the player's health UI by reading the current health from `PlayerHealth`.
- The **TimerDisplay.cs** script shows the remaining time in the UI by reading the countdown value from `Timer` and formatting it as minutes and seconds for the player.
- The **LeaderboardDisplay.cs** script displays the leaderboard on the Game Over screen. It reads the data from the .json with `LeaderboardManager.Load()` and formats the scores to display them in a `TextMeshProUGUI` field.

---

### Resources

Here are all the resources I had to use in addition to EbCRD and CD course contents to achieve the features I wanted for the game. These are mainly focused on persistent data management for the leaderboard/highscore.

#### Videos

- [Data Persistence Three Ways (Saving and Loading in Unity)](https://www.youtube.com/watch?v=YfOsdfrMvVk)
- [How to SAVE and LOAD Game Data in Unity 6 (Tutorial 2025)](https://www.youtube.com/watch?v=llmaxNvwy4E)
- [Make a FIRST PERSON SHOOTER in 10 MINUTES - Unity Tutorial](https://www.youtube.com/watch?v=OFXvvuxqPNQ&t=357s)
- [5 Minute MAIN MENU Unity Tutorial](https://www.youtube.com/watch?v=-GWjA6dixV4&t=63s)

#### Websites and Documentation

- [Application.persistentDataPath, Scripting API](https://docs.unity3d.com/6000.1/Documentation/ScriptReference/Application-persistentDataPath.html)
- [JsonUtility, Scripting API](https://docs.unity3d.com/ScriptReference/JsonUtility.html)
- [Script serialization, Scripting API](https://docs.unity3d.com/6000.1/Documentation/Manual/script-serialization.html)
- [Splitting tasks across frames, Scripting API](https://docs.unity3d.com/6000.1/Documentation/Manual/coroutines.html)