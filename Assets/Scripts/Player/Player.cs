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
        _playerAnim.SetBool("Falling", _jetpack.Falling);
        if(_jetpack._isGrounded)
            _playerAnim.SetBool("Run", _jetpack.Running);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            _playerAnim.SetTrigger("Damaged");
        }
        if (collision.gameObject.tag == "ItemBonus")
        {
            _playerAnim.SetTrigger("Bonused");
        }
       


    }

    #endregion


    #region Public Methods

    #endregion


    #region Private Methods

    #endregion

}
