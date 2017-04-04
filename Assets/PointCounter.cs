using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    // Materialを入れる
    Material myMaterial;

    // Emissionの最小値
    private float minEmission = 0.3f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度
    private int degree = 0;
    //発光速度
    private int speed = 10;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;
    //得点を表示するテキスト
    private Text pointText;


    // Use this for initialization
    void Start()
    {
        //シーン中のPointTextオブジェクトを取得
        GameObject pointTextObject = GameObject.Find("PointText");
        this.pointText = pointTextObject.GetComponent<Text>();
    }


    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        CountPoint();
    }

    // 得点を数える関数
    void CountPoint()
    {
        int point = int.Parse(pointText.text);
        if (tag == "SmallStarTag")
        {
            point += 10;
            pointText.text = point.ToString();
        }
        else if (tag == "LargeStarTag")
        {
            point += 20;
            pointText.text = point.ToString();
        }
        else if (tag == "SmallCloudTag")
        {
            point -= 5;
            pointText.text = point.ToString();
        }
        else if (tag == "LargeCloudTag")
        {
            point -= 10;
            pointText.text = point.ToString();
        }
    }
}