using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;

//AUTHOR : Alexandre GAUTIER

public class BackgroundMusic : MonoBehaviour
{
    
    public AudioClip[] backgroundMusicList;
    public AudioSource source;
    private int PreviousMusicInt = -1;
    private float newClip;
    private float timer;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.volume = 0.09f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > newClip + 1)
        {
            PlayBackgroundMusic();
            timer = 0;
        }
    }

    public void PlayBackgroundMusic()
    {
        int rand = Random.Range(0, backgroundMusicList.Length);
        
        if (PreviousMusicInt == rand)
        {
            while (PreviousMusicInt == rand)
            {
                rand = Random.Range(0, backgroundMusicList.Length);
            }
        }
        PreviousMusicInt = rand;

        if (!source.isPlaying)
        {
            source.loop = true;
            source.PlayOneShot(backgroundMusicList[rand]);
        }

        newClip = backgroundMusicList[rand].length;
    }
}
