using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailsNameUI : MonoBehaviour
{
    private Text targetText;

    public void ChangeSkillName(int jobnum){
        this.targetText = this.GetComponent<Text>();
        switch(jobnum){//スキルの名前を職業に合わせて変更する
            case 1://キャラクター（全体番号)
                this.targetText.text = "かぶとわり";
                break;
            case 2:
                this.targetText.text = "ボディーシールド";
                break;
            case 3:
                this.targetText.text = "ヒール";
                break;
            case 4:
                this.targetText.text = "エクスプロージョン";
                break;
            default:
                this.targetText.text = "--------";
                break;
        }
    }
}
