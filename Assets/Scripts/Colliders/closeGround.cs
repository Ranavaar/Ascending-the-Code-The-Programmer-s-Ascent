using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGround : MonoBehaviour
{
	#region Fields
	[SerializeField]private Collider2D ground;
	#endregion

	#region Unity CallBacks
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ground.enabled = true;

    }
	#endregion
}
