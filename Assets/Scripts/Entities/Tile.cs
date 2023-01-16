using DG.Tweening;
using UnityEngine;

namespace Entities {

    public class Tile : MonoBehaviour {

        [SerializeField] private int value;
        public int Value => value;

        public void Initialize(int value) {
            this.value = value;
        }

        public void Appear() =>
            transform.DOScale(new Vector3(.5f, 1f, .5f), .1f);

        public void Move() =>
            transform.DOMove(transform.parent.position + transform.parent.up, .2f);

        public void Merge() {
            DOTween.Sequence()
                .Append(transform.DOMove(transform.parent.position + transform.parent.up, .2f))
                .Append(transform.DOScale(0, .1f))
                .OnComplete(
                    () => { Destroy(gameObject); }
                );
        }

    }

}