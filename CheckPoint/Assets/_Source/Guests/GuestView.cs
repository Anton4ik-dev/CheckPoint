using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Guest
{
    public class GuestView : MonoBehaviour
    {
        [SerializeField] private Transform _guestLeftAnchor;
        [SerializeField] private Transform _guestCenterAnchor;
        [SerializeField] private Transform _guestRightAnchor;
        [SerializeField] private Transform _passport;
        [SerializeField] private Transform _passportTopAnchor;
        [SerializeField] private Transform _passportBottomAnchor;
        [SerializeField] private float _smoothTime;

        private GuestModel _guestModel;

        private void Start()
        {
            EnterGuest();
        }

        public void ExitGuest(bool isRight)
        {
            _passport.position = _passportTopAnchor.position;
            if (isRight)
                transform.DOMoveX(_guestRightAnchor.position.x, _smoothTime).OnComplete(EnterGuest);
            else
                transform.DOMoveX(_guestLeftAnchor.position.x, _smoothTime).OnComplete(EnterGuest);
        }

        private void EnterGuest()
        {
            transform.position = _guestLeftAnchor.position;
            _passport.position = _passportTopAnchor.position;
            _guestModel.OnGuestEnter?.Invoke();
            transform.DOMoveX(_guestCenterAnchor.position.x, _smoothTime);
            _passport.DOMoveY(_passportBottomAnchor.position.y, _smoothTime);
        }

        [Inject]
        public void Construct(GuestModel guestModel)
        {
            _guestModel = guestModel;
        }
    }
}