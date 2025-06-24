using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDetectorScript : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, -0.49f, -5.25f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
