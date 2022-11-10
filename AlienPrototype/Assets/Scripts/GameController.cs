using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Play,
    Puse,
    Over
}

public class GameController : MonoBehaviour
{
    [Header("Òàéìàóò ðåñïàóíà ÃÃ")]
    [SerializeField]
    private float respawnTimeout;

    private static GameController instance;
    public static GameController Instance { get => instance; }

    private GameObject characterSpawnPoint;
    private CharacterSpawnPoint characterSpawnPointScript;

    private GameState state;

    public GameState State { 
        get => state; 
        set { 
            if (value == GameState.Play || value == GameState.Over)
            {
                Time.timeScale = 1.0f;
            } 
            else
            {
                Time.timeScale = 0.0f;
            }

            state = value; 
        } 
    }

    private void CharacterRespawn()
    {
        characterSpawnPointScript.Spawn();

        // приаттачим камеру к заспавненому персу
        CameraController.Instance.Attach();
    }

    void Awake()
    {
        instance = this;

        State = GameState.Play;

        characterSpawnPoint = GameObject.FindGameObjectWithTag("CharacterSpawnPoint");
        characterSpawnPointScript = characterSpawnPoint.GetComponent<CharacterSpawnPoint>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CharacterRespawn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (State)
        {
            case GameState.Over:

                State = GameState.Play;

                // ïðåäëîæèòü îòðåñïàóíèòü èãðîêà, íî ïîêà ïðîñòî ðåñïàóí
                Invoke("CharacterRespawn", respawnTimeout);

                break;
        }
    }
}
