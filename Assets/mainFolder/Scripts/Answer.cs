using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text displayText;

    [SerializeField] string correctAnswer = "���";

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
        // Enter�L�[�Ŕ���
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    // ���͂��n�܂����u�ԂɌĂ΂��
    private void OnInputChanged(string currentText)
    {
        displayText.color = Color.black;

        if (!hasStartedTyping && !string.IsNullOrEmpty(currentText))
        {
            hasStartedTyping = true;
            Debug.Log("���͊J�n�I");
            StartTypingProcess();
        }
    }

    private void StartTypingProcess()
    {
        // ���͂��J�n�����u�Ԃɂ�肽������������
        Debug.Log("�v���C���[����������͂��n�߂܂����I");
        // ��F�A�j���[�V�����J�n�ABGM�Đ��Ȃ�
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
            Debug.Log("�s�����c");
            displayText.color = Color.red;
        }
    }
}
