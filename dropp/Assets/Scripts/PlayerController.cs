using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


            public Rigidbody rb;
            private Vector2 startPos;
            private Vector2 endPos;
            private float force=150;
            private float maxDragDistance = 65f;
	        void Start ()
            {
		
	        }
	
	        void Update ()
            {


                if (Input.GetMouseButtonDown(0))
                {
                    startPos = Input.mousePosition;

                }
        
                if(Input.GetMouseButtonUp(0) && Input.mousePosition.y> startPos.y + 5)
                {
            
                        endPos = Input.mousePosition;
            /* if (Vector3.Distance(startPos, endPos) <= maxDragDistance)
                 ThrowBall(0);
             else {
                 ThrowBall(1);
             }*/
            ThrowBall();
                }
	        }

            private void ThrowBall()
            {
                Vector2 direction = endPos - startPos;
        //if (flag == 0)
          //  force = Vector3.Distance(startPos, endPos);
       // else
           // force = maxDragDistance;
                Debug.Log(force);
                rb.AddForce(direction/direction.magnitude * force * Time.deltaTime, ForceMode.Impulse);
            }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("safe"))
        {
            rb.isKinematic = true;
            rb.isKinematic = false;
        }


        }

    }
