using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public void Start() {
        AudioManager.Ins.PlayMusic(SoundName.BackGroundMusic);
    }
}
