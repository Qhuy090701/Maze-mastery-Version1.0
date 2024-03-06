using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public enum SoundName {
  BackGroundMusic,
  SfxMove,
  SfxJump,
  SfxDie,
  SfxWinGame,
  SfxLoseGame,
  SfxBrokenBrick
}

[Serializable]
public class Sound {
  public SoundName name;
  public AudioClip clip;
}
