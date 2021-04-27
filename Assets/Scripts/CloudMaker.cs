using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMaker : MonoBehaviour
{
    public float minSize;
    public float maxSize;
    public float yMult;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        float sizeRandom = Random.Range(minSize, maxSize);
        Vector3 randSize = new Vector3(sizeRandom, sizeRandom * yMult, sizeRandom);
        transform.localScale = randSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
