using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Vorgefertigte Attribute
    public static List<Enemy> Enemies = new List<Enemy>();//Eine Liste aller aktiven Gegner

    //Verweise auf andere GameObjects
    protected GameManager gameManager;
    protected Player player;
    [SerializeField]
    private GameObject explosionEffect;
    #endregion

    public float Speed = 1.5f;
    public Vector3 position;

    private void Update()
    {
        #region Aufgabe 4
        //Bewege den Gegner abhängig von "Speed" nach unten

        #region Lösung
        /*
        //Bewege den Gegner abhängig von "Speed" nach unten
        position.y -= Speed * Time.deltaTime;*/
        #endregion
        #endregion
    }


    //Diese Methode wird automatisch aufgerufen wenn der Gegner von einem Projektil getroffen wird
    protected void OnHitByProjectile(Projectile projectile)
    {
        #region Aufgabe 5 a)

        //Lass sowohl den Gegner als auch das Projektil explodieren

        #region Lösung
        /*
        Explode();//Gegner stirbt
        projectile.Explode();*/
        #endregion
        #endregion

        #region Aufgabe 7 b)
        //Gib dem Spieler 100 Punkte für das Treffen des Gegners (gameManager.GetPoints())

        #region Lösung
        /*
        gameManager.GetPoints(100);//Spieler bekommt Punkte
        */
        #endregion
        #endregion
    }

    public void Explode()
    {
        #region Aufgabe 5 a)

        //Lösche den Gegner und erstelle einen Explosions-Effekt mit Instantiate

        #region Lösung
        /*
        Destroy(this.gameObject);
        Instantiate(explosionEffect, position, Quaternion.identity);*/
        #endregion
        #endregion
    }

    #region Vorgefertigte Methoden
    private void Start()
    {
        Enemies.Add(this);//Registriere den neuen Gegner in der Liste

        //Erstelle GameObject Referenzen
        gameManager = FindObjectOfType<GameManager>();
        player = gameManager.player;

        position = transform.position;//Speichere Startposition
    }

    private void OnDestroy()
    {
        Enemies.Remove(this);//Lösche Gegner aus Liste der aktiven Gegner
    }

    private void LateUpdate()
    {
        //Setzt am Ende des Frames die tatsächliche Position des Gegners auf "position"
        transform.position = position;
    }

    //Eigentliche Kollisionsmethode (ruft vereinfachte oben auf)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Prüfe auf Kollision mit Projektil
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            OnHitByProjectile(collision.gameObject.GetComponent<Projectile>());
        }
    }
    #endregion
}
