using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public Texture2D map;
    public ColorTOPrefab[] colorMappings;
    int nr = 0;
   
    void Start()
    {
        BuildLevel();
    }

    void BuildLevel()
    {
        for (int i=0; i < map.width; i++)
        {
            for (int j = 0; j < map.height; j++)
            {
                CreateTile(i, j);
            }
        }
    }

    void CreateTile(int i, int j)
    {
      Color pixColor=  map.GetPixel(i, j);
       
        if (pixColor.a == 0)
        {
           
            return;
        }
        if (pixColor.a == 0)
        {
            return;
        }
        else
        {
            print(ColorUtility.ToHtmlStringRGBA(pixColor));
        }
       
        foreach (ColorTOPrefab colorMapping in colorMappings)
        {


            //if (colorMapping.color == pixColor)
            //{
            //    // print("color mapping has values: " + colorMapping.color + " while pixel has color: " + pixColor);
            //    Vector3 position = new Vector3(i, colorMapping.prefab.transform.position.y, j)+colorMapping.offset;
            //    Instantiate(colorMapping.prefab, position, Quaternion.identity);
            //}
        }
    }
}
