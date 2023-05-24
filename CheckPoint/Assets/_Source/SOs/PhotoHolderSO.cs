using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PhotoHolderSO", menuName = "SO/PhotoHolder", order = 0)]
    public class PhotoHolderSO : ScriptableObject
    {
        [SerializeField] private List<Sprite> _faceSprites;
        [SerializeField] private List<Sprite> _glassesSprites;
        [SerializeField] private List<Sprite> _haircutSprites;
        [SerializeField] private List<Sprite> _mouthSprites;
        [SerializeField] private List<Sprite> _beardSprites;

        public List<Sprite> FaceSprites { get => _faceSprites; private set { } }
        public List<Sprite> GlassesSprites { get => _glassesSprites; private set { } }
        public List<Sprite> HaircutSprites { get => _haircutSprites; private set { } }
        public List<Sprite> MouthSprites { get => _mouthSprites; private set { } }
        public List<Sprite> BeardSprites { get => _beardSprites; private set { } }
    }
}