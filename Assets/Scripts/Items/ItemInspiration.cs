using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspiration : Item
{
    #region Constants    
    
    const float POSITIVE_ADD = 5;
    const float POSITIVE_ADD_CHARGE = 0.4f;

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
                jetpack.AddMaxEnergy(POSITIVE_ADD);
            else
                jetpack.MoreEnergyRegeneration(POSITIVE_ADD_CHARGE);
                         
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
