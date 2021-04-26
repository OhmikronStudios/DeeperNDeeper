using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    MapRotation world;
    AudioCue audioPlayer;
    private void Start()
    {
        world = GetComponentInParent<MapRotation>();
        audioPlayer = GetComponent<AudioCue>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioPlayer != null)
                audioPlayer.PlayAudioCue();

            world.RespawnPlayer();
            // Kill Player
        }
    }
}
