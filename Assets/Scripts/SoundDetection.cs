using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetection : MonoBehaviour
{
    // Start is called before the first frame update
    bool fastAlert = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
             GetComponent<EnemyManager>().alert = true;
            fastAlert = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
             GameManager.Instance.alert = false;
            fastAlert = false;
    }

    public bool GetAlertstatus()
    {
        return fastAlert;
    }
}
