using UnityEngine;
using UnityEngine.UI;

namespace Templates
{
    public class PhotoTemplate : MonoBehaviour
    {
        [SerializeField] private Image _face;
        [SerializeField] private Image _glasses;
        [SerializeField] private Image _haircut;
        [SerializeField] private Image _mouth;
        [SerializeField] private Image _beard;

        public Sprite Face
        {
            get => _face.sprite;
            set
            {
                _face.sprite = value;
            }
        }

        public Sprite Glasses
        {
            get => _glasses.sprite;
            set
            {
                _glasses.sprite = value;
            }
        }

        public Sprite Haircut
        {
            get => _haircut.sprite;
            set
            {
                _haircut.sprite = value;
            }
        }

        public Sprite Mouth
        {
            get => _mouth.sprite;
            set
            {
                _mouth.sprite = value;
            }
        }

        public Sprite Beard
        {
            get => _beard.sprite;
            set
            {
                _beard.sprite = value;
            }
        }
    }
}