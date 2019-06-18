using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private PlayerControl player;
    private Vector3 pos;

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        pos = transform.position;
    }

    private void Update()
    {
        pos.y = player.transform.position.y;
        transform.position = pos;
    }
}
