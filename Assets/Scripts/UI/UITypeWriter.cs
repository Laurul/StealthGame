using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

// attach to UI Text component (with the full text already there)

public class UITypeWriter : MonoBehaviour
{


    //public HyperText txt;
    string story;
    [SerializeField] Button button;
    ////[SerializeField] List<LocalizableText> animationTexts;
    
    //int textIndex = -1;

    //bool ok = false;
    //int length;
    //void Awake()
    //{
      
    //    //story += animationTexts[textIndex].OutputText;
    //    txt.text = ".";
    //    length = animationTexts[0].OutputText.Length;
    //    print(this.gameObject.name + " " + length);
    //    //button.onClick.AddListener(() => StartCoroutine("PlayText"));
    //    button.onClick.AddListener(() => CheckButton());



    //}


    //IEnumerator PlayText()
    //{


    //    foreach (char c in story)
    //    {
    //        if (txt.text == ".")
    //        {
    //            txt.text = "";
    //            //txt.text += 'p';

    //            story = " ";
    //            // print(txt.text);
    //        }
    //        txt.text += c;
    //        yield return new WaitForSeconds(0.025f);

    //        print(txt.text.Length);
           
    //    }

    //}

    //public void CheckButton()
    //{
       
    //    StopAllCoroutines();


    //    if (textIndex < animationTexts.Count - 1)
    //    {
    //        textIndex++;

    //    }
    //    else
    //    {
    //        textIndex = 0;


    //    }
    //    story += animationTexts[textIndex].OutputText;

    //    StartCoroutine(PlayText());
    //    if (animationTexts.Count <= 1)
    //    {
    //        button.interactable = false;
    //    }
    //    if (ok)
    //    {
    //        txt.text = ".";
    //    }

    //    ok = true;


    //}
}
