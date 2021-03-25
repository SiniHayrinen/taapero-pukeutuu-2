using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public bool ActivateOnAwake = true;
    public AudioClip[] MusicList;
    
    void Awake()
    {
        MusicManager.Instance.ChangePlaylist(this);
    }


}
