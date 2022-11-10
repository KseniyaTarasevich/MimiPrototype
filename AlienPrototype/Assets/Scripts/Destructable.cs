using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [Header("Изначальное кол-во жизней")]
    [SerializeField]
    private float hitPoints;

    private float currentHitPoints;

    private GameObject player;

    private GameController _gameController;

    private void Die()
    {
        Destroy(player);
        _gameController.State = GameState.Over;
    }

    public void Hit(float damage)
    {
        currentHitPoints -= damage;

        if (currentHitPoints <= 0) 
            Die();
    }

    private void Awake()
    {
        _gameController = GameController.Instance;
        player = gameObject.transform.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = hitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
