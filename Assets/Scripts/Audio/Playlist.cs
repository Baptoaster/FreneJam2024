using UnityEngine;

[System.Serializable]
public class Playlist
{
    public AudioClip clip;
    [Range(0, 1)] public float volume;
}