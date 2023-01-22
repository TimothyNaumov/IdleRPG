using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDrop : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(getRandomVector());
        rb.AddTorque(100);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 getRandomVector()
    {
        float randomAngle = Random.Range(0, Mathf.PI * 2);
        //float randomAngle = 3 * (Mathf.PI / 2);
        float deltaX = Mathf.Cos(randomAngle);
        float deltaY = Mathf.Sin(randomAngle);
        return new Vector2(deltaX, deltaY) * Random.Range(100, 300);
    }
}
