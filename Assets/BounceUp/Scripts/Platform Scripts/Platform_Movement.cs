using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour {

    // public
    public Vector3 direction;
    public float speed;
    public float moveTime;
    public float iddleTime;
	// private
    private float currentTime = 0f;
    private bool canMove = false;
    private Coroutine currentCourutine;

	// Unity Methods
	// Use this for initialization
	void Start () {
        currentCourutine = StartCoroutine(Iddle(iddleTime));
	}

    void Update()
    {
        if (canMove)
        {
            currentTime += Time.deltaTime;
            if(currentTime > moveTime)
            {
                currentCourutine = StartCoroutine(Iddle(iddleTime));
                currentTime = 0f;
            }else
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

	// My Methods
    IEnumerator Iddle(float waitTime)
    {
        canMove = false;
        Debug.Log("Iddle");
        yield return new WaitForSeconds(waitTime);
        //StopCoroutine(currentCourutine);
        direction = direction * -1;
        canMove = true;
    }
}
