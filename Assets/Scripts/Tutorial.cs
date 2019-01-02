using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public string[] strings;
    private Text text;
    private int index = 0;

    private Animator anim;

    private void Start()
    {
        text = GetComponent<Text>();
        text.text = strings[index];
        anim = GetComponent<Animator>();
    }

    public void UpdateText()
    {
        index++;
        text.text = strings[index];
    }

    public bool PlayAnimation()
    {
        if (index + 1 >= strings.Length)
        {
            return false;
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("TutorialFadeOutAndIn"))
            anim.SetTrigger("Change");
        return true;
    }
}
