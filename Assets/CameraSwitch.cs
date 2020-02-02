using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public static Coroutine currentCoroutine;
    public float TargetSize = 8;
    public float ZoomTime = 1;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (CameraSwitch.currentCoroutine != null)
            {
                StopCoroutine(CameraSwitch.currentCoroutine);
            }
            CameraSwitch.currentCoroutine = StartCoroutine(Zoom());
        }
    }

    IEnumerator Zoom()
    {
        float startZoom = Camera.main.orthographicSize;
        float t = 0;
        while (t < ZoomTime)
        {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime;
            Camera.main.orthographicSize = EasingFunction.EaseOutCirc(startZoom, TargetSize, t / ZoomTime);
        }
    }
}
