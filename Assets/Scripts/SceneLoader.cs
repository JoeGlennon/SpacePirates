using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    Button m_Button;


    // Start is called before the first frame update
    void Start()
    {
        m_Button = gameObject.GetComponent<Button>();
        m_Button.onClick.AddListener(LoadGame);
    }


    private void LoadGame()
    {

        SceneManager.LoadScene(1);
    }
}
