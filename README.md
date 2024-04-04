# WickerREST RevealMap Sample Plugin

RevealMapREST is a sample mod developed for Farthest Frontier that utilizes a RESTful interface for revealing the map and monitoring game states such as whether the game has been fully initialized. This sample mod is built on top of [WickerREST](https://github.com/derekShaheen/WickerREST), enabling dynamic interaction with the game through web requests.

While this sample is for Farthest Frontier, the WickerREST works on any Unity game, Mono or IL2CPP, and plugins can be made for each of them.

## Example Features

- **Reveal Map Command**: Exposes an HTTP command that triggers the map reveal action within Farthest Frontier.
- **Game Initialization Monitoring**: Allows monitoring the game's initialization state through a dedicated game variable.

## Installation

1. **Prerequisites**: 
    1. Ensure you have [MelonLoader](https://melonwiki.xyz/) installed in your Unity game.
    2. Ensure you have [WickerREST](https://github.com/derekShaheen/WickerREST) installed in your Unity game.
2. **Build Plugin**: Download the latest code from this repository and set up your references. 
3. **Installation**: This mod requires WickerREST to function. Ensure that WickerREST and the built plugin are installed in your game `/Mods/` folder.

## Usage

Once installed, the mod will be loaded automatically when you start Farthest Frontier. You can then interact with the mod's features through HTTP requests:

- **Interface**: Use a browser to navigate to `http://localhost:6103` to reveal the dashboard.
- **Reveal Map**: Send a GET request to `http://localhost:6103/revealMap` to reveal the map.
- **Example Command*: Provides an example on how to use inputs.
- **Check Game Initialization**: Access `http://localhost:6103/game-variables` to see the current value of the monitored variables.

This sample project produces a command and a game variable monitor. As of time of writing, the frontend interface looks like this, with this sample plugin loaded.

![SampleUserInterface](https://i.imgur.com/SFzaWUX.png)
![SampleUserInterface2](https://i.imgur.com/zMIWMhI.png)

## Developing Your Own Commands and Variables

RevealMapREST serves as an example of how to create your own commands and game variables using WickerREST. Here's a brief guide:

### Creating Command Handlers

1. Annotate a static method with the `[CommandHandler]` attribute, providing the path for the command:
    ```csharp
    [CommandHandler("yourCommand")]
    public static void YourCommandHttp(HttpListenerResponse response)
    {
       // Implement command action
       Wicker.Server.Instance.SendResponse(response, "Command executed successfully");
    }
    ```
2. Implement the logic within the method. Use Wicker.Server.Instance.SendResponse to send back a response to the caller.

### Monitoring Game Variables

1. Use the [GameVariable] attribute to expose a static property or method as a game variable:

    ```csharp
    [GameVariable("YourVariable")]
    public static string YourGameVariable => // Your variable retrieval logic here
    ```

Access `http://localhost:6103/game-variables` to see the value of your exposed variables.