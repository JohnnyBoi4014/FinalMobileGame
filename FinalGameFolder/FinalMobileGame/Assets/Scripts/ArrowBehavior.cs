using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowBehavior : MonoBehaviour
{
    public GameObject tooLateCube;
    public CameraTargetScript targetPlayer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == tooLateCube)
        {
            targetPlayer.takeDamage(5);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == tooLateCube)
        {
            targetPlayer.takeDamage(5);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [Tooltip("Explosion effect")]
    public GameObject explosion;

    private void PlayerTouch()
    {
        if (explosion != null)
        {
            var particles = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(particles, 1.0f);
        }

        targetPlayer.heal(10);

        Destroy(this.gameObject);
    }
}
