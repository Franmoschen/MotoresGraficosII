using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDelete= 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDelete -= Time.deltaTime;
        if (timeDelete<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
