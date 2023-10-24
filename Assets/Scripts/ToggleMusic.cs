using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    [SerializeField]
    private bool toggleMusic;

    public void  Toggle()
    {
        if(toggleMusic)
        {
            SoundManager.Instance.ToggleMusic();
        }
    }
}
