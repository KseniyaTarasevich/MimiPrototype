using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private float damage;

    [HideInInspector] 
    public float Damage { get => damage; set => damage = value; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destructable target = collision.gameObject.GetComponent<Destructable>();

        if (target != null)
        {

            target.Hit(Damage);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Interior")
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
