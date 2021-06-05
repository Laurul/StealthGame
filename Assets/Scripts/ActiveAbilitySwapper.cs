using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAbilitySwapper : MonoBehaviour
{
    public List<GameObject> allAvailableActives;
    public GameObject[] currentActives;
    [SerializeField] Button template;
    [SerializeField] Button template1;
    [SerializeField] GameObject gridAll;
    [SerializeField] GameObject gridCurrent;
    List<Image> allActivesIcons;
    List<Image> currentActivesIcons;

    Button toSwap;
    Button toBeSwapped;


    List<Texture> allActivesIconsTextures;
    List<Texture> currentActivesIconsTextures;

    List<Button> allAvailableButtons;
    List<Button> currentButtons;


    [SerializeField] PlayerHudSwap s;
    // Start is called before the first frame update
    void Start()
    {

        allActivesIconsTextures = new List<Texture>();
        currentActivesIconsTextures = new List<Texture>();

        allActivesIcons = new List<Image>();
        currentActivesIcons = new List<Image>();

        allAvailableButtons = new List<Button>();
        currentButtons = new List<Button>();
       
        foreach (GameObject skill in allAvailableActives)
        {
            Image skillIcon = skill.GetComponentInChildren<Image>();
            //if(skillIcon.tag=="ActiveAbility")
            allActivesIcons.Add(skillIcon);
            allActivesIconsTextures.Add(skillIcon.mainTexture);
        }

        foreach (Image icon in allActivesIcons)
        {
            Button iconAll = Instantiate(template) as Button;
            iconAll.gameObject.SetActive(true);
            iconAll.name = icon.gameObject.name;
            iconAll.image.sprite = icon.sprite;
            iconAll.transform.SetParent(gridAll.transform);
            allAvailableButtons.Add(iconAll);
        }


        foreach (GameObject skill in currentActives)
        {
            Image skillIcon = skill.GetComponentInChildren<Image>();
            //if(skillIcon.tag=="ActiveAbility")
            currentActivesIcons.Add(skillIcon);
            currentActivesIconsTextures.Add(skillIcon.mainTexture);
        }
        foreach (Image icon in currentActivesIcons)
        {
            Button iconCurrent = Instantiate(template1) as Button;
            iconCurrent.gameObject.SetActive(true);
            iconCurrent.name = icon.gameObject.name;
            iconCurrent.image.sprite = icon.sprite;
            iconCurrent.transform.SetParent(gridCurrent.transform);
            currentButtons.Add(iconCurrent);
        }

    }

    // Update is called once per frame
    void Update()
    {

        //foreach (Image i in currentActivesIcons)
        //{
        //    print(i.sprite.name);
        //}
        //if (toSwap != null)
        //    print("To Swap is: " + toSwap.image.name);
        //if (toBeSwapped != null)
        //{
        //    print("To be Swapped is: " + toBeSwapped.image.name);
        //}

    }


    public void SwapItems()
    {
        if (toSwap != null && toBeSwapped != null)
        {
            if (currentActivesIconsTextures.Contains(toSwap.image.mainTexture))
            {
                int pos2 = currentActivesIconsTextures.IndexOf(toBeSwapped.image.mainTexture);
                int pos1 = currentActivesIconsTextures.IndexOf(toSwap.image.mainTexture);




                // s.SetAbilityPlacement(pos2, pos1);

                //s.SetAbilityPlacement(currentActives[pos2], pos1);
                //s.SetAbilityPlacement(currentActives[pos1], pos2);

                Texture aux1 = currentActivesIconsTextures[pos1];
                currentActivesIconsTextures[pos1] = currentActivesIconsTextures[pos2];
                currentActivesIconsTextures[pos2] = aux1;


                SwapIcons(currentActivesIcons, pos1, pos2);
                Sprite aux = currentButtons[pos1].image.sprite;
                currentButtons[pos1].image.sprite = currentButtons[pos2].image.sprite;
                currentButtons[pos2].image.sprite = aux;
                s.SetAbilityPlacement(pos1, pos2);


            }
            else
            {
                int pos1 = currentActivesIconsTextures.IndexOf(toBeSwapped.image.mainTexture);
                currentActivesIcons[pos1] = toSwap.image;
                currentActivesIconsTextures[pos1] = toSwap.image.mainTexture;
                currentButtons[pos1].image.sprite = toSwap.image.sprite;
                for (int i = 0; i < allActivesIconsTextures.Count; i++)
                {
                    if (allActivesIconsTextures[i] == toSwap.image.mainTexture)
                    {
                        s.SetAbilityPlacement(pos1, 3);
                    }
                }

            }

            toSwap = null;
            toBeSwapped = null;
        }


    }

    public void AssignButtonToSwap(Button b)
    {
        toSwap = b;
    }


    public void AssignButtonTobeSwapped(Button b)
    {
        toBeSwapped = b;
    }

    void SwapIcons(List<Image> list, int pos1, int pos2)
    {
        Image aux = list[pos1];
        list[pos1] = list[pos2];
        list[pos2] = aux;


    }

    public void AddToList(GameObject g)
    {
        allAvailableActives.Add(g);

        Image skillIcon = g.GetComponentInChildren<Image>();

        allActivesIcons.Add(skillIcon);
        allActivesIconsTextures.Add(skillIcon.mainTexture);


        Button iconAll = Instantiate(template) as Button;
        iconAll.gameObject.SetActive(true);
        iconAll.name = g.gameObject.name;
        iconAll.image.sprite = g.GetComponentInChildren<Image>().sprite;
        iconAll.transform.SetParent(gridAll.transform);
        allAvailableButtons.Add(iconAll);

    }
}
