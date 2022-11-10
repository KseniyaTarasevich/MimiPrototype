using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterSpawnPoint : MonoBehaviour 
{
    [Header ("Çàäåðæêà âîçðîæäåíèÿ")]
    [SerializeField]
    private float spawnDelay;

    [Header("Ïðåôàá ïåðñîíàæà")]
    [SerializeField]
    private GameObject characterPrefab;

    public void Spawn()
    {
        GameObject newCharacter = Instantiate(characterPrefab, transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
