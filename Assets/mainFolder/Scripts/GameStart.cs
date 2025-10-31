using System.Collections;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    SpriteRenderer spr;

    bool starting;//ゲーム開始したか
    float alpha;//色のアルファ値
    float speed;//↑の減少速度

    private bool finish;
    public bool Finish
    {
        get { return finish; }
    }

    [SerializeField] GameObject inputField;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = Color.black;
        starting = false;
        alpha = 1.0f;
        speed = 0.4f;

        finish = false;
        inputField.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !starting)
        {
            StartCoroutine("fadeOut");
        }
    }

    IEnumerator fadeOut()
    {
        starting = true;
        while(alpha > 0f)
        {
            alpha -= speed * Time.deltaTime;
            spr.color = new Color(0f, 0f, 0f, alpha);
            yield return null;
        }

        alpha = 0f;
        spr.color = new Color(0f, 0f, 0f, alpha);
        finish = true;
        inputField.SetActive(true);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
