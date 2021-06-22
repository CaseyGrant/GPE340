using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance// allows the game manager to be called by instance
    {
        get
        {
            if (_instance == null) // if there is no game manager
            {
                _instance = FindObjectOfType<GameManager>(); // find a game manager
            }

            return _instance; // make the found game manager the instance of the game manager
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // make the game manager persist throughout all scenes
    }
}
