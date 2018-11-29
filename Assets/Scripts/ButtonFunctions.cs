using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

    public string spell = "fireball";

    private int index;

    private void Start()
    {
        index = GetIndex();
    }

    public void Select()
    {
        print("Selected");
        transform.parent.GetComponent<SpellHolder>().selectedIndex = index;
    }

    private int GetIndex()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.parent.GetChild(i) == transform)
            {
                index = i;
            }
        }

        return index + 1;
    }

    public void Use()
    {
        GetComponent<Button>().interactable = false;
    }
}
