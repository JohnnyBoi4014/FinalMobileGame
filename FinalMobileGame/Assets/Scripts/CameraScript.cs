using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3 (0, 12, -3);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt (target);
        }
    }
}
