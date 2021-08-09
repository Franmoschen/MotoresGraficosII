using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //El cofre se destruye cuando toque el piso o la bala

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Floor")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
