using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public AudioSource shotAudio;

    private void OnMouseDown()
    {
        shotAudio.Play();
        Settings.Score -= 2;
    }
}
