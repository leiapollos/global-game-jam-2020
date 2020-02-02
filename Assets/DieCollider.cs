﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieCollider : MonoBehaviour
{
    public float WaitTime = 3f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            var sound = col.GetComponent<Player>().sound;
            col.GetComponent<SpriteRenderer>().color = Color.red;
            sound.PlayOnce(sound.Die);
            StartCoroutine(WaitAndRestart());
        }
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene("InitialLevelProto");
    }
}
