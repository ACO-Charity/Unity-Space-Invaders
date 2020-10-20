using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private float amount = 15f;
    private Vector3 restPos;
    private float timer = 0.0f;

    private void Start()
    {
        restPos = transform.position;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer > 0.0f)
        {
            //Calculate direction
            Vector2 randomDir = Random.insideUnitCircle;//random 2D direction
            Vector3 direction = new Vector3(randomDir.x * Mathf.Sin(amount * Time.deltaTime), randomDir.y * Mathf.Sin(amount * Time.deltaTime), 0);//oscillate in that direction

            this.transform.position = restPos + direction;//add to standard position
        }
        else
        {
            timer = 0.0f;
            transform.position = restPos;
        }
    }


    public void StartShake(float duration)
    {
        timer = duration;
    }
}
