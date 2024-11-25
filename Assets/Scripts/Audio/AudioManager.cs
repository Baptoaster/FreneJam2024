using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Playlist[] playlists;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < playlists.Length; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.clip = playlists[i].clip;
            audioSource.volume = playlists[i].volume;
            audioSource.loop = true;

            audioSource.Play();
        }
    }

    public void PlayClipAt(Playlist playlist)
    {
        AudioSource audioSource = new GameObject("TmpAudio").AddComponent<AudioSource>();

        audioSource.clip = playlist.clip;
        audioSource.volume = playlist.volume;
        audioSource.Play();

        Destroy(audioSource.gameObject, playlist.clip.length);
    }
}