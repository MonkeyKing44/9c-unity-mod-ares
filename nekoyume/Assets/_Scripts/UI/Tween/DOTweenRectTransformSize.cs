﻿using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Nekoyume.UI.Tween
{
    public class DOTweenRectTransformSize : DOTweenBase
    {
        public float multiplier = 1.2f;

        private Vector2 _beginValue;
        private Vector2 _endValue;
        private RectTransform _rectTransform;

        protected override void Awake()
        {
            base.Awake();
            _rectTransform = GetComponent<RectTransform>();
            _beginValue = _rectTransform.sizeDelta;
            _endValue = _beginValue * multiplier;
            if (startWithPlay)
            {
                currentTween = _rectTransform.DOSizeDelta(_beginValue, 0.0f);
            }
        }

        public override void PlayForward()
        {
            currentTween = _rectTransform.DOSizeDelta(_beginValue, 0.0f);
            currentTween = _rectTransform.DOSizeDelta(_endValue, duration);
            if (TweenType.Repeat == tweenType)
            {
                currentTween = SetEase().OnComplete(PlayForward);
            }
            else if (TweenType.PingPongOnce == tweenType || TweenType.PingPongRepeat == tweenType)
            {
                currentTween = SetEase().OnComplete(PlayReverse);
            }
            else
            {
                currentTween = SetEase().OnComplete(OnComplete);
            }
        }

        public override void PlayReverse()
        {
            currentTween = _rectTransform.DOSizeDelta(_endValue, 0.0f);
            currentTween = _rectTransform.DOSizeDelta(_beginValue, duration);
            if (TweenType.PingPongRepeat == tweenType)
            {
                currentTween = SetEase().OnComplete(PlayForward);
            }
            else
            {
                currentTween = SetEase().OnComplete(OnComplete);
            }
        }

        public override void PlayRepeat()
        {
            PlayForward();
        }

        public override void PlayPingPongOnce()
        {
            PlayForward();
        }


        public override void PlayPingPongRepeat()
        {
            PlayForward();
        }
    }
}
