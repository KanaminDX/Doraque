using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void LoadGameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
    public void LoadGameStart()
    {
        SceneManager.LoadScene("GameStart");
    }
}