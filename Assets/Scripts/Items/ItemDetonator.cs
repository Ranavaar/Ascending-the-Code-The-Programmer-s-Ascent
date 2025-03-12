using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetonator : MonoBehaviour
{
	#region Fields
	[SerializeField] private Collider2D _itemsDeathZone;
	#endregion

	#region Unity CallBacks
    private void Start()
    {
        _itemsDeathZone.enabled = false;
    }
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            _itemsDeathZone.enabled = true;
    }
	#endregion
}
