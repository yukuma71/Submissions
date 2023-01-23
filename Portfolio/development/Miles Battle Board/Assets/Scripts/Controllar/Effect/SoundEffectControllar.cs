using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectControllar : MonoBehaviour
{
    public AudioClip slash_sound;
    public AudioClip blow_sound;
    public AudioClip powerslash_sound;
    public AudioClip shield_sound;
    public AudioClip heal_sound;
    public AudioClip spell_sound;

    AudioSource audioSource;

    void Start(){
		audioSource = GetComponent<AudioSource>();
    } 
    //斬撃音
	public void SlashSound(){
		audioSource.PlayOneShot(slash_sound);
    }
    //打撃音
    public void BlowSound()
    {
        audioSource.PlayOneShot(blow_sound);
    }
    //強斬撃音
    public void PowerSlashSound()
    {
        audioSource.PlayOneShot(powerslash_sound);
    }
    //盾音
    public void ShieldSound()
    {
        audioSource.PlayOneShot(shield_sound);
    }
    //回復音
    public void HealSound()
    {
        audioSource.PlayOneShot(heal_sound);
    }
    //攻撃魔法音
    public void SpellSound()
    {
        audioSource.PlayOneShot(spell_sound);
    }
}
