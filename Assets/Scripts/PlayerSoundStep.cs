using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundStep : MonoBehaviour
{
    [SerializeField] GameObject stepSphere;
    PlayerContoller playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.ReturnVelocity() > 0)
        {
            stepSphere.transform.localScale = new Vector3(3, 1, 3);
        }
        else
        {
            stepSphere.transform.localScale = new Vector3(0,1,0);
        }
    }
}
