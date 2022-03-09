using System.Collections;
using System.Collections.Generic;
using NotReaper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using NotReaper.UserInput;
using UnityEngine.InputSystem;
using NotReaper.Keyboard;

namespace NotReaper.UI
{
    public class ShortcutInfo : NRMenu
    {

        public Image BG;
        public CanvasGroup window;
        public GameObject version;
        public GameObject readme;
        public Image readmeUnderline;
        public bool isOpened = false;
        public ShortcutKeyboardHandler keyboard;

        private CanvasGroup canvas;


        public static ShortcutInfo Instance { get; private set; } = null;
        protected override void Awake()
        {
            base.Awake();
            if (Instance != null)
            {
                Debug.Log("ShortcutInfo already exists.");
                return;
            }
            Instance = this;
        }

        // Start is called before the first frame update
        private void Start()
        {
            canvas = GetComponent<CanvasGroup>();
            var t = transform;
            var position = t.localPosition;
            t.localPosition = new Vector3(0, position.y, position.z);

            TextMeshProUGUI versionLabel = version.GetComponent<TextMeshProUGUI>();
            var versionButton = version.GetComponent<Button>();
            versionLabel.text = "Version " + Application.version;
            versionButton.onClick.AddListener(() =>
            {
                Application.OpenURL("https://github.com/CircuitLord/NotReaper/releases");
            });
            var readmeButton = readme.GetComponent<Button>();
            readmeButton.onClick.AddListener(() =>
            {
                Application.OpenURL("https://github.com/CircuitLord/NotReaper/blob/master/README.md");
            });
            GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            gameObject.SetActive(false);
            keyboard.OnClose();
            isOpened = false;
        }

        public override void Show()
        {
            OnActivated();
            transform.position = Vector3.zero;
            canvas.alpha = 0f;
            canvas.DOFade(1.0f, 0.3f);
            readmeUnderline.color = NRSettings.config.leftColor;
            Transform camTrans = Camera.main.transform;

            //window.transform.position = new Vector3(0f, camTrans.position.y, transform.position.z);
            //window.transform.DOLocalMoveY(camTrans.position.y + 250f, 1.0f).SetEase(Ease.OutQuint);
            isOpened = true;
            keyboard.OnOpen();
        }

        public override void Hide()
        {
            keyboard.OnClose();
            isOpened = false;
            canvas.DOFade(0f, .3f).OnComplete(() =>
            {
                OnDeactivated();
            });
        }

        protected override void OnEscPressed(InputAction.CallbackContext context)
        {
            Hide();
        }
    }

}
