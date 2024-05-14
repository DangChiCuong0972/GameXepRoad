using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speedMove = 10f;
    [SerializeField] private float speedRotate = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, vertical * speedMove * Time.deltaTime));
        transform.Rotate(new Vector3(0 , horizontal * speedRotate * Time.deltaTime, 0));

    }
}
