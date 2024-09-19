using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
    public enum Direction
    {
        Left, 
        Right
    }

    #region Properties

    [field: SerializeField] public float Energy { get; set; }
    public bool Flying { get; set; }

    #endregion


    #region Fields

    private Rigidbody2D _target;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForze;
    [SerializeField] private float _flyForce;

    #endregion


    #region Unity Callbacks

    private void Awake()
    {
        _target = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Energy = _maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Flying)
            Fly();
                  
        
    }   

    #endregion


    #region Public Methods

    public void FlyUp()
    {
        Flying = true;
    }
    public void StopFlying()
    {
        Flying = false;
    }
    public void Regenerate()
    {
        Energy += _energyRegenerationRatio;
    }    
    public void EnergyModification(float energy)
    {
        Energy += energy;
        Energy -= energy;
    }
    public void FlyHorizontal(Direction flyDirection)
    {
        if (!Flying)
            return;

        if (flyDirection == Direction.Left)
            _target.AddForce(Vector2.left * _horizontalForze);
        else
            _target.AddForce(Vector2.right * _horizontalForze);
    }

    #endregion


    #region Private Methods

    private void Fly()
    {
        if (Energy > 0)
        {
            _target.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
        }
        else
            Flying = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Regenerate();
        if (collision.gameObject.tag == "Plataform")
            Regenerate();
    }

    #endregion
}
