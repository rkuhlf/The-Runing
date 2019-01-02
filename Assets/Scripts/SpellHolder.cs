using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellHolder : MonoBehaviour {

    public GameObject[] spells;
    private float spellWidth;

    public float gap = 10f;

    public int selectedIndex = 0;

    private void Start()
    {
        spellWidth = (spells[0].GetComponent(typeof(RectTransform)) as RectTransform).sizeDelta.y;
        RectTransform rt = GetComponent(typeof(RectTransform)) as RectTransform;

        int index = 0;
        for (float i = (float) -spells.Length / 2; i < (float) spells.Length / 2; i++)
        {
            Transform newCard = Instantiate(spells[(int) (i + (float) spells.Length / 2)], new Vector2(0, 0), Quaternion.identity).transform;
            newCard.parent = transform;
            newCard.localPosition = new Vector2((i + 0.5f) * (spellWidth + gap), 0);
            newCard.localScale = Vector3.one;
        }
    }

    public string GetSelectedSpell()
    {
        if (selectedIndex != 0)
        {
            Transform child = transform.GetChild(selectedIndex - 1);
            if (child.GetComponent<Button>().interactable)
                return child.GetComponent<ButtonFunctions>().spell;
        }
        return null;
    }

    public void UseSelectedSpell()
    {
        if (selectedIndex != 0)
            transform.GetChild(selectedIndex - 1).GetComponent<SpellButton>().Use();
    }

    public bool SpellsLeft()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Button>().interactable)
                return true;
        }

        return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Select(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Select(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Select(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Select(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Select(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Select(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Select(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Select(8);
        }
    }

    private void Select(int index)
    {
        if (transform.childCount > index) {
            Transform card = transform.GetChild(index);
            card.GetComponent<ButtonFunctions>().Select();
        }
    }
}
