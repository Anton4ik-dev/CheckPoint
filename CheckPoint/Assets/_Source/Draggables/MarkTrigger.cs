using UnityEngine;

namespace Draggables
{
    public class MarkTrigger : ADraggable
    {
        [SerializeField] private bool _isRight;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_layerService.CheckLayersEquality(collision.gameObject.layer, _triggerLayer) && !_isDragging)
            {
                if (collision.TryGetComponent(out PassportTrigger passportTrigger))
                {
                    passportTrigger.IsMarked = true;
                    passportTrigger.IsRight = _isRight;
                }
            }
        }
    }
}