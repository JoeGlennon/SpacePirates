using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField]
    float m_LoadDelay = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", m_LoadDelay);
    }

    private void LoadGame()
    {

        SceneManager.LoadScene(1);
    }
}
