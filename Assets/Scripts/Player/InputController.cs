using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Jetpack _jetpack;
    #endregion

    #region Unity Callbacks
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
            _jetpack.HorizontalMove(Jetpack.Direction.Right);
        if (Input.GetAxis("Horizontal") < 0)
            _jetpack.HorizontalMove(Jetpack.Direction.Left);
        if (Input.GetAxis("Vertical") > 0)
            _jetpack.FlyUp();
        else
            _jetpack.StopFlying();
    }
    #endregion
}
