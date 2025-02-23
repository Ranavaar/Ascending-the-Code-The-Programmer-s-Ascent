using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
    public enum Direction
    {
        Left, 
        Right
    }

    #region Properties

    public float Energy
    { 
        get
        { 
            return _energy;
        }
        set
        {
            _energy = Mathf.Clamp(value, 0, _maxEnergy);
        }
    }
    public bool Flying { get; set; }
    public bool Running;
    public bool Falling;
    public bool _isGrounded;    

    #endregion


    #region Fields

    private Rigidbody2D _targetRB;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private AudioSource _flyAudio;
    [SerializeField] private AudioSource _regenerationAudio;
    [SerializeField] private GameObject _particlesFire;
    [SerializeField] private GameObject _particlesEnergy;
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForze;
    [SerializeField] private float _flyForce;
    [SerializeField] private float _VxMax = 15;
    [SerializeField] private float _VyMax = 1000;
    [SerializeField] private float _VxCurrent;
    [SerializeField] private float _VyCurrent;

    #endregion


    #region Unity Callbacks

    private void Awake()
    {
        _targetRB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Energy = _maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        _energySlider.value = _energy / _maxEnergy;
        if(_VxCurrent > 0.1)
            StartRunning();
        else
            StopRunning();
        if(_targetRB.velocity.y < -0.1)
            Falling = true;
        else
            Falling = false;
        
    }
    void FixedUpdate()
    {
        

        _VxCurrent = MathF.Abs(_targetRB.velocity.x);
        _VyCurrent = _targetRB.velocity.y;
        

        if (Flying)
            Fly();
        if(MathF.Abs(_VyCurrent) < 0.1f)
        {
            Regenerate();
            if (Energy < _maxEnergy)
                Instantiate(_particlesEnergy, transform.position, Quaternion.identity);           
        }

        //if (-_VyCurrent > -_VyMax)
        //{
        //    float correctiveForce = (-_VyCurrent - -_VyMax);
        //    _targetRB.AddForce(new Vector2(0, correctiveForce), ForceMode2D.Force);
        //}
        //if (_VyCurrent > _VyMax)
        //{
        //    float correctiveForce = (_VyCurrent - _VyMax) * -6;
        //    _targetRB.AddForce(new Vector2(0, correctiveForce), ForceMode2D.Force);
        //}
        //if (_VxCurrent > _VxMax)
        //{
        //    float correctiveForce = (_VxCurrent - _VxMax) * -1;
        //    _targetRB.AddForce(new Vector2(correctiveForce, 0), ForceMode2D.Force);
        //}
        



    }   

    #endregion


    #region Public Methods

    public void FlyUp()
    {
        if(_energy > 0)
        {
            Flying = true;
           
            if(_flyAudio.isPlaying == false)
                _flyAudio.Play();
        }
        else
            Flying = false;
    }
    public void StopFlying()
    {
        Flying = false;

        if (_flyAudio.isPlaying)
            _flyAudio.Stop();
    }
    public void StartRunning()
    {
        Running = true;
    }
    public void StopRunning()
    {
        Running = false;
    }
    public void Regenerate()
    {
        Energy += _energyRegenerationRatio;
        if (_regenerationAudio.isPlaying == false)
            _regenerationAudio.Play();
        if (_regenerationAudio.isPlaying)
            _regenerationAudio.Stop();
    }
    public void MoreEnergyRegeneration(float energy)
    {
        _energyRegenerationRatio += energy;
    }
    public void LessEnergyRegeneration(float energy)
    {
        _energyRegenerationRatio -= energy;
    }
    public void EnergyHeal(float energy)
    {
        Energy += energy;
       
    }
    public void EnergyRemove(float energy)
    {
        Energy -= energy;

    }
    public void AddMaxEnergy(float energy)
    {
        _maxEnergy += energy;

    }
    public void RemoveMaxEnergy(float energy)
    {
        _maxEnergy -= energy;

    }
    public void HorizontalMove(Direction directionMove)
    {     
        if (directionMove == Direction.Left)
        {
            _targetRB.AddForce(Vector2.left * _horizontalForze * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            _targetRB.AddForce(Vector2.right * _horizontalForze * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    

    #endregion


    #region Private Methods

    private void Fly()
    {
        if (Energy > 0)
        {
            _targetRB.AddForce(Vector2.up * _flyForce * Time.deltaTime);
            Energy -= _energyFlyingRatio;
            Instantiate(_particlesFire, transform.position, Quaternion.identity);
            
        }
        else
            Flying = false;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Plataform")
            _isGrounded = true;
        else
            _isGrounded = false;
        if (collision.gameObject.tag == "Plataform5")
            Energy += 25;
    }

    #endregion
}
