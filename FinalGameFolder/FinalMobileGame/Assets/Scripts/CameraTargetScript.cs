using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetScript : MonoBehaviour
{
    
    private Rigidbody rb;

    [Range(0, 10)]
    public float rollSpeed = 5;

    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Health
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        healthBar.setHealth(currentHealth);
        //Health
    }

    // Update is called once per frame
    void Update()
    {
        //Health
        if (Input.GetKeyDown(KeyCode.D))
        {
            takeDamage(5);
            healthBar.setHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            takeDamage(10);
            healthBar.setHealth(currentHealth);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            heal(20);
            healthBar.setHealth(currentHealth);
        }
        //Health

        /*
        //Mobile Touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            TouchObjects(touch.position);
        }
        //Mobile Touch

        //Computer Click
        if (Input.GetMouseButton(0))
        {
            Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
            TouchObjects(screenPos);
        }
        //Computer Click
        */

        //TEST TOUCH
        if (Input.GetMouseButton(0))
        {
            Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                TouchObjects(screenPos, touch);
            }
            else
            {
                TouchObjects(screenPos);
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            TouchObjects(touch.position);
        }
        //TEST TOUCH

    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, rollSpeed);
    }


    // (HealthStuff)

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public void takeDamage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }

        gameManager.DecreaseScore();
        healthBar.setHealth(currentHealth);
    }

    public void heal(int heal)
    {
        if (currentHealth + heal >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += heal;
        }

        gameManager.IncreaseScore();
        healthBar.setHealth(currentHealth);
    }


    /*
    //touch commands test

    private static void TouchObjects(Vector2 screenpos)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(screenpos);
        RaycastHit hit;

        int layerMask = ~0;

        if(Physics.Raycast(touchRay, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            //Destroy(hit.transform.gameObject);
            hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
        }
    }

    void TouchObjects(Touch touch)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;

        int layerMask = ~0;

        if (Physics.Raycast(touchRay, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
        }
    }
    */

    private static void TouchObjects(Vector2 screenPos)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        int layerMask = ~0;

        if (Physics.Raycast(touchRay, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (Input.touchCount == 0)
            {
                hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    private static void TouchObjects(Vector2 screenPos, Touch touch)
    {
        Ray touchRay = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        int layerMask = ~0;

        if (Physics.Raycast(touchRay, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (touch.phase == TouchPhase.Began)
            {
                hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    private static void TouchObjects(Touch touch)
    {

        if (Input.touchCount == 1)
        {
            Ray touchRay = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            int layerMask = ~0;

            if (Physics.Raycast(touchRay, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
                }

                hit.transform.SendMessage("PlayerTouch", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
