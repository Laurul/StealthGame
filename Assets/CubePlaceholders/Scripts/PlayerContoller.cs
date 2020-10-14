using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed=10;
    Animator anim;
    Vector3 velocity;
    Rigidbody rb;
    Camera viewCam;

    [SerializeField] float maxHealth = 100f;
    [SerializeField] Image healthOrb;
    private float currentHealth = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        viewCam = Camera.main;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      
        Vector3 mousePos = viewCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCam.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
       
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * movementSpeed;
       
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public float ReturnMaxHealth()
    {
        return maxHealth;
    }

    public float ReturnCurrentHealth()
    {
        return currentHealth;
    }

    public void  ReceiveDamage(float value)
    {
        if (currentHealth > 0)
        {
            currentHealth -= value;
            if (healthOrb != null)
            {
                healthOrb.fillAmount = currentHealth / maxHealth;
            }
        }
        else
        {
            //death animation
            //stop player movement
            //death audio clip
            Destroy(this.gameObject);
        }
    }
}
