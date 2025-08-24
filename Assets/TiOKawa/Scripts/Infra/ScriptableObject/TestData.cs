using System;
using System.Collections.Generic;
using TiOKawa.Scripts.Infra.Schema;
using UnityEngine;

namespace TiOKawa.Scripts.Infra.ScriptableObject
{
    [CreateAssetMenu(fileName = "TestData", menuName = "ScriptableObject/TestData")]
    public class TestData : UnityEngine.ScriptableObject
    {
        public List<ScriptableTest> tests = new();
    }

    [Serializable]
    public class ScriptableTest
    {
        [SerializeField] int id;
        [SerializeField] string name;

        public Test ToTest()
        {
            return new Test() { Id = id, Name = name };
        }
    }
}
