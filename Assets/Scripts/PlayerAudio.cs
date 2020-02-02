using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioClipVolume
{
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public struct PlayerAudio
{
    private AudioSource loopSource;
    private AudioSource oneShotSource;

    public AudioClipVolume Running;
    public AudioClipVolume SurfaceSwim;
    public AudioClipVolume DeepSwim;
    public AudioClipVolume Jumping;
    public AudioClipVolume ImpactAfterFallSky;
    public AudioClipVolume FallingFromSky;
    public AudioClipVolume Idle;
    public AudioClipVolume Climbing;

    public void SetSources(Player player)
    {
        loopSource = player.gameObject.AddComponent<AudioSource>();
        loopSource.loop = true;
        oneShotSource = player.gameObject.AddComponent<AudioSource>();
    }

    public void PlayOnce(AudioClipVolume clip)
    {
        oneShotSource.PlayOneShot(clip.clip, clip.volume);
    }

    public void PlayLoop(AudioClipVolume clip)
    {
        if (loopSource.clip != clip.clip)
        {
            loopSource.clip = clip.clip;
            loopSource.volume = clip.volume;
            loopSource.Play();
        }
    }

    public void StopLoop()
    {
        loopSource.Stop();
        loopSource.clip = null;
    }
}