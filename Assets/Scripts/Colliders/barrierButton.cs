using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierButton : MonoBehaviour
{
	#region Fields
	[SerializeField]private GameObject closeBarrier;
	#endregion

	#region Unity CallBacks
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(closeBarrier);
            Destroy(gameObject);
            
        }
    }
	#endregion
}
