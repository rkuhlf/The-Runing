using UnityEngine.UI;
using UnityEngine;

public class SpellButton : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseEnter()
    {
        anim.SetBool("Highlighted", true);
    }

    private void OnMouseExit()
    {
        anim.SetBool("Highlighted", false);
    }

    public void Select()
    {
        anim.SetBool("Selected", true);
    }

    public void Deselect()
    {
        anim.SetBool("Selected", false);
    }

    public void Use()
    {
        anim.SetBool("Used", true);
        anim.SetBool("Selected", false);
        GetComponent<Button>().interactable = false;
    }
}
