using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour {

    public string spell = "";

    private int index;

    public AudioClip selectSound;

    private void Start()
    {
        if (spell != "")
        {
            index = GetIndex();
        }
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

    public void Select()
    {
        AudioManager.instance.PlaySingle(selectSound);
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<SpellButton>().Deselect();
        }
        GetComponent<SpellButton>().Select();
        transform.parent.GetComponent<SpellHolder>().selectedIndex = index;
    }

    public void Pause()
    {
        Animator pause = GameObject.FindGameObjectWithTag("PauseScreen").GetComponent<Animator>();
        bool paused = !pause.GetBool("Paused");
        pause.SetBool("Paused", paused);
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Restart()
    {
        AudioManager.instance.PlaySingle(selectSound);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().RestartLevel();
    }

    public void Exit()
    {
        AudioManager.instance.PlaySingle(selectSound);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().FadeToLevel(0);
    }

    public void LoadNextLevel()
    {
        AudioManager.instance.PlaySingle(selectSound);
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        gm.level++;
        gm.LoadCurrentLevel();
    }
}
