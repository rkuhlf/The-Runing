using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour
{
    public GameObject clickEffect;
    private Animator anim;
    GraphicRaycaster m_Raycaster;
    EventSystem m_EventSystem;

    private static Mouse instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        m_Raycaster = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GraphicRaycaster>();
        m_EventSystem = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<EventSystem>();
    }

    private void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward * 10;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Click");
            Instantiate(clickEffect, transform.position, Quaternion.identity);
        }
    }

    public bool IsMouseOnUI()
    {
        
        PointerEventData m_PointerEventData;

        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.layer == 5) // 5 is the ui layer
                return true;
        }

        return false;
    }
}



