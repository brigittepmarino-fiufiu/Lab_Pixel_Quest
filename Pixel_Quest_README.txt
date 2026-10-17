PIXEL QUEST - HOW IT WORKS
==========================

CONTROLS
--------
Move left / right : A and D   (or the Left / Right arrow keys)
Jump              : Space
Change color      : 1 = red, 2 = green, 3 = blue
Die on spikes     : you restart the same level
Bounce pad        : throws you up into the air
Green goal block  : loads the next level

LEVELS  (this is the order in Build Settings)
---------------------------------------------
1. Assets/Geo_Quest/Scenes/Geo_Quest_Scene_1.unity
2. Assets/Geo_Quest/Scenes/Geo_Quest_Scene_1 2.unity
3. Assets/Geo_Quest/Scenes/Geo_Quest_Scene_1 3.unity

HOW TO RUN IT
-------------
1. Open Unity.
2. Open the scene: Assets > Geo_Quest > Scenes > Geo_Quest_Scene_1
3. Press the Play button.
4. Walk right, jump over the spikes, and touch the green goal block.

WHAT IS IN EACH LEVEL
---------------------
* Player          - the square with the GeoController script (moves, jumps, color).
* Spikes          - the triangles. They have the tag "Death".
* Goal            - the green block on the right. It has the tag "Goal".
* Bounce Pad      - the orange block. It has the tag "Bounce".
* Conveyor Belt   - (level 1 only) a Surface Effector that pushes you along.
* Floor/Platforms - the yellow/purple squares (solid, you stand on them).

SCRIPTS
-------
Assets/Geo_Quest/Scripts/GeoController.cs   <- everything the player does

NOTES
-----
* The old duplicate square called "Square (2)" had a copy of the player
  script on it, which made two players. Its script and physics body were
  removed so there is only one player now.
* Color values in code go from 0 to 1 (0 = none, 1 = full).
