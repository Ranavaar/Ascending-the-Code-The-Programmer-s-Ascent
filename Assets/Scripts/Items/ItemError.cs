using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemError : Item
{
    #region Constants
    const float ERROR_FORCE = 50;
    const float ERROR_DOWN_POS = 2.5f;
    #endregion

    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);

        Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();

        if (collision.gameObject.tag == "Player")
        {
            if (jetpack.Flying)
                jetpack.GetComponent<Rigidbody2D>().AddForce(Vector2.down * ERROR_FORCE);
            else
                jetpack.transform.Translate(Vector2.down * ERROR_DOWN_POS);

            Recolected() ;
           
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
    #endregion
}
