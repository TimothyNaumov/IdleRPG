using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    private static MoneyManager _instance;
    public TextMeshProUGUI moneyText;
    public static MoneyManager Instance {
        get {
            return _instance; 
        } 
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

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "Money: " + GameDataManager.Instance.gameData.money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseMoney()
    {
        GameDataManager.Instance.gameData.money++;
        moneyText.text = "Money: " + GameDataManager.Instance.gameData.money;
    }
}
