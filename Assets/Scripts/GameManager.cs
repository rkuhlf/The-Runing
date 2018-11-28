using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip music;
    private Animator fadeAnimator;

    private AudioManager audioManager;

    private bool loadingLevel = false;

    public int level = 0;
    public static GameManager instance = null;

    private bool won = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.PlayRepeating(music);
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        fadeAnimator = GameObject.FindGameObjectWithTag("BlackFade").GetComponent<Animator>();        
    }

    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        FadeToLevel(index);
    }


    public void FadeToLevel(int index)
    {
        fadeAnimator.SetTrigger("FadeOut");
        StartCoroutine(LoadLevel(index));
    }

    private IEnumerator LoadLevel(int index)
    {
        if (!loadingLevel)
        {
            loadingLevel = true;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(index);
            loadingLevel = false;
        }
    }
}




  

    

    

