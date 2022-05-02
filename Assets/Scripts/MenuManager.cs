using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        public TMP_InputField playerNameField;
        public TextMeshProUGUI sliderText;
        public Slider collectableSlider;

        public TextMeshProUGUI errorText;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            sliderText.text = collectableSlider.value +"";
        }

       
        public void StartGame()
        {
            if (playerNameField.text.Length > 0)
            {
                DataManager.Instance.PlayerName = playerNameField.text;
                DataManager.Instance.NumberOfCollectables = (int)collectableSlider.value;
                SceneManager.LoadScene(1);
                
            }
            else
            {
                errorText.gameObject.SetActive(true);
            }
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}