using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlighted : MonoBehaviour
{
    public GameObject colorHiglighted;
    public AudioClip soundHiglighted;

    // Start is called before the first frame update
    void Start()
    {
        colorHiglighted.SetActive(false);
    }

    private void OnMouseEnter()
    {
        AudioSource.PlayClipAtPoint(soundHiglighted, Camera.main.transform.position, 0.5f);
        colorHiglighted.SetActive(true);
    }

    private void OnMouseExit()
    {
        colorHiglighted.SetActive(false);
    }
}
