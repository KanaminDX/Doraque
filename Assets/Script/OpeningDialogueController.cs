using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroDialogueManager : MonoBehaviour
{
    [Header("表示するテキストUI")]
    public TextMeshProUGUI dialogueText;

    [Header("5つの文章を入力してください")]
    [TextArea(3, 10)]
    public string[] lines = new string[5];

    [Header("表示スピード（1文字出す速度）")]
    public float typeSpeed = 0.05f;

    [Header("次の行へ移るまでの待機時間")]
    public float waitTime = 2.0f;

    void Start()
    {
        if (dialogueText != null && lines.Length > 0)
        {
            StartCoroutine(PlayDialogue());
        }
    }

    IEnumerator PlayDialogue()
    {
        foreach (string line in lines)
        {
            // 1文字ずつ表示する演出
            dialogueText.text = "";
            foreach (char letter in line.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typeSpeed);
            }

            // 行が表示し終わったら2秒待機
            yield return new WaitForSeconds(waitTime);
        }
    }
}