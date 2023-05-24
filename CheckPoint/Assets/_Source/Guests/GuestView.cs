using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

namespace Guest
{
    public class GuestView : MonoBehaviour
    {
        [SerializeField] private Transform _guest;
        [SerializeField] private Transform _guestLeftAnchor;
        [SerializeField] private Transform _guestCenterAnchor;
        [SerializeField] private Transform _guestRightAnchor;
        [SerializeField] private Transform _passport;
        [SerializeField] private Transform _passportTopAnchor;
        [SerializeField] private Transform _passportBottomAnchor;
        [SerializeField] private float _smoothTime;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private int _addableScore;

        private GuestModel _guestModel;

        private void Start()
        {
            EnterGuest();
        }

        public void ExitGuest(bool isRight)
        {
            _passport.position = _passportTopAnchor.position;
            ChangeScore(isRight);
            if (isRight)
                _guest.DOMoveX(_guestRightAnchor.position.x, _smoothTime).OnComplete(EnterGuest);
            else
                _guest.DOMoveX(_guestLeftAnchor.position.x, _smoothTime).OnComplete(EnterGuest);
        }

        private void EnterGuest()
        {
            _guest.position = _guestLeftAnchor.position;
            _passport.position = _passportTopAnchor.position;
            _guestModel.OnGuestEnter?.Invoke();
            _guest.DOMoveX(_guestCenterAnchor.position.x, _smoothTime);
            _passport.DOMoveY(_passportBottomAnchor.position.y, _smoothTime);
        }

        private void ChangeScore(bool isRight)
        {
            if (_guestModel.OnGuestExit(isRight))
                _score.text = $"{int.Parse(_score.text) + _addableScore}";
            else
                _score.text = $"{int.Parse(_score.text) - _addableScore}";
            if (int.Parse(_score.text) < 0)
                _score.text = $"{0}";
        }

        [Inject]
        public void Construct(GuestModel guestModel)
        {
            _guestModel = guestModel;
        }
    }
}