using System;
using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour {

    [SerializeField] private int _value;
    public int Value => _value;

    public void Initialize(int value) {
        _value = value;
    }

    public void Appear() =>
        transform.DOScale(new Vector3(.5f, 1f, .5f), .5f);

    public void Move() =>
        transform.DOMove(transform.parent.position + transform.parent.up, .3f);

    public void Merge() {
        DOTween.Sequence()
            .Append(transform.DOMove(transform.parent.position + transform.parent.up, .3f))
            .Append(transform.DOScale(0, .1f))
            .OnComplete(
                () => { Destroy(gameObject); }
                );
    }

}