# Rogue Like Game 0.1.2 By Stephan Almisry
The current iteration of the rogue-like that I have been working on for the past few weeks.  \
The goal is to have the enemies drop items/currency upon being killed and for the player to  \
gather them into their inventory. Currently the game has a UI element for the inventory, some  \
test item/gold pickups, the player character, and a test enemy for both AI testing as well as  \
something to test combat in the future.
## Features and Mechanics
The Enemy has a simple mechanic to them that they chase the player if they come too close and  \
go back to their starting position once the player has wandered/ran away for a certain amount  \
of time. This uses a simple check to see if the player is within their range of sight and then  \
navigates them to that point in the shortest way possible. Now pathfinding is not implemented  \
yet into the program however I do plan on putting it in into the future once I have a better  \
understanding of the subject matter.  \
For the return mechanic I have the enemy store a value of where they were spawned at first to  \
have a value to return to, then once that is done I have them walk back to that starting value  \
in the shortest path possible. A very simple algorithm!  \
The player has around 3 different interactions for now: Walking, Running, and Item Interaction.  \
The walking is self explanitory, move with the movement keys at a set pace and stop moving once  \
the keys are no longer pressed. There is some slight acceleration and deceleration however but  \
that is to make movement look a little smoother.  \
The sprinting is slightly more complex, as the player must press the 'Sprint' key and have enough  \
stamina to do so. If the player does not have the stamina they will not sprint, however while they  \
are not sprinting the stamina will quickly regenerate.  \
For the pickup mechanic, it first checks to see what kind of item it picks up. Whether that be gold,  \
collectibles, or any other thing that could be implemented. If it's gold, then it adds the value to  \
a gold counter in the player class, otherwise it adds it to the inventory array if the spot is empty.  \
The player has a range of spells/abilites that they can use to attack the enemy, more are going to be  \
added as time goes on. For now the player character just shoots ping pong balls at the enemy.  \
The Camera follows the player and has a slight smoothing to it in order to have a better flow for movement  \
direction.
## Current Bugs/Missing Features
- The inventory cannot be open/closed and is permanently open, creating a cluttered UI  \
- When the enemy is damaged by a projectile but not within range, they do not follow the player  \
- The player currently cannot be damaged  \
- Hope to create a creature (thinking about a gnoll) that has both ranged and melee modes  \
- Random generation!

