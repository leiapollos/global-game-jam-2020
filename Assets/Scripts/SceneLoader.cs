using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioClip playSound;
    public AudioClip creditsSound;
    public AudioClip helpSound;
    public float soundVolume;

    //private float waitTime = 0.0f;
    public void LoadPlayScene(int index)
    {
        StartCoroutine(LoadSceneAndPlaySound(index));
    }

    IEnumerator LoadSceneAndPlaySound(int index)
    {
        AudioSource.PlayClipAtPoint(playSound, Camera.main.transform.position, 0.5f);
        yield return new WaitForSeconds(1.855f);
        SceneManager.LoadScene(index);

    }

    public void LoadHelpScene(int index)
    {
        StartCoroutine(LoadSceneAndHelpSound(index));
    }

    IEnumerator LoadSceneAndHelpSound(int index)
    {
        AudioSource.PlayClipAtPoint(helpSound, Camera.main.transform.position, 0.5f);
        yield return new WaitForSeconds(1.855f);
        SceneManager.LoadScene(index);

    }

    public void LoadCreditsScene(int index)
    {
        StartCoroutine(LoadSceneAndCreditsSound(index));
    }

    IEnumerator LoadSceneAndCreditsSound(int index)
    {
        AudioSource.PlayClipAtPoint(creditsSound, Camera.main.transform.position, 0.5f);
        yield return new WaitForSeconds(1.855f);
        SceneManager.LoadScene(index);

    }

}
