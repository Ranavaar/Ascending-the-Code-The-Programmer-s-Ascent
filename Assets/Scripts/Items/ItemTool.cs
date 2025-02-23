using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTool : Item
{
    #region Constants
    
    const float POSITIVE_UP_POS = 4;
    const float POSITIVE_FORCE = 200;

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
                jetpack.transform.Translate(Vector2.up * POSITIVE_UP_POS);
            else
                jetpack.GetComponent<Rigidbody2D>().AddForce(Vector2.up * POSITIVE_FORCE);

            Recolected();

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
    #endregion
}
