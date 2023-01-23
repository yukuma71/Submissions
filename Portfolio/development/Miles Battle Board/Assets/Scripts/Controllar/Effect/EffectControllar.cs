using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControllar : MonoBehaviour
{
    public SoundEffectControllar soundeffectcontrollar;

    public GameObject slasheffect;
    public GameObject bloweffect;
    public GameObject powerslasheffect;
    public GameObject shieldeffect;
    public GameObject healeffect;
    public GameObject spelleffect;

    //攻撃ボタン用エフェクト
    public void AttackEffect(Vector3 pos,int jobs)
    {
        if(jobs == 1 || jobs == 2){//職業が戦士 or 騎士の時
            Slash(pos);
        }
        else if(jobs == 3 || jobs == 4){//職業が魔女 or 僧侶の時
            Blow(pos);
        }
    }

    //斬撃エフェクト
    private void Slash(Vector3 pos){
    	Instantiate(slasheffect, new Vector3(pos.x, pos.y, 0), Quaternion.identity);//エフェクト配置
        soundeffectcontrollar.SlashSound();//SE
    	Invoke("DeleteEffects", 1f);//オブジェクト削除
    }

    //打撃エフェクト
    private void Blow(Vector3 pos)
    {
        Instantiate(bloweffect, new Vector3(pos.x, pos.y, 0), Quaternion.identity);//エフェクト配置
        soundeffectcontrollar.BlowSound();//SE
        Invoke("DeleteEffects", 1f);//オブジェクト削除
    }
    //強斬撃エフェクト
    public void PowerSlashEffect(Vector3 pos, int flag){
        if(flag == 1){//右
            Quaternion rotation = Quaternion.Euler(0f, 0f, -90f);
            Instantiate(powerslasheffect, new Vector3(pos.x, pos.y, 0), rotation);//エフェクト配置
        }
        if(flag == 2){//下
            Quaternion rotation = Quaternion.Euler(0f, 0f, 180f);
            Instantiate(powerslasheffect, new Vector3(pos.x, pos.y, 0), rotation);//エフェクト配置
        }
        if(flag == 3){//左
            Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);
            Instantiate(powerslasheffect, new Vector3(pos.x, pos.y, 0), rotation);//エフェクト配置
        }
        if (flag == 4){//上
            Instantiate(powerslasheffect, new Vector3(pos.x, pos.y, 0), Quaternion.identity);//エフェクト配置
        }
        soundeffectcontrollar.PowerSlashSound();//SE
        Invoke("DeleteEffects", 1f);//オブジェクト削除
    }

    //盾エフェクト
    public void ShieldEffect(Vector3 pos)
    {
        Instantiate(shieldeffect, new Vector3(pos.x, pos.y, 0), Quaternion.identity);//エフェクト配置
        soundeffectcontrollar.ShieldSound();//SE
        Invoke("DeleteEffects", 1.2f);//オブジェクト削除
    }

    //回復エフェクト
    public void HealEffect(Vector3 pos)
    {
        Instantiate(healeffect, new Vector3(pos.x, pos.y + 0.1f, 0), Quaternion.identity);//エフェクト配置
        soundeffectcontrollar.HealSound();//SE
        Invoke("DeleteEffects", 1f);//オブジェクト削除
    }

    //攻撃魔法エフェクト
    public void SpellEffect(Vector3 pos)
    {
        Instantiate(spelleffect, new Vector3(pos.x, pos.y, 0), Quaternion.identity);//エフェクト配置
        soundeffectcontrollar.SpellSound();//SE
        Invoke("DeleteEffects", 1f);//オブジェクト削除
    }

    //エフェクト削除関数
    private void DeleteEffects(){
    	//クローン削除
        var clones = GameObject.FindGameObjectsWithTag ("effect");
		foreach(var clone in clones){
    		Destroy(clone);
		}
    }
}
