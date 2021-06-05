using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;


public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed = 10;
    Animator anim;
    Vector3 velocity;
    Rigidbody rb;
    Camera viewCam;
    Vector3 rotation;
    public float maxHealth = 100f;
    public float maxEnergy = 100f;
    [SerializeField] Image healthOrb;
    [SerializeField] PlayerAttack selectAttack;
    [SerializeField] SpawnClone cloneAttack;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Image energyBar;
    [SerializeField] GameObject attackUI;
    [SerializeField] FollowTarget cameraFollow;


    PlayerVent pv;
    [HideInInspector] public float currentHealth = 0f;
    [HideInInspector] public float currentEnergy = 0f;
    [HideInInspector] public int defense = 0;
    [SerializeField] float rechargeCooldown = 0.5f;
    void Start()
    {
        pv = GetComponent<PlayerVent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        viewCam = Camera.main;
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 1)
        {
            cameraFollow.offset = new Vector3(0, 7.5f, 0);
        }
        if (attackUI.activeSelf)
        {
           // GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnClone>().enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().enabled = true;
        }
        else
        {
           // GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnClone>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().enabled = false;
        }
        //cloneAttack.index = selectAttack.index;




        //Vector3 mousePos = viewCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCam.transform.position.y));

        //print(mousePos);
        // transform.LookAt(mousePos + Vector3.up * transform.position.y);

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * movementSpeed;

        rechargeCooldown -= Time.deltaTime;
        if (pv.GetVentStatus() && rechargeCooldown <= 0f && energyBar.fillAmount >= 0.08f)
        {
            rechargeCooldown = 1f;
            energyBar.fillAmount -= 0.08f;
        }
        if (pv.GetVentStatus() && rechargeCooldown <= 0f && energyBar.fillAmount <= 0.08f)
        {
            rechargeCooldown = 1f;
            ReceiveDamage(5f);
        }
        if (currentEnergy<maxEnergy&& rechargeCooldown <= 0f&&currentEnergy<=100f)
        {
            currentEnergy += 3f;
            energyBar.fillAmount = currentEnergy / maxEnergy;
            rechargeCooldown = 1f;
        }else if (currentEnergy < maxEnergy && rechargeCooldown <= 0f && currentEnergy > 100f)
        {
            currentEnergy += 3f;
            rechargeCooldown = 1f;
        }
        else if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
            rechargeCooldown = 1f;
        }
        //transform.LookAt(transform.position + new Vector3(velocity.x, 0, velocity.z));

        //if (pv.GetVentStatus())
        //{
        //    cloneAttack.enabled = false;

        //}
        //else
        //{
        //    cloneAttack.enabled = true;

        //}
    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (velocity.sqrMagnitude != 0)
        {
            playerAnimator.SetBool("IsWalking", true);
            Quaternion forwardRotation = Quaternion.LookRotation(velocity);
            rb.MoveRotation(forwardRotation);

        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }


    }



    public float ReturnMaxHealth()
    {
        return maxHealth;
    }

    public float ReturnCurrentHealth()
    {
        return currentHealth;
    }

    public void ReceiveDamage(float value)
    {
        if (currentHealth > 100)
        {
            if (defense < value)
            {
                currentHealth -= value - defense;
            }
            
        }
        else if (currentHealth > 0)
        {
            if (defense < value)
            {
                currentHealth -= value - defense;
                if (healthOrb != null)
                {
                    healthOrb.fillAmount = currentHealth / maxHealth;
                }
            }
          
        }
        else if (currentHealth <= 0)
        {
            playerAnimator.SetBool("isDead", true);
            //death animation
            //stop player movement
            //death audio clip
            //Destroy(this.gameObject);
        }
    }

    public float ReturnVelocity()
    {
        return velocity.sqrMagnitude;
    }
}
