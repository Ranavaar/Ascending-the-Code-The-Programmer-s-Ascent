using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IRecolectable
{      
    #region Enums
    public enum ItemTypes
    {
        None,
        Nose,
        ErrorCode,
        Frustration,
        PositiveWords
    }
    #endregion

    #region Properties
    [field: SerializeField]public ItemTypes Type { get; set; }
    #endregion

    #region Fields
    [SerializeField] private GameObject _particles;
    #endregion    
        
    #region Public Methods
    public void Recolected()
    {
        Destroy(gameObject);
        CreateParticles();
    }
    #endregion

    #region Private Methods
    private void CreateParticles()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }
    #endregion

}
