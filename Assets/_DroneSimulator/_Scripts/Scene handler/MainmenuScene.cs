using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alpha
{
    public class MainmenuScene : MonoBehaviour
    {
        #region Variables
        [SerializeField] GameObject creditsPanel;
        [SerializeField] GameObject settingsPanel;
        #endregion

        #region UnityMethods
        void Start()
        {

        }

        void Update()
        {

        }
        #endregion

        #region PublicMethods
        public void LoadMainGame()
        {
            SceneManager.LoadScene(1);
        }
        public void ShowCredits()
        {
            creditsPanel.SetActive(true);
        }
        public void ShowSettingPanel()
        {
            settingsPanel.SetActive(true);
        }
        public void QuitGame()
        {
            Application.Quit(); 
        }

        #endregion

        #region PrivateMethods

        #endregion

        #region GameEventListeners

        #endregion
    }
}