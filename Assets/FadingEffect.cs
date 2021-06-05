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
        img.canvasRenderer.SetAlpha(0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        img.CrossFadeAlpha(0.5f, 1f, false);
    }
}
