using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Vorgefertigte Attribute
    //Verweise auf andere GameObjects
    public GameObject Projectile;//Prefab für Projektile
    public GameManager gameManager;

    [SerializeField]
    private GameObject loseLifeEffect;
    #endregion

    private Vector3 position;
    public int Lives = 3;

    void Update()
    {
        //Welche Tasten drückt der Spieler gerade?
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool up = Input.GetKeyDown(KeyCode.UpArrow);

        #region Aufgabe 1

        //Wenn links gedrueckt wird, bewege den Spieler nach links
        

        //Wenn rechts gedrueckt wird, bewege den Spieler nach rechts

        #region Lösung
        /*
        //Wenn links gedrueckt wird, bewege den Spieler nach links
        if (left)
        {
            position.x -= 10.0f * Time.deltaTime;
        }

        //Wenn rechts gedrueckt wird, bewege den Spieler nach rechts
        if (right)
        {
            position.x += 10.0f * Time.deltaTime;
        }
        */
        #endregion

        #endregion

        #region Aufgabe 2
        //Beschränke den Bereich, in dem sich der Spieler bewegen kann

        #region Lösung
        /*
        //Beschränke den Bereich, in dem sich der Spieler bewegen kann
        if(position.x > 10.0f) { position.x = 10.0f; }
        if (position.x < -10.0f) { position.x = -10.0f; }
        */
        #endregion

        #endregion

        #region Aufgabe 3 a)

        //Wenn gerade hoch gedrueckt wurde, rufe Shoot() auf

        #region Lösung
        /*
        //Wenn gerade hoch gedrueckt wurde, rufe Shoot() auf
        if (up)
        {
            Shoot();
        }*/
        #endregion
        #endregion

    }


    //Diese Methode erzeugt ein Projektil an der Position des Spielers
    void Shoot()
    {
        #region Aufgabe 3 a)
        //Erstelle ein Projektil mithilfe der Instantiate-Methode

        #region Lösung
        /*
        Instantiate(Projectile, position, Quaternion.identity);
        */
        #endregion

        #endregion
    }

    //Diese Methode wird automatisch aufgerufen, wenn der Spieler mit einem Gegner kollidiert
    protected void OnHitEnemy(Enemy enemy)
    {
        #region Aufgabe 5 b)
        //Ziehe dem Spieler ein Leben ab (ohne dass sie unter 0 fallen!)


        //Erstelle einen "loseLifeEffect" mit Instantiate


        //Lass den Gegner explodieren, der den Spieler getroffen hat

        #region Lösung
        /*
        Lives -= 1;
        if (Lives < 0) { Lives = 0; }
        else { Instantiate(loseLifeEffect, position, Quaternion.identity); }

        //Zerstoere den Gegner
        enemy.Explode();*/
        #endregion
        #endregion

        #region Aufgabe 7 b)
        //Ziehe dem Spieler 100 Punkte ab, weil er von einem Gegner getroffen wurde (gameManager.LosePoints())

        #region Lösung
        /*
        gameManager.LosePoints(100);//Verliere Punkte
        */
        #endregion
        #endregion
    }

    #region Vorgefertigte Methoden
    void Start()
    {
        position = transform.position;
    }

    void LateUpdate()
    {
        //Setzt am Ende des Frames die tatsächliche Position des Spielers auf "position"
        transform.position = position;
    }

    //Eigentliche Kollisionsmethode (ruft vereinfachte oben auf)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Prüfe auf Kollision mit Gegner
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            OnHitEnemy(collision.gameObject.GetComponent<Enemy>());
        }
    }
    #endregion
}
