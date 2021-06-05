using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon:MonoBehaviour
{

    public virtual void DisplayWeapon() { }
    public virtual void Shoot() { }

   public  Transform FindChild(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child;
            }
            else
            {
                Transform found = FindChild(child, childName);
                if (found != null)
                {
                    return found;
                }
            }
        }
        return null;
    }


}
