using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] float dashCooldown = 1f;
    [SerializeField] Image energyBar;
    bool dashing = false;
    Rigidbody rb;
    float dashTimer = 0f;
    KeyCode dashKey;
    Vector3 dashDirection;
    float rechargeCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        
        
        rechargeCooldown -= Time.deltaTime;
        if (energyBar.fillAmount < 1.0f && rechargeCooldown <= 0f)
        {
            energyBar.fillAmount += 0.08f;
            rechargeCooldown = 1f;
        }
        if (energyBar.fillAmount >= 0.25f)
        {
            if (Input.GetKeyDown(KeyCode.W) )
            {
                DashDir(KeyCode.W, Vector3.forward);
                energyBar.fillAmount -= 0.25f;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                DashDir(KeyCode.S, -Vector3.forward );
                energyBar.fillAmount -= 0.25f;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                DashDir(KeyCode.D, Vector3.right );
                energyBar.fillAmount -= 0.25f;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                DashDir(KeyCode.A, -Vector3.right);
                energyBar.fillAmount -= 0.25f;
            }
        }

        dashCooldown -= Time.deltaTime;

       
    }



    private void DashDir(KeyCode key, Vector3 dir)
    {
            Vector3 target = transform.position + dir * 5f;
        //    //print("DashTarget: " + target);
            RaycastHit hit;
        if (Physics.Linecast(transform.position, target, out hit))
        {
            //float dist = Vector3.Distance(transform.position, hit.transform.position);
            //print(dist);
            if (transform.position.x > hit.transform.position.x) 
            transform.position = new Vector3(hit.transform.position.x + 0.5f, transform.position.y, transform.position.z);
            else
            {
                transform.position = new Vector3(hit.transform.position.x - 0.5f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.position = target;
        }


        //   // rb.AddForce(dir*100f, ForceMode.Impulse);
        //TryMove(dir, 5f);
    }


    bool CanMove(Vector3 dir, float dist)
    { 
        RaycastHit hit;
        Physics.Raycast(transform.position, dir,out hit, dist);
        return hit.collider == null;
    }

    private bool TryMove(Vector3 baseMoveDir, float dist)
    {
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, dist);
        if (!canMove)
        {
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0 && CanMove(moveDir, dist);
        }

        if (canMove)
        {
            transform.position += moveDir * dist;
            return true;
        }
        else
        {
            return false;
        }
    }
}
