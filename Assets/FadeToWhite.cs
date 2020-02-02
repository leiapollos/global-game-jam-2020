using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToWhite : MonoBehaviour
{
    public SpriteRenderer spr;
    public float FadeTime = 5f;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        float t = 0;
        while (t < FadeTime)
        {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
            Color c = spr.color;
            c.a = EasingFunction.EaseInOutCubic(0, 1, t / FadeTime);
            spr.color = c;
        }
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("StartMenu");
    }
}
