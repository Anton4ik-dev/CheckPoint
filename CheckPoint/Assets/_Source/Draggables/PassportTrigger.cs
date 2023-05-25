using Guest;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Draggables
{
    public class PassportTrigger : ADraggable
    {
        public bool IsRight { get; set; }
        public bool IsMarked { get; set; }
        private GuestView _guestView;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _triggerLayer))
            {
                if (collision.TryGetComponent(out GuestView guestView))
                    _guestView = guestView;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _triggerLayer))
            {
                if (collision.TryGetComponent(out GuestView guestView))
                    _guestView = null;
            }
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if(_guestView != null && IsMarked)
            {
                IsMarked = false;
                _guestView.ExitGuest(IsRight);
            }
        }
    }
}