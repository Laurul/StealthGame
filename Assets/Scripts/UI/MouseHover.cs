using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
{
    [SerializeField] Image imageInvert;
    [SerializeField] Color OnHoverImage;

    [SerializeField] TextMeshProUGUI textInvert;
    [SerializeField] Color OnHoverText;
    Color imageColor;
    Color textColor;

    private void Start()
    {
        imageColor = imageInvert.color;
        textColor = textInvert.color;
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
      
        imageInvert.color = OnHoverImage;
        textInvert.color = OnHoverText;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        imageInvert.color = imageColor;
        textInvert.color = textColor;
    }

}
