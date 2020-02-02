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
public class PlayerAudio
{
    [Header("Settings")]
    public float FadeTime = 0.25f;
    private AudioSource[] loopSources;
    private Coroutine[] coroutines;
    private bool[] isStopping;
    private AudioSource oneShotSource;
    private Player player;

    private int curSource;

    [Header("AudioClips")]
    public AudioClipVolume Running;
    public AudioClipVolume SurfaceSwim;
    public AudioClipVolume DeepSwim;
    public AudioClipVolume Jumping;
    public AudioClipVolume ImpactAfterFallSky;
    public AudioClipVolume FallingFromSky;
    public AudioClipVolume Idle;
    public AudioClipVolume Climbing;
    public AudioClipVolume GetBlue;
    public AudioClipVolume GetGreen;
    public AudioClipVolume GetRed;

    public void SetSources(Player player)
    {
        this.player = player;
        loopSources = new AudioSource[2];
        coroutines = new Coroutine[2];
        isStopping = new bool[2];
        loopSources[0] = player.gameObject.AddComponent<AudioSource>();
        loopSources[1] = player.gameObject.AddComponent<AudioSource>();
        loopSources[0].loop = true;
        loopSources[1].loop = true;
        oneShotSource = player.gameObject.AddComponent<AudioSource>();
    }

    public void PlayOnce(AudioClipVolume clip)
    {
        oneShotSource.PlayOneShot(clip.clip, clip.volume);
    }



    public void PlayLoop(AudioClipVolume clip)
    {
        if (loopSources[curSource].clip != clip.clip || isStopping[curSource])
        {
            loopSources[(curSource + 1) % 2].clip = clip.clip;
            loopSources[(curSource + 1) % 2].volume = clip.volume;
            if (!isStopping[curSource])
            {
                if (coroutines[curSource] != null) player.StopCoroutine(coroutines[curSource]);
                coroutines[curSource] = player.StartCoroutine(FadeOut(curSource));
            }
            if (coroutines[(curSource + 1) % 2] != null) player.StopCoroutine(coroutines[(curSource + 1) % 2]);
            coroutines[(curSource + 1) % 2] = player.StartCoroutine(FadeIn((curSource + 1) % 2));
            loopSources[(curSource + 1) % 2].Play();
            curSource = (curSource + 1) % 2;
        }
    }

    public void StopLoop()
    {
        coroutines[curSource] = player.StartCoroutine(FadeOut(curSource));
        isStopping[curSource] = true;
    }

    IEnumerator FadeOut(int i)
    {
        float startVol = loopSources[i].volume;
        float t = 0;
        while (t < FadeTime)
        {
            loopSources[i].volume = Mathf.Lerp(startVol, 0, t / FadeTime);
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
        }
    }
    IEnumerator FadeIn(int i)
    {
        float endVol = loopSources[i].volume;
        float t = 0;
        while (t < FadeTime)
        {
            loopSources[i].volume = Mathf.Lerp(0, endVol, t / FadeTime);
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
        }
    }
}