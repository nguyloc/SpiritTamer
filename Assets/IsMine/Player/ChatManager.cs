using System.Collections.Generic;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace IsMine.Player
{
    public class ChatManager : NetworkBehaviour
    {
        [Header("UI Components")]
        public GameObject chatPanel;
        public Button chatButton;
        public TMP_InputField inputField;
        public Button sendButton;
        public TextMeshProUGUI chatText;

        private List<string> messages = new List<string>();

        private string playerName; // Tên người chơi
        private Color playerColor; // Màu ngẫu nhiên của người chơi

        private void Start()
        {
            if (chatPanel == null || chatButton == null || inputField == null || sendButton == null || chatText == null)
            {
                Debug.LogError("ChatManager: Một hoặc nhiều UI Elements chưa được gán trong Inspector!");
                return;
            }

            chatPanel.SetActive(false);

            chatButton.onClick.AddListener(ToggleChatPanel);
            sendButton.onClick.AddListener(SendMessage);

            // Random tên và màu
            playerName = "Player" + Random.Range(1, 1000);
            playerColor = new Color(Random.value, Random.value, Random.value);
        }

        private void ToggleChatPanel()
        {
            chatPanel.SetActive(!chatPanel.activeSelf);
        }

        private void SendMessage()
        {
            if (!string.IsNullOrEmpty(inputField.text))
            {
                string message = inputField.text;
                inputField.text = "";

                // Gửi tin nhắn với tên và màu
                SendChatMessageRpc($"<color=#{ColorUtility.ToHtmlStringRGB(playerColor)}>[{playerName}]</color>: {message}");
            }
        }

        [Rpc(RpcSources.All, RpcTargets.All)]
        private void SendChatMessageRpc(string message)
        {
            messages.Add(message);
            UpdateChatDisplay();
        }

        private void UpdateChatDisplay()
        {
            chatText.text = "";

            foreach (var msg in messages)
            {
                chatText.text += msg + "\n";
            }
        }
    }
}