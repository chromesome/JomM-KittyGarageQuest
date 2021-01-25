using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Range (0f, 1.5f)]
    public float parallaxSpeed = 0.02f;
    public RawImage background;
    public RawImage floor;
    public GameObject UIIddle;
    public LevelGenerator levelGenerator;

    public enum GameState { Iddle, Playing};
    public GameState gameState = GameState.Iddle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Comenzar juego
        if(gameState == GameState.Iddle && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            gameState = GameState.Playing;
            UIIddle.SetActive(false);
            levelGenerator.StartLevel();
        }
        else if(gameState == GameState.Playing)
        {
            Parallax();
        }

    }

    private void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        floor.uvRect = new Rect(floor.uvRect.x + finalSpeed, 0f, 1f, 1f);
    }
}
