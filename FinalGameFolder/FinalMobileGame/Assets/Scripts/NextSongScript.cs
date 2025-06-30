using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSongScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "CameraTarget")
        {
            //other.gameObject.transform.position = new Vector3(0, 1, 0);

            StartCoroutine(waitNextScene(other.gameObject));
        }
    }

    IEnumerator waitTP(GameObject obj)
    {
        obj.transform.position = new Vector3(0, 1, 0);
        obj.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        obj.SetActive(true);
    }

    IEnumerator waitNextScene(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(3);
    }
}
