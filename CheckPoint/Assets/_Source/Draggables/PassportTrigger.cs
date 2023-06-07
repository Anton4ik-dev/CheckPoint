using Guest;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Draggables
{
    public class PassportTrigger : ADraggable
    {
        [SerializeField] private Image _markPoint;
        public bool IsRight { get; set; }
        public bool IsMarked { get; set; }
        public Image MarkPoint { get => _markPoint; private set { } }
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
                _markPoint.color = _markPoint.defaultMaterial.color;
                if(IsRight)
                    _soundService.PlayClip(_soundService.Sounds.RightClip);
                else
                    _soundService.PlayClip(_soundService.Sounds.FalseClip);
                _guestView.ExitGuest(IsRight);
            }
        }
    }
}