using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDetailsTextUI : MonoBehaviour
{
    private Text targetText;

    public void ChangeSkillText(int jobnum){
        this.targetText = this.GetComponent<Text>();
        switch (jobnum)
        {
            case 1://キャラクター（全体番号)
                this.targetText.text = "効果 敵キャラクターを切りつけ、\n　　 30ダメージ与える。\n選択範囲 上下左右1マス\n効果範囲 縦2マス(最大2体)\n最大使用回数 3回";
                break;
            case 2:
                this.targetText.text = "効果 次の自分のターンまで、自分\n　　 に対してのダメージを50%\n　　 軽減する。\n選択範囲 自分の位置1マス\n効果範囲 自分の位置1マス\n最大使用回数 4回";
                break;
            case 3:
                this.targetText.text = "効果 回復魔法で味方キャラクター\n     のHPを50回復する。\n選択範囲 自分の周囲1マス\n効果範囲 1マス\n最大使用回数 2回";
                break;
            case 4:
                this.targetText.text = "効果 爆発魔法で敵キャラクターを\n     攻撃し、20ダメージ与える。\n選択範囲 自分の周囲3マス\n効果範囲 3×3マス\n最大使用回数 3回";
                break;
            default:
                this.targetText.text = "--------";
                break;
        }
    }
}