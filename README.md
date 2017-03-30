# DynamicUI

This simple Unity project shows how you can easily create dynamic UIs. This allows for the usage of the same UI in different situations and for the use of different UIs in the same situation (to have multiple themes for example).

In the Assets folder of this project you'll find two folder, OLD and NEW, that you are encouraged to explore. They show two different implementations of the way dynamic UIs are managed.

> NOTE: The NEW method is not yet implemented. Soon thou... :)

## Installation and Running

1. Download the project (using `git clone` or downloading the zip file)
1. Open the project in Unity
1. Select a scene in either OLD or NEW format and open it
1. Press Play and see that a UI was created
1. Explore the code.

## Usage

### OLD

Create a Prefab starting with a Canvas and create a Hook, this bundle will allow you to create multiple prefabs for the same Hook.

> Drag one of the prefabs in Old/Prefabs/UI to see how it is being used.
> Play special attention to the way the buttons interact with the hook.

Create a Class that inherits Control and implement your code there.

> See `MainScript.cs` and `YesNoControl.cs` to see how it is made.
