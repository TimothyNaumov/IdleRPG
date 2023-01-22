using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject escapePanel;
    public GameObject settingsPanel;

    public Stack<GameObject> activePanels = new Stack<GameObject>();

    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
        if (Input.GetKeyDown("escape"))
        {
            if(activePanels.Count > 0)
            {
                GameObject topActivePanel = activePanels.Pop();
                topActivePanel.SetActive(false);
            } else
            {
                activePanels.Push(escapePanel);
                escapePanel.SetActive(true);
                Time.timeScale = 0;
            }

            if (activePanels.Count == 0)
            {
                Time.timeScale = 1;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        escapePanel.SetActive(false);
        activePanels.Pop();
    }

    public void SaveAndQuit()
    {
        GameDataManager.Instance.saveGame();
        Application.Quit();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        activePanels.Push(settingsPanel);
    }
}