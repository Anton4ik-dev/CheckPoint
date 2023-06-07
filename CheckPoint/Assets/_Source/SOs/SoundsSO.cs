using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundsSO", menuName = "SO/Sounds", order = 0)]
    public class SoundsSO : ScriptableObject
    {
        [SerializeField] private AudioClip _falseClip;
        [SerializeField] private AudioClip _rightClip;
        [SerializeField] private AudioClip _markClip;

        public AudioClip FalseClip { get => _falseClip; private set { } }
        public AudioClip RightClip { get => _rightClip; private set { } }
        public AudioClip MarkClip { get => _markClip; private set { } }
    }
}