using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleStartTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemyに接触！戦闘開始！");
            SceneManager.LoadScene("BattleScene");
        }
    }
}