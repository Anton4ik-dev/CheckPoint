using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Draggables
{
    public class MarkTrigger : ADraggable, IPointerDownHandler
    {
        [SerializeField] private bool _isRight;
        [SerializeField] private Transform _markPosition;
        [SerializeField] private float _smoothTime;
        [SerializeField] private Color _markColor;
        private PassportTrigger _passportTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _triggerLayer))
            {
                if (collision.TryGetComponent(out PassportTrigger passportTrigger))
                    _passportTrigger = passportTrigger;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _triggerLayer))
            {
                if (collision.TryGetComponent(out PassportTrigger passportTrigger))
                    _passportTrigger = null;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_passportTrigger != null)
            {
                _passportTrigger.IsMarked = true;
                _passportTrigger.MarkPoint.color = _markColor;
                _passportTrigger.IsRight = _isRight;
                transform.DOMove(_markPosition.position, _smoothTime);
                _soundService.PlayClip(_soundService.Sounds.MarkClip);
            }
        }
    }
}