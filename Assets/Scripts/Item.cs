using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    #region Constants
    const float NOSE_DAMAGE = 20;
    const float ERROR_FORCE = 50;
    const float POSITIVE_HEAL = 20;
    #endregion
    #region Enums
    public enum ItemTypes
    {
        None,
        Nose,
        ErrorCode,
        PositiveWords
    }
    #endregion
    #region Properties
    [field: SerializeField]public ItemTypes Type { get; set; }
    #endregion


    #region Fields

    #endregion


    #region Unity Callbacks

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();      
        if (collision.gameObject.tag == "Player")
        {
            switch (Type)
            {
                case ItemTypes.Nose:
                    if (jetpack.Flying)
                        jetpack.EnergyModification(NOSE_DAMAGE);
                    else
                        jetpack.transform.Translate(Vector2.down * 2.5f);
                    break;
                case ItemTypes.ErrorCode:
                    if (jetpack.Flying)
                        jetpack.GetComponent<Rigidbody2D>().AddForce(Vector2.down * ERROR_FORCE);                   
                    break;
                case ItemTypes.PositiveWords:
                    if (jetpack.Flying)
                        jetpack.EnergyModification(POSITIVE_HEAL);
                    else
                        jetpack.EnergyModification(POSITIVE_HEAL * 3);
                    break;

            }
        }

    }

    #endregion


    #region Public Methods

    #endregion


    #region Private Methods

    #endregion

}
