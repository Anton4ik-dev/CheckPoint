using UnityEngine;
using UnityEngine.EventSystems;

namespace Draggables
{
    public class MarkTrigger : ADraggable, IPointerDownHandler
    {
        [SerializeField] private bool _isRight;
        private PassportTrigger _passportTrigger;

        public void OnPointerDown(PointerEventData eventData)
        {
            if(_passportTrigger != null)
            {
                _passportTrigger.IsMarked = true;
                _passportTrigger.IsRight = _isRight;
            }
        }

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
    }
}