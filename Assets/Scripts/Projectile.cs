using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region Vorgefertigte Attribute
    [SerializeField]
    private GameObject explosionEffect;
    #endregion

    public float Speed = 5.0f;
    public float TimeToLive = 2.0f;
    public Vector3 position;

    void Update()
    {
        #region Aufgabe 3 b)

        //Bewege das Projektil abhängig von "Speed" nach oben


        #region Lösung
        /*
        //Bewege das Projektil abhängig von "Speed" nach oben
        position.y += Speed * Time.deltaTime;
        */
        #endregion

        #endregion

        #region Aufgabe 3 c)

        //Lasse den Timer herablaufen

        //Wenn er abgelaufen ist, rufe "Explode()" auf um das Projektil zu löschen

        #region Lösung
        /*
        TimeToLive -= Time.deltaTime;//Lasse den Timer herablaufen

        //Wenn der Timer abgelaufen ist
        if (TimeToLive <= 0.0f)
        {
            //Zerstöre das Projektil
            Explode();
        }*/
        #endregion

        #endregion
    }

    public void Explode()
    {
        #region Aufgabe 3 c)

        //Lösche hier das Projektil und erstelle einen Explosions-Effekt mithilfe von "Instantiate"

        #region Lösung
        /*
        Destroy(gameObject);
        Instantiate(explosionEffect, position, Quaternion.identity);
        */
        #endregion

        #endregion
    }

    #region Vorgefertigte Methoden
    private void Start()
    {
        position = transform.position;//Speichere Startposition
    }

    private void LateUpdate()
    {
        //Setzt am Ende des Frames die tatsächliche Position des Projektils auf "position"
        transform.position = position;
    }
    #endregion
}


