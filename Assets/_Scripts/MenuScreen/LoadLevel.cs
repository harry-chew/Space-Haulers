using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private string levelName;
    public void LoadLevelByName()
    {
        SceneManager.LoadScene(levelName);
    }
}
