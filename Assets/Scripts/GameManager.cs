using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Vorgefertigte Attribute
    //Verweise
    [SerializeField]
    protected ScreenShake screenshake;

    public Player player;
    public UI ui;

    public Enemy enemyPrefab;//Prefab um Enemies zu Spawnen
    #endregion

    public int Score = 0;
    public float SpawnCooldown = 2.0f;
    public float EnemySpeed = 1.5f;

    private float spawnTimer = 2.0f;
    private bool gameOver = false;

    private void Update()
    {
        #region Aufgabe 6
        //Verwende "spawnTimer" um regelmäßig neue Gegner erscheinen zu lassen
        //Random.Range(a, b) kannst du benutzen, um einen zufälligen Wert zwischen a und b zu bekommen

        #region Lösung
        /*
        //Erstelle regelmäßig Gegner
        if (spawnTimer <= 0.0f)//Wenn der Timer Abgelaufen ist
        {
            float randomX = Random.Range(-10.0f, 10.0f);//Würfle einen zufälligen X-Wert zwischen -10 und 10

            SpawnEnemy(new Vector3(randomX, 8.0f, 0.0f), EnemySpeed);//Erstelle einen Gegner an dieser Position overhalb des Bildschirms
            spawnTimer = SpawnCooldown;//Resette den Timer
        }

        spawnTimer -= Time.deltaTime;//Lasse den Timer herablaufen
        */
        #endregion

        #endregion

        #region Aufgabe 7 c)
        //Gehe durch die Liste aller Gegner (Enemy.Enemies) und prüfe, ob der Gegner unterhalb des Bildschirms ist
        //Wenn ja, dann lass den Gegner explodieren und zieh dem Spieler 500 Punkte ab

        #region Lösung
        /*
        //Gibt es einen Gegner der den unteren Bildschirmrand beruehrt?
        foreach (Enemy enemy in Enemy.Enemies)
        {
            //Wenn ja dann
            if (enemy.position.y < -5.0f)
            {
                LosePoints(500);//Punkte werden abgezogen
                enemy.Explode();//Gegner stirbt
            }
        }*/
        #endregion
        #endregion

        #region Aufgabe 8

        //Prüfe ob der Spieler noch Leben übrig hat
        //Wenn nicht, rufe GameOver() auf und merke dir mithilfe von "gameOver", dass das Spiel vorbei ist


        //Falls das Spiel gerade vorbei ist und der Spieler die Leertaste drückt
        
        //Starte das Spiel neu
        //Rufe dazu Restart() auf und setze alle Werte (Score, player.Lives, etc.) auf ihre Anfangswerte
        //Gehe außerdem durch die Liste aller Gegner durch und lass sie explodieren


        #region Lösung
        /*
        //Hat der Spieler noch Leben uebrig?
        if (player.Lives <= 0)
        {
            //Wenn nicht, dann Game Over
            GameOver();
            gameOver = true;//Speichere, dass gerade Game Over
        }*/

        /*
        //Wenn Game Over und eine Leertaste gedrückt wird
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            //Starte Spiel neu
            Restart();
            gameOver = false;//Speichere, dass Spiel wieder läuft

            //Setze Werte auf Anfangswert
            Score = 0;
            player.Lives = 3;
            SpawnCooldown = 2.0f;

            //Zerstöre alle aktiven Gegner
            foreach (Enemy enemy in Enemy.Enemies)
            {
                enemy.Explode();
            }
        }*/
        #endregion
        #endregion
    }

    //Diese Methode soll aufgerufen werden, wenn der Spieler Punkte verliert
    public void LosePoints(int points)
    {
        #region Aufgabe 7 a)
        //Ziehe von Score die übergebene Anzahl Punkte ab (ohne dass Score kleiner als 0 wird!)

        //Verwende "screenShake.StartShake(0.5f)" um den Bildschirm wackeln zu lassen

        #region Lösung
        /*
        Score -= points;
        if (Score < 0) { Score = 0; }//Der Punktestand darf nicht kleiner als 0 werden

        screenshake.StartShake(0.5f);//Immer wenn Punkte verloren werden soll der Bildschirm wackeln
        */
        #endregion
        #endregion


        #region Aufgabe 9
        //Verringere den Schwierigkeitsgrad indem du SpawnCooldown erhöhst
        //Pass dabei darauf auf, dass SpawnCooldown nicht größer als 2.0 wird!

        #region Lösung
        /*
        //Verringere Schwierigkeitsgrad bei Punktverlust
        SpawnCooldown += 0.1f;
        if (SpawnCooldown > 2.0f) { SpawnCooldown = 2.0f; }*/
        #endregion
        #endregion
    }


    //Diese Methode soll aufgerufen werden, wenn der Spieler Punkte bekommt
    public void GetPoints(int points)
    {
        #region Aufgabe 7 a)
        //Erhöhe Score um die übergeben Anzahl an Punkten

        #region Lösung
        /*
        Score += points;
        */
        #endregion
        #endregion

        #region Aufgabe 9
        //Erhöhe langsam den Schwierigkeitsgrad indem du SpawnCooldown ein kleines Bisschen verringerst
        //Pass dabei darauf auf, dass SpawnCooldown nicht kleiner als 0.4 wird!
        //Wenn du SpawnCooldown änderst musst du außerdem darauf achten, dass spawnTimer nicht größer als der neue Maximalwert ist.

        #region Lösung
        /*
        //Erhöhe Schwierigkeitsgrad mit steigender Punktzahl
        SpawnCooldown -= 0.05f;
        if (SpawnCooldown < 0.4f) { SpawnCooldown = 0.4f; }//SpawnCooldown sollte nicht kleiner als 0.4 werden

        if (spawnTimer > SpawnCooldown) { spawnTimer = SpawnCooldown; }//spawnTimer darf nicht größer als der aktuelle SpawnCooldown sein*/
        #endregion
        #endregion
    }

    #region Vorgefertigte Methoden
    private void LateUpdate()
    {
        ui.UpdateDisplay(Score, player.Lives);//Aktualisiere Lebens- und Punkteanzeigen
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            ui.ShowPause(true);
        }
        else
        {
            Time.timeScale = 1;
            ui.ShowPause(false);
        }
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        ui.ShowGameOver(true);
    }

    public void Restart()
    {
        ui.ShowGameOver(false);
        Time.timeScale = 1;
    }

    private Enemy SpawnEnemy(Vector3 spawnPosition, float speed)
    {
        Enemy spawnedEnemy = Instantiate<Enemy>(enemyPrefab, spawnPosition, Quaternion.identity);
        spawnedEnemy.Speed = speed;
        return spawnedEnemy;
    }

    #endregion
}
