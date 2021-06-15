using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadingEffect : MonoBehaviour
{
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        img.color = new Color(1, 1, 1, Mathf.PingPong(Time.time, 1.8f) / 1.8f);
    }
}
