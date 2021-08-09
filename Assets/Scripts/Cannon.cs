using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject headCannon;
    public Camera gameCamera;
    public GameObject bullet;
    public float shootSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 mousePosition = Input.mousePosition;
        //movemos la proyeccion de la camara a la pantalla del juego
        Vector3 globalPosition = gameCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - gameCamera.transform.position.z));
                                                                                                                                                                      
    //con este codigo muevo el angulo del cabezal en base al punto del mouse, pero antes tiene que pasarse de radianes a sexagesimal con el Mathf.Rad2Deg
        headCannon.transform.localEulerAngles = new Vector3(
            headCannon.transform.localEulerAngles.x, 
            headCannon.transform.localEulerAngles.y,
      /* Atan2 me da el angulo del cabezal en radianes*/ 
      Mathf.Atan2((globalPosition.y - headCannon.transform.position.y), (globalPosition.x - headCannon.transform.position.x)) * Mathf.Rad2Deg);
     //con este if instancio y le doy direccion a la bala
        if (Input.GetMouseButtonDown(0))
        {

            GameObject bulletObject = Instantiate(bullet);
            bulletObject.transform.position = headCannon.transform.position;
            //Agregamos fuerza hacia el lado que apunta el cabezal en el angulo del eje x
            bulletObject.GetComponent<Rigidbody2D>().AddForce(headCannon.transform.right * shootSpeed);
            //La bala se crea como objeto hijo del canon
            bulletObject.transform.SetParent(this.transform);
        }

    }
}
