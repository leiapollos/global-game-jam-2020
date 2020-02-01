using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float XOffset = 2.5f;
    public float FollowAmount = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(player.transform.position.x + XOffset, player.transform.position.y, transform.position.z), FollowAmount * Time.deltaTime);
    }
}
