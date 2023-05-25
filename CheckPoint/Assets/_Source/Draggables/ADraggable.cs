using Services;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Draggables
{
    public abstract class ADraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] protected LayerMask _triggerLayer;
        protected LayerService _layerService;

        public virtual void OnBeginDrag(PointerEventData eventData) { }

        public virtual void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public virtual void OnEndDrag(PointerEventData eventData) { }

        [Inject]
        public void Construct(LayerService layerService)
        {
            _layerService = layerService;
        }
    }
}