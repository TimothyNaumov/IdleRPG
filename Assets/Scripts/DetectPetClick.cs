using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPetClick : MonoBehaviour
{
    public GameObject moneyPrefab;
    public Transform moneySpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked on pet!");
        Instantiate(moneyPrefab, transform.position, Quaternion.identity, moneySpawnPoint);
    }
}
