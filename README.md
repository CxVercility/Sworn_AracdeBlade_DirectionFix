Low effort MelonLoader Mod (see https://melonwiki.xyz)

Moves the projectile trajectory slightly downwards so the hitbox îs closer to your actual cursor position

Some more Context on this since ive been playing around with it a lot lately:
This seems to be a visual issue only. The hitbox actually correctly correlates with cursor position, its just that the visual angle that is displayed to the user is *massively* off

This is because for some reason, the projectiles have an initial height offset that is insanely high, which makes it look angled due to the diagonal camera perspective
-> im pretty certain that this was done as a dirty quick fix due to the fact that removing this offset actually makes the projectile stuck in the ground, which just becomes worse when you realize that the different maps actually have different heights for some reason?

From what limit knowledge i have, i suppose a better solution would be to just increase the projectiles hitbox (in height) or decouple it's visuals from its actual hitbox

Adding on top of that direction is derived from the cursor's position assuming that it's pointing directly at the ground. This assumes players would always target an enemys feet which is not the case.

Added Fun Fact: Activating Lock on pretty much solves this issue for some reason.
