using Guest;
using UnityEngine;

namespace Draggables
{
    public class PassportTrigger : ADraggable
    {
        public bool IsRight { get; set; }
        public bool IsMarked { get; set; }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(_layerService.CheckLayersEquality(collision.gameObject.layer, _triggerLayer) && !_isDragging)
            {
                if (collision.TryGetComponent(out GuestView guestView) && IsMarked)
                {
                    IsMarked = false;
                    guestView.ExitGuest(IsRight);
                }
            }
        }
    }
}