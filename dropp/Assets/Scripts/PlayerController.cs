using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour {


           // public Rigidbody rb;
            private Vector2 startPos;
            private Vector2 endPos;
            private float force=150;
	        private float speed =6f;

            private float maxDragDistance = 65f;
	        void Start ()
            {
		
	        }

    /*void Update ()
     {


         if (Input.GetMouseButtonDown(0))
         {
             startPos = Input.mousePosition;

         }

         if(Input.GetMouseButtonUp(0) && Input.mousePosition.y> startPos.y + 5)
         {

                 endPos = Input.mousePosition;
    //  if (Vector3.Distance(startPos, endPos) <= maxDragDistance)
   //        ThrowBall(0);
   //   else {
   //          ThrowBall(1);
   //   }
    ThrowBall();
         }
     }*/

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			Physics.gravity = new Vector3 (0, -1 * Physics.gravity.y, 0);
		}
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);


	}
	/*private void ThrowBall()
            {
                Vector2 direction = endPos - startPos;
        //if (flag == 0)
          //  force = Vector3.Distance(startPos, endPos);
       // else
           // force = maxDragDistance;
                Debug.Log(force);
              //  rb.AddForce(direction/direction.magnitude * force * Time.deltaTime, ForceMode.Impulse);
            }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("safe"))
        {
			GetComponent<SphereCollider> ().material.bounciness = 0;
        }


        }*/

    }
