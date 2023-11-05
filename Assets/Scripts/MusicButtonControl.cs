using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public MusicPlayer musicPlayer; // Arrastra el objeto MusicPlayer a este campo en el Inspector
    public Slider volumeSlider; // Agrega un Slider en el Inspector para ajustar el volumen

    public void ToggleMute()
    {
        musicPlayer.ToggleMute();
    }

    public void SetVolume()
    {
        musicPlayer.AdjustVolume(volumeSlider.value);
    }
}
