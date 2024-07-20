using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickyPlatfrom : MonoBehaviour
{
    // nếu sd 1 coll box thì dùng này để người chơi được đưa đi
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    */


    // nếu sd 2 coll box để người chơi tự di chuyển
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }


}
