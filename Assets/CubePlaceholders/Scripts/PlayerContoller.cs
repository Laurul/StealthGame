using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed = 10;
    Animator anim;
    Vector3 velocity;
    Rigidbody rb;
    Camera viewCam;
    Vector3 rotation;
    [SerializeField] float maxHealth = 100f;
    [SerializeField] Image healthOrb;
    [SerializeField] PlayerAttack selectAttack;
    [SerializeField] SpawnClone cloneAttack;
    [SerializeField] Animator playerAnimator;
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
        cloneAttack.index = selectAttack.index;
        //Vector3 mousePos = viewCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCam.transform.position.y));

        //print(mousePos);
        // transform.LookAt(mousePos + Vector3.up * transform.position.y);

        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * movementSpeed;

        //transform.LookAt(transform.position + new Vector3(velocity.x, 0, velocity.z));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        print(velocity.sqrMagnitude);
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
            playerAnimator.SetBool("isDead", true);
            //death animation
            //stop player movement
            //death audio clip
            Destroy(this.gameObject);
        }
    }
}
