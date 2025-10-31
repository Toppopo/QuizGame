using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSet : MonoBehaviour
{
    [SerializeField] private List<GameObject> Bobis = new List<GameObject>();
    [SerializeField] private List<GameObject> allMarks = new List<GameObject>();

    float fadeSpeed = 0.1f;

    GameStart gameStart;
    private void Awake()
    {
        gameStart = GameObject.Find("title").GetComponent<GameStart>();
        // markを収集
        allMarks.Clear();
        foreach (GameObject parent in Bobis)
        {
            if (parent != null)
                GetAllChildren(parent.transform);
        }

        // 最初は全部透明に
        SetAllAlpha(0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStart.Finish)
        {
            RevealOne();
        }
    }

    private void GetAllChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name.StartsWith("mark_"))
            {
                allMarks.Add(child.gameObject);
            }
            GetAllChildren(child);
        }
    }
    private void SetAllAlpha(float alpha)
    {
        foreach (GameObject obj in allMarks)
        {
            if (obj == null) continue;
            SpriteRenderer spr = obj.GetComponent<SpriteRenderer>();
            if (spr != null)
            {
                Color c = spr.color;
                c.a = alpha;
                spr.color = c;
            }
        }
    }
    private void RevealOne()
    {
        List<GameObject> hiddenMarks = new List<GameObject>();//まだフェードインしてないもの
        foreach (GameObject obj in allMarks)
        {
            if (obj == null) continue;
            SpriteRenderer spr = obj.GetComponent<SpriteRenderer>();
            if (spr != null && spr.color.a < 1f)
            {
                hiddenMarks.Add(obj);
            }
        }

        GameObject target = hiddenMarks[Random.Range(0, hiddenMarks.Count)];//ランダムに一枚
        SpriteRenderer targetSpr = target.GetComponent<SpriteRenderer>();//フェードインさせるSpriteRender

        StartCoroutine(FadeIn(targetSpr));
    }
    IEnumerator FadeIn(SpriteRenderer spr)
    {
        float alpha = spr.color.a;
        while (alpha < 1f)
        {
            alpha += 0.1f;
            Color c = spr.color;
            c.a = Mathf.Min(1f, alpha);
            spr.color = c;
            yield return new WaitForSeconds(fadeSpeed);//フェードインの速度
        }
    }
}
