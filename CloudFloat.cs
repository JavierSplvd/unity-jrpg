using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFloat : MonoBehaviour
{

    [SerializeField] private float amplitude, freq;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = amplitude * Mathf.Sin(freq * Time.time);
        transform.position = pos + originalPos;
    }
}
