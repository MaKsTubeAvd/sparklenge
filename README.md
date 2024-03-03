# sparklenge
Sparkle Visual Novel Engine This is a new solution for creating your own visual stories 
It allows you to write your own visual novels based on the Unity game engine. 
Functions:
- Use backgrounds, sprites and videos for your story
- Rewind and rewind events
- Saving and loading history in json

All backgrounds, sprites, etc. should be stored in the Resources folder in the appropriate folders.
The script must be in the format.txt.
dialogue_ Character name | Phrase is a line
of audio play dialog: song name is to reproduce an audio file
audio stop - Stop playback
video play: video title - Play video
sprite: file name location(left,center,right) - Show sprite
spritehide: file name location - Hide sprite
label - name - Create label
jump: Label name - Go to label
choice: Text - action, Text - action... - - Selection (no more than 7 mi)
return - Finish the game, return to the main menu
Write everything without unnecessary spaces, and do not leave unnecessary lines
Example:
label-start
dialog_ Maxim | Yes
return
