using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Properties

    #endregion


    #region Fields
    [SerializeField] private Jetpack _jetpack;
    private Animator _playerAnim;
    #endregion


    #region Unity Callbacks

    private void Awake()
    {
        _playerAnim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _playerAnim.SetBool("Flying", _jetpack.Flying);
    }

    #endregion


    #region Public Methods

    #endregion


    #region Private Methods

    #endregion

}
