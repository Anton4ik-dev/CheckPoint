using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button gameButton;
        [SerializeField] private GameObject gamePanel;
        [SerializeField] private UISwitcher uISwitcher;

        private void Start()
        {
            Bind();
        }

        private void Bind()
        {
            gameButton.onClick.AddListener(() => uISwitcher.TurnOnPanel(gamePanel));
        }
    }
}