# One Button Starter
This is intended to be a starter project for Game1501, Rapid Prototyping, and its first project, the One Button Game. The current project is in 2D but the code could be easily used for a 3D project. It uses the **Unity Input System**, but you should be able to get by without familiarizing yourself with it.

## Usage
In a scene, grab an InputObject from the prefabs folder and drag it into your scene (if you are not using the prefab, just attach the `PlayerInputs.cs` script to some object in your scene).

For whatever object you want to receive One Button input (like, for example, a PlayerController), you will need to follow the following steps:
1. Have that object implement the `IButtonListener` interface. For example: `public class JumpBall : MonoBehaviour, IButtonListener`, and then implement the 3 functions in IButtonListener.
2. Find the input object in your scene and register your object as a listener. For example: 
   ```  
   var inputObject = FindObjectOfType<PlayerInputs>();
   inputObject.RegisterListener(this);
   ```

# Button Info
Each button press will carry a struct of `ButtonInfo`, and this contains information about the button press such as how long it was held, when it was released, etc. Each button will also get an ID according to how many button presses have happened in your level. 

# Device Support and Configurtation
In the `Scripts/Inputs` folder, there is the GameInputs object which allows for Controller support and Keyboard/Mouse support. Currently the one button's `Interact` command is mapped to the south button on a gamepad and spacebar respectively, but it could very easily be mapped to different things. Feel free to change these for your own usage. 