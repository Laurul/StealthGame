using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeColor : MonoBehaviour
{
    Image i;
    Color spriteTransparent;
    
    // Start is called before the first frame update
    void Start()
    {
        i = GetComponent<Image>();
        spriteTransparent = i.color;
        spriteTransparent.a = 0;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        i.color = spriteTransparent;
       

    }
    
   public void IncreaseFade(float value)
    {
        if(spriteTransparent.a>0.0f)
        spriteTransparent.a -= value;
    }

   public void IncreaseOpacity(float value)
    {
        if (spriteTransparent.a <1.0f)
            spriteTransparent.a += value;
    }

    public float GetAlphaValue()
    {
        return i.color.a;
    }
}
