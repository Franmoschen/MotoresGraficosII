using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public int chests;
    public GameObject[] prefabLevel;
    private int levelIndex;
    private GameObject levelObject;
    public float timer = 90f;

    public Text gameText;
    // Start is called before the first frame update
    void Start()
    {
        levelIndex = 0;
        levelObject = Instantiate(prefabLevel[levelIndex]);
        levelObject.transform.SetParent(this.transform);
        timer = 90;
    }

    // Update is called once per frame
    void Update()
    {
        //toma el hijo cofre para contar cuantos cofres hay
        timer-= Time.deltaTime;
        chests = this.GetComponentsInChildren<Chest>().Length;
        gameText.text = "Nivel " + (levelIndex + 1) + "\nDestruye todos los cofres" + "\nCofres restantes: " + chests+ "\nTiempo Restante " + timer; // \n es para que escriba en la linea siguiente
        if (chests== 0)
        {
            gameText.text = "Completaste el nivel! \nPresione R para el siguiente nivel";
            Destroy(GameObject.FindWithTag("Bullet"));
            //Diferenciar el ultimo nivel de los demas para indicar el final del juego
            if (levelIndex == prefabLevel.Length - 1)
            {
                timer = 1;
                gameText.text = "Felicidades! Completaste el juego! \nPresione R par volver a empezar";
            }
            //Funcion de la tecla R
            if (Input.GetKeyUp("r"))
            {
                if(levelIndex==prefabLevel.Length - 1)
                {
                    //Destruyo el nivel y reinicio
                    Destroy(levelObject);
                    levelIndex = 0;
                    levelObject = Instantiate(prefabLevel[0]);
                    levelObject.transform.SetParent(this.transform);
                    timer = 90;
                }
                else
                {
                    //Avanzo al siguiente nivel y quito el nivel previo
                    Destroy(levelObject);
                    levelIndex += 1;
                    levelObject = Instantiate(prefabLevel[levelIndex]);
                    levelObject.transform.SetParent(this.transform);
                }
            }
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene("Lost");
        }

    }
}
