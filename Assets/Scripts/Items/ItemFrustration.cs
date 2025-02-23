using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFrustration : Item
{
    #region Constants

    const float FRUSTRATION_REMOVE = 5;
    const float FRUSTRATION_DAMAGE = 20;

    #endregion

    #region Unity Callbacks

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);


        if (collision.gameObject.tag == "Player")
        {

            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();

            if (jetpack.Flying)
                jetpack.EnergyRemove(FRUSTRATION_DAMAGE);
            else
                jetpack.RemoveMaxEnergy(FRUSTRATION_REMOVE);

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
