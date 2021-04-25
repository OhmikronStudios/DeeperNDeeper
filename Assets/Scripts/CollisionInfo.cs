using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfo : MonoBehaviour
{
    [System.Serializable]
    public class CollisionData
    {
        public Material mat;
        public AudioCueSO audioCueSO;
    }

    [SerializeField] CollisionData[] ImpactSounds;

    private Dictionary<Material, CollisionData> CollisionMap;
    private AudioCue audioCue;

    private void Start()
    {
        audioCue = GetComponent<AudioCue>();
        CollisionMap = new Dictionary<Material, CollisionData>();

        foreach (CollisionData data in ImpactSounds)
        {
            if (data.mat = null) continue;

            CollisionMap.Add(data.mat, data);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
        {
            if (CollisionMap.TryGetValue(renderer.sharedMaterial, out CollisionData data))
            {
                audioCue.PlayAudioCue(data.audioCueSO);
            }
        }
    }
}
