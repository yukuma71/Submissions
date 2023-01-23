using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI3Controllar : MonoBehaviour
{

    public CharactorControllar charactor1;
	public CharactorControllar charactor2;
	public CharactorControllar charactor3;
	public CharactorControllar charactor4;
	public CharactorControllar charactor5;
	public CharactorControllar charactor6;
	public CharactorControllar charactor7;
	public CharactorControllar charactor8;

	public CharactorsImage charactorsimage;
    public CharactorsNameText charactorsnametext;
    public HPUI hpui;
    public MPUI mpui;
    public SkillUI skillui;
    public SkillFlameUI skillflameui;
    public PlayerUI playerui;
    public ATKUI atkUi;

    private int dataretention;

	public void UI3BoardData(int masudata){//UI3Boardの情報変更
		switch(masudata){
				case 1://キャラクター（全体番号）
					charactorsimage.ChangeImage(charactor1.plnum,charactor1.jobnum);//キャラクターの画像
					charactorsnametext.JobText(charactor1.jobnum);//職業の名前変更
					hpui.HPUIChange(charactor1.maxhp,charactor1.hp);//hpバーの変更
					mpui.MPUIChange(charactor1.maxmp,charactor1.mp);//mpバーの変更
					skillui.ChangeSkillIcons(charactor1.jobnum);//スキルアイコンの変更
					skillflameui.SkillRetention(charactor1.jobnum);//スキルアイコン情報のscriptに送る
					playerui.PlayerUIChange(charactor1.plnum);//プレイヤー番号の表示変更
					atkUi.ATKPoworChange(charactor1.atk);//基礎攻撃力の表示変更
					break;
				case 2:
					charactorsimage.ChangeImage(charactor2.plnum,charactor2.jobnum);
					charactorsnametext.JobText(charactor2.jobnum);
					hpui.HPUIChange(charactor2.maxhp,charactor2.hp);
					mpui.MPUIChange(charactor2.maxmp,charactor2.mp);
					skillui.ChangeSkillIcons(charactor2.jobnum);
					skillflameui.SkillRetention(charactor2.jobnum);
					playerui.PlayerUIChange(charactor2.plnum);
					atkUi.ATKPoworChange(charactor2.atk);
					break;
				case 3:
					charactorsimage.ChangeImage(charactor3.plnum,charactor3.jobnum);
					charactorsnametext.JobText(charactor3.jobnum);
					hpui.HPUIChange(charactor3.maxhp,charactor3.hp);
					mpui.MPUIChange(charactor3.maxmp,charactor3.mp);
					skillui.ChangeSkillIcons(charactor3.jobnum);
					skillflameui.SkillRetention(charactor3.jobnum);
					playerui.PlayerUIChange(charactor3.plnum);
					atkUi.ATKPoworChange(charactor3.atk);
					break;
				case 4:
					charactorsimage.ChangeImage(charactor4.plnum,charactor4.jobnum);
					charactorsnametext.JobText(charactor4.jobnum);
					hpui.HPUIChange(charactor4.maxhp,charactor4.hp);
					mpui.MPUIChange(charactor4.maxmp,charactor4.mp);
					skillui.ChangeSkillIcons(charactor4.jobnum);
					skillflameui.SkillRetention(charactor4.jobnum);
					playerui.PlayerUIChange(charactor4.plnum);
					atkUi.ATKPoworChange(charactor4.atk);
					break;
				case 5:
					charactorsimage.ChangeImage(charactor5.plnum,charactor5.jobnum);
					charactorsnametext.JobText(charactor5.jobnum);
					hpui.HPUIChange(charactor5.maxhp,charactor5.hp);
					mpui.MPUIChange(charactor5.maxmp,charactor5.mp);
					skillui.ChangeSkillIcons(charactor5.jobnum);
					skillflameui.SkillRetention(charactor5.jobnum);
					playerui.PlayerUIChange(charactor5.plnum);
					atkUi.ATKPoworChange(charactor5.atk);
					break;
				case 6:
					charactorsimage.ChangeImage(charactor6.plnum,charactor6.jobnum);
					charactorsnametext.JobText(charactor6.jobnum);
					hpui.HPUIChange(charactor6.maxhp,charactor6.hp);
					mpui.MPUIChange(charactor6.maxmp,charactor6.mp);
					skillui.ChangeSkillIcons(charactor6.jobnum);
					skillflameui.SkillRetention(charactor6.jobnum);
					playerui.PlayerUIChange(charactor6.plnum);
					atkUi.ATKPoworChange(charactor6.atk);
					break;
				case 7:
					charactorsimage.ChangeImage(charactor7.plnum,charactor7.jobnum);
					charactorsnametext.JobText(charactor7.jobnum);
					hpui.HPUIChange(charactor7.maxhp,charactor7.hp);
					mpui.MPUIChange(charactor7.maxmp,charactor7.mp);
					skillui.ChangeSkillIcons(charactor7.jobnum);
					skillflameui.SkillRetention(charactor7.jobnum);
					playerui.PlayerUIChange(charactor7.plnum);
					atkUi.ATKPoworChange(charactor7.atk);
					break;
				case 8:
					charactorsimage.ChangeImage(charactor8.plnum,charactor8.jobnum);
					charactorsnametext.JobText(charactor8.jobnum);
					hpui.HPUIChange(charactor8.maxhp,charactor8.hp);
					mpui.MPUIChange(charactor8.maxmp,charactor8.mp);
					skillui.ChangeSkillIcons(charactor8.jobnum);
					skillflameui.SkillRetention(charactor8.jobnum);
					playerui.PlayerUIChange(charactor8.plnum);
					atkUi.ATKPoworChange(charactor8.atk);
					break;
				default:
					charactorsimage.ChangeImage(444,444);
					charactorsnametext.JobText(444);
					hpui.HPUIChange(444,444);
					mpui.MPUIChange(444,444);
					skillui.ChangeSkillIcons(444);
					skillflameui.SkillRetention(444);
					playerui.PlayerUIChange(444);
					atkUi.ATKPoworChange(444);
					break;
		}
		dataretention = masudata;
	}
	public void ClickData(){
		switch(dataretention){
				case 1://キャラクター（全体番号）
					charactorsimage.ChangeImage(charactor1.plnum,charactor1.jobnum);
					charactorsnametext.JobText(charactor1.jobnum);
					hpui.HPUIChange(charactor1.maxhp,charactor1.hp);
					mpui.MPUIChange(charactor1.maxmp,charactor1.mp);
					skillui.ChangeSkillIcons(charactor1.jobnum);
					skillflameui.SkillRetention(charactor1.jobnum);
					playerui.PlayerUIChange(charactor1.plnum);
					atkUi.ATKPoworChange(charactor1.atk);
					break;
				case 2:
					charactorsimage.ChangeImage(charactor2.plnum,charactor2.jobnum);
					charactorsnametext.JobText(charactor2.jobnum);
					hpui.HPUIChange(charactor2.maxhp,charactor2.hp);
					mpui.MPUIChange(charactor2.maxmp,charactor2.mp);
					skillui.ChangeSkillIcons(charactor2.jobnum);
					skillflameui.SkillRetention(charactor2.jobnum);
					playerui.PlayerUIChange(charactor2.plnum);
					atkUi.ATKPoworChange(charactor2.atk);
					break;
				case 3:
					charactorsimage.ChangeImage(charactor3.plnum,charactor3.jobnum);
					charactorsnametext.JobText(charactor3.jobnum);
					hpui.HPUIChange(charactor3.maxhp,charactor3.hp);
					mpui.MPUIChange(charactor3.maxmp,charactor3.mp);
					skillui.ChangeSkillIcons(charactor3.jobnum);
					skillflameui.SkillRetention(charactor3.jobnum);
					playerui.PlayerUIChange(charactor3.plnum);
					atkUi.ATKPoworChange(charactor3.atk);
					break;
				case 4:
					charactorsimage.ChangeImage(charactor4.plnum,charactor4.jobnum);
					charactorsnametext.JobText(charactor4.jobnum);
					hpui.HPUIChange(charactor4.maxhp,charactor4.hp);
					mpui.MPUIChange(charactor4.maxmp,charactor4.mp);
					skillui.ChangeSkillIcons(charactor4.jobnum);
					skillflameui.SkillRetention(charactor4.jobnum);
					playerui.PlayerUIChange(charactor4.plnum);
					atkUi.ATKPoworChange(charactor4.atk);
					break;
				case 5:
					charactorsimage.ChangeImage(charactor5.plnum,charactor5.jobnum);
					charactorsnametext.JobText(charactor5.jobnum);
					hpui.HPUIChange(charactor5.maxhp,charactor5.hp);
					mpui.MPUIChange(charactor5.maxmp,charactor5.mp);
					skillui.ChangeSkillIcons(charactor5.jobnum);
					skillflameui.SkillRetention(charactor5.jobnum);
					playerui.PlayerUIChange(charactor5.plnum);
					atkUi.ATKPoworChange(charactor5.atk);
					break;
				case 6:
					charactorsimage.ChangeImage(charactor6.plnum,charactor6.jobnum);
					charactorsnametext.JobText(charactor6.jobnum);
					hpui.HPUIChange(charactor6.maxhp,charactor6.hp);
					mpui.MPUIChange(charactor6.maxmp,charactor6.mp);
					skillui.ChangeSkillIcons(charactor6.jobnum);
					skillflameui.SkillRetention(charactor6.jobnum);
					playerui.PlayerUIChange(charactor6.plnum);
					atkUi.ATKPoworChange(charactor6.atk);
					break;
				case 7:
					charactorsimage.ChangeImage(charactor7.plnum,charactor7.jobnum);
					charactorsnametext.JobText(charactor7.jobnum);
					hpui.HPUIChange(charactor7.maxhp,charactor7.hp);
					mpui.MPUIChange(charactor7.maxmp,charactor7.mp);
					skillui.ChangeSkillIcons(charactor7.jobnum);
					skillflameui.SkillRetention(charactor7.jobnum);
					playerui.PlayerUIChange(charactor7.plnum);
					atkUi.ATKPoworChange(charactor7.atk);
					break;
				case 8:
					charactorsimage.ChangeImage(charactor8.plnum,charactor8.jobnum);
					charactorsnametext.JobText(charactor8.jobnum);
					hpui.HPUIChange(charactor8.maxhp,charactor8.hp);
					mpui.MPUIChange(charactor8.maxmp,charactor8.mp);
					skillui.ChangeSkillIcons(charactor8.jobnum);
					skillflameui.SkillRetention(charactor8.jobnum);
					playerui.PlayerUIChange(charactor8.plnum);
					atkUi.ATKPoworChange(charactor8.atk);
					break;
				default:
					charactorsimage.ChangeImage(444,444);
					charactorsnametext.JobText(444);
					hpui.HPUIChange(444,444);
					mpui.MPUIChange(444,444);
					skillui.ChangeSkillIcons(444);
					skillflameui.SkillRetention(444);
					playerui.PlayerUIChange(444);
					atkUi.ATKPoworChange(444);
					break;
		}
	}
	//マスデータが入っているかどうか見るため
	public int ReturnMasuData(){
		return dataretention;
	}
}
