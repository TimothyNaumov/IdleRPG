using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodBowlScript : MonoBehaviour
{
    public int foodLeft = 1;
    public Sprite fullBowl;
    public Sprite emptyBowl;
    public GameObject loadingSlider;
    public GameObject dangerSign;
    public Image fillImage;
    private SpriteRenderer sr;
    private bool playerIsInRange = false;
    private float fillProgress = 0;
    


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (GameDataManager.Instance.gameData.foodIsInBowl)
        {
            sr.sprite = fullBowl;
        } else
        {
            sr.sprite = emptyBowl;
            loadingSlider.SetActive(true);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Interact") == 1){
            if (foodLeft <= 0 && playerIsInRange)
            {
                fillProgress += Time.deltaTime;
                fillImage.fillAmount = fillProgress;
                if (fillProgress >= 1)
                {
                    if (GameDataManager.Instance.gameData.petFood > 0)
                    {
                        GameDataManager.Instance.gameData.petFood--;
                        foodLeft = 1;
                        sr.sprite = fullBowl;
                        GameDataManager.Instance.gameData.foodIsInBowl = true;
                        loadingSlider.SetActive(false);
                    } else
                    {
                        fillProgress = 0;
                        loadingSlider.SetActive(false);
                        dangerSign.SetActive(true);
                    }
                }
            }
        } else
        {
            fillProgress = 0;
            fillImage.fillAmount = fillProgress;
        }
    }

    public bool EatFood()
    {
        if(GameDataManager.Instance.gameData.foodIsInBowl)
        {
            sr.sprite = emptyBowl;
            GameDataManager.Instance.gameData.foodIsInBowl = false;
            loadingSlider.SetActive(true);
            return true;
        } else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            
            playerIsInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            
            playerIsInRange = false;
        }
    }
}
