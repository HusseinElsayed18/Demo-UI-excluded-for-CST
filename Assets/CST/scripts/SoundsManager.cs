using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CST
{
    public class SoundsManager : MonoBehaviour
    {
        AudioSource bgMusic, btnEffects;
        [SerializeField] AudioClip bgmusicClip, clickEffect, matchEffect, misMatchEffect;
        private void Awake()
        {
            bgMusic = gameObject.AddComponent<AudioSource>();
            btnEffects = gameObject.AddComponent<AudioSource>();
        }
        private void Start()
        {
            InitBackgroundMusic(bgMusic, bgmusicClip);
            EventsManager.onBtnPlayClick += BtnClick;
        }
        public void InitBackgroundMusic(AudioSource source, AudioClip clip)
        {
            source.clip = clip;
            source.Play();
            source.loop = true;
        }
        public void BtnClick()
        {
            btnEffects.clip = clickEffect;
            btnEffects.Play();
        }
        public void MatchEffect()
        {
            btnEffects.clip = matchEffect;
            btnEffects.Play();
        }
        public void MisMatchEffect()
        {
            btnEffects.clip = misMatchEffect;
            btnEffects.Play();
        }
    }
}

