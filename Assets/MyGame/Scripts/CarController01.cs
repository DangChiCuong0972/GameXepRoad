using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController01 : MonoBehaviour
{
   
       [SerializeField] private float speedMove = 10f;
       [SerializeField] private float speedRotate = 30f;
       public float maxHealth = 100;
       private float currentHealth = 0;
       public float fuelValue = 20;
       public float damageValue = 50;
    public int roundValue = 1;
    private bool isGate = false;

       public GameObject explusionPrefab;
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(0, 0, vertical * speedMove * Time.deltaTime));
            transform.Rotate(new Vector3(0, horizontal * speedRotate * Time.deltaTime, 0));
            
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fuel")
        {
            Destroy(other.gameObject);
            GameManager.Instance.SetFuel(fuelValue);
            InstantiateGame(other);
        }
        else if(other.tag == "Damage")
        {
            DamageHealth(damageValue);
            Debug.LogWarning("So Health con lai : " + currentHealth);
            InstantiateGame(other);
            
        }else if (other.tag == "FinishGate")
        {
            if (isGate)
            {
                GameManager.Instance.SetRound(roundValue);
                isGate = false;
            }
        }

        if (other.name == "Gate")
        {
            isGate = true;
        }



    }

    void InstantiateGame(Collider other)
    {
        Instantiate(explusionPrefab, other.transform.position, Quaternion.identity);
    }

    private void DamageHealth(float health)
    {
        if(currentHealth > 0 )
        {
            currentHealth -= health;
        }
        else
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }

}
