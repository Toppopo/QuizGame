using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text displayText;

    [SerializeField] string correctAnswer = "りんご";

    private bool hasStartedTyping = false;

    [SerializeField] GameObject screenParent;
    [SerializeField] GameObject correctParent;

    private void Start()
    {
        correctParent.SetActive(false);
        inputField.onValueChanged.AddListener(OnInputChanged);
    }

    private void Update()
    {
        // Enterキーで判定
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    // 入力が始まった瞬間に呼ばれる
    private void OnInputChanged(string currentText)
    {
        displayText.color = Color.black;

        if (!hasStartedTyping && !string.IsNullOrEmpty(currentText))
        {
            hasStartedTyping = true;
            Debug.Log("入力開始！");
            StartTypingProcess();
        }
    }

    private void StartTypingProcess()
    {
        // 入力を開始した瞬間にやりたい処理を書く
        Debug.Log("プレイヤーが文字を入力し始めました！");
        // 例：アニメーション開始、BGM再生など
    }

    private void CheckAnswer()
    {
        string userInput = inputField.text.Trim();
        displayText.text = userInput;

        if (userInput == correctAnswer)
        {
            screenParent.SetActive(false);
            correctParent.SetActive(true);
            displayText.color = Color.green;
        }
        else
        {
            Debug.Log("不正解…");
            displayText.color = Color.red;
        }
    }
}
