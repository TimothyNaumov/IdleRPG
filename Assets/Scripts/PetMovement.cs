using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetMovement : MonoBehaviour
{
    public TextMeshProUGUI hungerText;
    int maxHunger = 45;
    public GameObject foodBowl;
    private bool isGoingToEat = false;
    public Transform idlePosition;
    public FoodBowlScript foodBowlScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("decreaseHealth", 0f, 1f);
    }

    private void Awake()
    {
        hungerText.text = "Hunger: " + GameDataManager.Instance.gameData.petHunger;
    }

    void decreaseHealth()
    {
        if(GameDataManager.Instance.gameData.petHunger > 0)
        {
            GameDataManager.Instance.gameData.petHunger--;
            if(GameDataManager.Instance.gameData.petHunger <= 40 && !isGoingToEat)
            {
                StartCoroutine(moveToFoodBowl());
                isGoingToEat = true;
            }
            hungerText.text = "Hunger: " + GameDataManager.Instance.gameData.petHunger;
        } else
        {
            Debug.Log("Your pet ded");
        }
    }

    IEnumerator moveToFoodBowl()
    {
        //moving to food bowl
        float progressToBowl = 0;
        while (!isAtFoodBowl()) {
            transform.position = Vector2.Lerp(idlePosition.position, foodBowl.transform.position, progressToBowl);
            progressToBowl += (Time.deltaTime / 2);
            yield return null;
        }

        //We have gotten to the food bowl, now eat!
        bool successfullyAte = foodBowlScript.EatFood();
        if (successfullyAte)
        {
            Debug.Log("We ate successfully");
            GameDataManager.Instance.gameData.petHunger = maxHunger;

            //Eating and repleneshing hunger from food bowl
            yield return new WaitForSeconds(1.0f);

            //moving back to idle position
            progressToBowl = 0f;
            Vector2 eatingPosition = transform.position;
            while (!isAtIdlePosition())
            {
                transform.position = Vector2.Lerp(eatingPosition, idlePosition.position, progressToBowl);
                progressToBowl += (Time.deltaTime / 2);
                yield return null;
            }
            transform.position = idlePosition.position;
            isGoingToEat = false;
        }
        else
        {
            Debug.Log("There was no food in the bowl, Pet is gonna wait until there is");
            yield return new WaitForSeconds(1.0f);
            //Pet tries to eat again
            StartCoroutine(moveToFoodBowl());
        }

        
    }

    private bool isAtFoodBowl()
    {
        float distanceToFoodBowl = Vector2.Distance(transform.position, foodBowl.transform.position);
        return distanceToFoodBowl < 1;
    }

    private bool isAtIdlePosition()
    {
        float distanceToIdlePosition = Vector2.Distance(transform.position, idlePosition.position);
        return distanceToIdlePosition < .1;
    }

    
}
