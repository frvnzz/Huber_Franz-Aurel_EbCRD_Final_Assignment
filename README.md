# Final Assignment for EbCRD

This project uses third party assets like 3D models from the [Unity AssetStore](https://assetstore.unity.com/). All assets are documented in [**ThirdPartyAssets.md**](/ThirdPartyAssets.md).

---

### Project Idea

The project idea that I had for this final assignment was an aim trainer game / indoor shooting range simulator. I initially sketched out a small document that lists MVP, Idea, Scenes and a project structure idea:

![project_notes.pdf](/img/project_notes.png)
---

### How to Run the Program (User Guideline)
1. **Download and Install Unity 6**  
   Ensure you have Unity installed on your system. The project was developed using Unity version `6000.0.50f1`.  

2. **Clone the Repository**  
   Clone the project repository to your local machine with:
   ```bash
   https://github.com/frvnzz/Huber_Franz-Aurel_EbCRD_Final_Assignment.git
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
- The **TimerDisplay.cs** script updates the UI to show the remaining time to the

#### Display Scripts

These display scripts always reflect the current game state, while keeping UI separate from the logic.

- The **ScoreDisplay.cs** script shows the score UI by reading the current score from `ScoreManager`.
- The **PlayerHealthDisplay.cs** script shows the player's health UI by reading the current health from `PlayerHealth`.
- The **TimerDisplay.cs** script shows the remaining time in the UI by reading the countdown value from `Timer` and formatting it as minutes and seconds for the player.