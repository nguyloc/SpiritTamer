using System.Collections;
using System.Collections.Generic;
using IsMine.TestPlayMode.TestSource;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestPlay
{
    // Test UI button click
    
    [UnitySetUp]
    public IEnumerator Setup()
    {
        SceneManager.LoadScene("StartScene");
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator ButtonClick_ChangesScene()
    {
        // lay scene StartScene
        GameObject gameObject = GameObject.Find("Canvas/StartButton");
        
        // kiem tra xem gameObject co ton tai khong
        Button startButton = gameObject.GetComponent<Button>();
        
        // Gia lap su kien click
        startButton.onClick.Invoke();
        
        // doi cho scene moi duoc load
        yield return new WaitForSeconds(3f);
        
        // kiem tra xem scene da duoc load chua
        Assert.AreEqual("SampleScene", SceneManager.GetActiveScene().name);
        
        yield return new WaitForSeconds(1f);
    }
    
    // Test Old movement
    public class MockInput : IInputProvider
    {
        public float h;
        public float v;

        public float GetHorizontal() => h;
        public float GetVertical() => v;
    }

    public class MovementTest
    {
        [UnityTest]
        public IEnumerator MovesForwardWithWKey()
        {
            // Tạo object
            var go = new GameObject();
            var move = go.AddComponent<Movement>();

            // Tạo mock input
            var input = new MockInput { h = 0, v = 1 }; // nhấn W
            move.input = input;

            Vector3 before = go.transform.position;

            // Cho chạy Update()
            yield return null;

            Vector3 after = go.transform.position;
            Assert.Greater(after.z, before.z); // di chuyển về phía trước
        }
    }
}
