using UnityEngine;
using UnityEngine.SceneManagement;

namespace IsMine.SceneManager
{
    public class ChangeScene : MonoBehaviour
    {
        public void ChangeSceneTo()
        {
            // Load the new scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
