


# Image
Image - Server Instance and Room management for **Mirror**

 ```
  __  .___  ___.      ___       _______  _______ 
|  | |   \/   |     /   \     /  _____||   ____|
|  | |  \  /  |    /  ^  \   |  |  __  |  |__   
|  | |  |\/|  |   /  /_\  \  |  | |_ | |   __|  
|  | |  |  |  |  /  _____  \ |  |__| | |  |____ 
|__| |__|  |__| /__/     \__\ \______| |_______|

```
## Index

- [Why and When to use Image](#why-and-when-to-use-image)
- [Demos & Showcase](https://github.com/Nirav-Madhani/Image-Demos) (Ctrl/Cmd + Click to Open in new tab)
- [Architecture and FLow](#architecture-and-flow)
- [Contributing](#contributing)
- [To Do](#to-do)
- [Testing on GCP](#testing-the-example-deployment-on-gcp)
- [Testing on Local Server](#testing-with-local-server-if-gcp-is-not-online)
- [Docs](#docs)


## Why and When to use Image

It is primarily designed to handle complications faced when implementing Room logic for scenes that have complicated physics.
Although MultipleAddictiveScenes examples is another way to implement this, it very quickly becomes overcomplicated when we try to modify it to suit our needs.
Therfore an alternate solution is required to seperate room management from development of multiplayer game logic.

Image tries to solve this problem by providing a standalone application which provides fundamental and modular blocks to handle room management outside (as well as inside if required) Unity Environmment .
Furthermore, this can be also used for scaling the project. Developer has complete control over who has authority to choose the room for player; `client` or `server`

The basic code provided has all the functionality required to deploy the game to a cloud. There are only few variables that the developer / dev-ops engineer needs to configure.

## Architecture and FLow

![image](https://user-images.githubusercontent.com/77914957/148757652-cc7532d5-043a-4641-9b74-0a3f770c82a8.png)

## Contributing

Project **Image** is in its preliminary phase. There are lot's of features that can be added. Also, the project has not been evaluated in terms of security against common attacks. Any form of contribution, whether it be code, demo, documentation, bug-reports or vulnerability identification is very welcomed!

## To Do

- [ ] More Algorithms for Room Allocation
- [ ] Authentication
- [ ] Optional Use Database functionality
- [ ] Handling more than 1 server, ie `Many Ip Many Ports`
## Stats
Powered by [GithubStatsTracker](https://github.com/Nirav-Madhani/GithubStatsTracker)

![](https://docs.google.com/spreadsheets/u/2/d/e/2PACX-1vRpQWfmElUl5p6sUCKp-TYJPMXfNF9tHqf5gH8BkF-N92uW94fxWyLK2psixOjZ4SxtDe-SCDG_7rPg/pubchart?oid=2004236886&format=image)
## Testing the example deployment on GCP

1. Open `Builds/Client/MultiplayerRoom.exe`.
2. You will see Mirror tanks example scene with Server address already set.

![image](https://user-images.githubusercontent.com/77914957/148752639-25cd4b48-3f36-46ad-87ec-f2620a789fd4.png) 

3. If you seen `Port Number` already set to `10001 or greater`, that means server is running in the GCP

![image](https://user-images.githubusercontent.com/77914957/148752892-1a552915-c4c0-42a5-b138-41f23d6e90a9.png)

4. Simply Click on client and game will be loaded.
5. Open one more instance of game on your PC or other PC and enjoy the demo.
6. Open more than 4 instance and you will see that 5th one will open in other room.
(If you are the only one testing server at that time)

Note: Number of players label will not be updated. It was for debugging purpose.

## Testing with Local Server (if GCP is not online)

1. Goto Python folder and type `cmd` in address bar
2. Type `python main.py` or `python3 main.py` whichever works for you. You will see something like this.
![image](https://user-images.githubusercontent.com/77914957/148755194-ff355a53-a2e1-4779-ac7d-43ff1989b94a.png)

3. Open `Builds/ClientLocal/MultiplayerRoom.exe` instead of `Builds/Client/MultiplayerRoom.exe`. and rest of the steps are same.

### Docs
- [Manual](Docs/Documentation.docx )
- [Hosting on GCP](HostGCP.md)



