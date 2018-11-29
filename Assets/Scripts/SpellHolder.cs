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
        rt.sizeDelta = new Vector2(spells.Length * (spellWidth) + gap * (spells.Length + 1), spellWidth + 2 * gap);
        rt.localPosition = new Vector2(0, 100 + spellWidth);

        for (float i = -spells.Length / 2; i < spells.Length / 2; i++)
        {
            Transform newCard = Instantiate(spells[(int) (i + spells.Length / 2)], new Vector2(0, 0), Quaternion.identity).transform;
            newCard.parent = transform;
            newCard.localPosition = new Vector2((i + 0.5f) * (spellWidth + gap), 0);
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
            transform.GetChild(selectedIndex - 1).GetComponent<ButtonFunctions>().Use();
    }
}
