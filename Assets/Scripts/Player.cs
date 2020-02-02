using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartAction
{
    FallSky,
    Idle
}

public class Player : MonoBehaviour
{
    public StartAction startAction = StartAction.Idle;
    public float jumpSpeed, fallMultiplier, jumpMultiplier, highJumpMultiplier;

    public float SkyFallVelocity = 8;
    public float climbSpeed = 0.05f;
    public float SpringForce = 1f;

    public float swimSpeed = 1.5f;
    public bool adaptCollider = true;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AudioSource musicManager;
    public PlayerAction action;
    public Scenery scenery;
    public float RunVelocity = 4.0f;
    public float maxSpeed = 10.0f;

    public float minBreathInterval = 4.0f, maxBreathInterval = 10.0f;

    public AudioClip emptyTheme, blueTheme, greenTheme, redTheme;

    public bool CanClimb;

    public PlayerAudio sound;

    public SpriteRenderer eyes;

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Climbable"))
            CanClimb = true;
        action.OnTriggerEnter(col);
    }
    public virtual void OnTriggerStay2D(Collider2D col)
    {
        action.OnTriggerStay(col);
    }
    public virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Climbable"))
            CanClimb = false;
        action.OnTriggerExit(col);
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        action.OnCollisionEnter(col);
    }
    public virtual void OnCollisionStay2D(Collision2D col)
    {
        action.OnCollisionStay(col);
    }
    public virtual void OnCollisionExit2D(Collision2D col)
    {
        action.OnCollisionExit(col);
    }

    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.Find("Music").GetComponent<AudioSource>();
        sound.SetSources(this);
        switch (startAction)
        {
            case StartAction.Idle:
                action = new Idle(this);
                break;
            case StartAction.FallSky:
                action = new FallSky(this);
                break;
        }
        eyes = transform.Find("Eyes").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(action.GetType());
        if (adaptCollider)
        {
            Vector2 S = spriteRenderer.bounds.size;
            GetComponent<BoxCollider2D>().size = S;
            GetComponent<BoxCollider2D>().offset = spriteRenderer.bounds.min + spriteRenderer.bounds.extents - transform.position;
        }
        action.DoAction();

        eyes.enabled = action.GetType() == typeof(Idle);
        var eyesScale = eyes.transform.localScale;
        eyesScale.x = Mathf.Abs(eyesScale.x) * (spriteRenderer.flipX ? -1 : 1);
        eyes.transform.localScale = eyesScale;
        var eyesPos = eyes.transform.localPosition;
        eyesPos.x = Mathf.Abs(eyesPos.x) * (spriteRenderer.flipX ? -1 : 1);
        eyes.transform.localPosition = eyesPos;
    }

    public bool isGrounded()
    {
        string[] ignoreLayers = { "Water", "Player", "Climbable" };
        var bounds = this.GetComponent<SpriteRenderer>().bounds;
        var collider = Physics2D.BoxCast(
            new Vector2(bounds.min.x + bounds.extents.x, bounds.min.y),
            new Vector2(bounds.extents.x, 0.001f),
            0,
            Vector2.down,
            0.1f,
            ~LayerMask.GetMask(ignoreLayers)
            ).collider;
        bool hit = false;
        if (collider != null)
        {
            hit = true;
            for (int i = 0; hit && i < ignoreLayers.Length; i++)
            {
                hit = hit && LayerMask.LayerToName(collider.gameObject.layer) != ignoreLayers[i];
            }
        }
        return hit;
    }

    public void enableScenery(String name)
    {
        scenery.enableSprite(name);
    }

    public void GoToIdle()
    {
        action = new Idle(this);
    }

    public void DrinkAnimation(GameObject fountain)
    {

        StartCoroutine(DrinkWater(fountain));
    }

    IEnumerator DrinkWater(GameObject fountain)
    {
        this.animator.SetTrigger("Fountain");
        //PILINHAS:)
        yield return new WaitForSeconds(1.5f);
        GameObject.Destroy(fountain);
        this.scenery.enableWater();
    }

    void PlayBlue()
    {
        musicManager.clip = blueTheme;
        musicManager.Play();
        sound.PlayOnce(sound.GetBlue);
    }

    void PlayGreen()
    {
        musicManager.clip = greenTheme;
        musicManager.Play();
        sound.PlayOnce(sound.GetGreen);
    }

    void PlayRed()
    {
        musicManager.clip = redTheme;
        musicManager.Play();
        sound.PlayOnce(sound.GetRed);
    }

}
