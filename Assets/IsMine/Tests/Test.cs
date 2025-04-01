using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace IsMine.Tests
{
    public class Test
    {
        public int diem {get;set;}
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void suadiem(int d) 
        {
            diem=d;
        }
        public int xemdiem()
        {
            return diem;
        }

        
        [Test]
        public void TestScore()
        {
            Test a = new Test();
            a.suadiem(10);
            int x = a.xemdiem();
            Assert.AreEqual(10, x);
        }

        [Test]
        public void TestCongA()
        {
            var obj = new kkk();
            Debug.Log("kq: " + obj.CongA(5,5));
            Assert.AreEqual(10, obj.CongA(5,5));
        }

        [Test]
        public void TestTru()
        {
            var obj = new kkk();
            Debug.Log("kq: " + obj.TruA(10, 15));
            Assert.AreEqual(15, obj.TruA(10, 15));
        }
        
        [Test]
        public void NhanA()
        {
            var obj = new kkk();
            Debug.Log("kq: " + obj.NhanA(2, 2));
            Assert.AreEqual(4, obj.NhanA(2, 2));
        }
        
        [Test]
        public void TestChia()
        {
            var obj = new kkk();
            Debug.Log("kq: " + obj.TestChia(10, 15));
            Assert.AreEqual(15, obj.TestChia(10, 15));
        }
        
     

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
