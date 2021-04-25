using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    MapRotation world;

    private void Start()
    {
        world = GetComponentInParent<MapRotation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            world.RespawnPlayer();
            // Kill Player
        }
    }
}
