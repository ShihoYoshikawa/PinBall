using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    //スクリーンのwidthの半分の値
    private int harfScreenWidth;

    // Use this for initialization
    void Start()
    {
        //HinjiJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        harfScreenWidth =
            Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityエディタ上ではない場合は、タッチでフリッパーの操作を行う
        if (!Application.isEditor)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.position.x < harfScreenWidth && touch.phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                else if (touch.position.x > harfScreenWidth && touch.phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                else if (touch.position.x < harfScreenWidth && touch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
                else if (touch.position.x > harfScreenWidth && touch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                {
                    SetAngle(this.defaultAngle);
                }
            }
        }
        else
        {
            //左矢印キーを押した時左フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右矢印キーを押した時右フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //矢印キー離された時フリッパーを元に戻す
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                SetAngle(this.defaultAngle);
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}