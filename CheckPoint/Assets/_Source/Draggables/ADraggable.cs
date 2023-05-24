using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Draggables
{
    public abstract class ADraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] protected LayerMask _triggerLayer;
        protected bool _isDragging;
        protected LayerService _layerService;

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
        }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }
    }
}