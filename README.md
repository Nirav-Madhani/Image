# Image
Image - Server Instance and Room management for Mirror Networking

## Why and When to use Image

It is primarily designed to handle complications faced when implementing Room logic for scenes that have complicated physics.
Although MultipleAddictiveScenes examples is another way to implement this, it very quickly becomes overcomplicated when we try to modify it to suit our needs.
Therfore an alternate solution is required to seperate room management from development of multiplayer game logic.

Image tries to solve this problem by providing a standalone application which provides fundamental and modular blocks to handle room management outside (as well as inside if required) Unity Environmment .
Furthermore, this can be also used for scaling the project. Developer has complete control over who has authority to choose the room for player; `client` or `server`

Moreover, the basic code provided has all the functionality required to deploy the game to a cloud. There are only few variables that the developer / dev-ops engineer needs to configure.
