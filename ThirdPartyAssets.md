# Third party assets used for this Assignment

- [Low Poly Shooter Pack - Free Sample](https://assetstore.unity.com/packages/templates/systems/low-poly-shooter-pack-free-sample-144839)
- [Guns Pack: Low Poly Guns Collection](https://assetstore.unity.com/packages/3d/props/guns/guns-pack-low-poly-guns-collection-192553)
- [Dark Future Cyberpunk Soundtrack](https://assetstore.unity.com/packages/audio/ambient/dark-future-cyberpunk-soundtrack-126026#content)

**Low Poly Shooter Pack - Free Sample** contained several scripts for core functionality. I put them into [**/Scripts/fromAssets**](/src/Assets/Scripts/fromAssets/) to keep these scripts separate. All scripts in [**/Scripts**](/src/Assets/Scripts/) are written by me to make a playable game. Only [**AudioManagerService.cs**](/src/Assets/Scripts/AudioManagerService.cs) was originally from an asset pack but rewritten by me. I had to add a null-check to prevent a `MissingReferenceException` error that occurred when changing scenes, because the script tried to access an `AudioSource` that had already been destroyed during the scene transition.