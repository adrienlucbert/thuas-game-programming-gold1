# State Machine

This is the first gold achievements for the Game Programming class in THUAS'
Game Development & Simulation minor.

## Instructions

Implement a state machine without using existing solutions for it.

### Requirements:

- the player should be able to control an object and change its state
- the controls should always be visible on screen
- the controllable object must be a prefab
- implement at least 4 different states that can be uniquely identified
- at least one state must be reliant on another state and can only be entered
when that other state is active
- implement a follow camera so that the object is always in-frame
- make movements framerate-independent

### Submission requirements

- submit a state diagram depicting the different states for the object
- submit a text document containing a description of each state

## Result

<div align="center">
  <img src="./resources/demo.gif" alt="project demo"/>
  <p><i>Project demo</i></p>
</div>

The player has 5 states:

- **Idle**: the player is idle
- **Moving**: the player moves at constant speed on the X and Z axes
- **Jumping**: the player jumps
- **Hovering**: the player is hovering in the air, performing a repetitive up and
down movement, while rotating on itself
- **Resetting**: when the player goes out of the scene bounds, it gets
progressively repositioned to its starting position

The player states and their transitions are further described in the following states
diagram:

<div align="center">
  <img src="./resources/player-states-diagram.svg" alt="player states diagram"/>
  <p><i>Player states diagram</i></p>
</div>

### Camera behaviour

When the player is hovering, the camera is fixed. When hovering stops, the
offset between the camera position and the player position may be different from
the original offset.  
To solve this, the camera has 3 states:

- **Follow**: the camera follows the player, with a constant offset
- **Fixed**: the camera is fixed, it doesn't move with the player
- **CatchUp**: the camera progressively moves to reach it's original offset

<div align="center">
  <img src="./resources/camera-states-diagram.svg" alt="camera states diagram"/>
  <p><i>Camera states diagram</i></p>
</div>

## Credits

This project is the work of [Adrien Lucbert](https://github.com/adrienlucbert),
and the Game Programming class was given by Mathijs Koning.
