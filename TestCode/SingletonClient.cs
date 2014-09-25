using System;
using DesignStrategies_JonSkeet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCode
{
    [TestClass]
    public class SingletonClient
    {
        [TestMethod]
        public void TestMethod1()
        {
            NotASingleton s1 = new NotASingleton();
            s1.DoSomething();
            //what we dont want!
            NotASingleton s2 = new NotASingleton();
            s1.DoSomething();

            //using a static class
            SingletonLike.DoSomething();


            Singleton singleton1 = Singleton.Instance;
            Singleton singleton2 = Singleton.Instance;

            Assert.AreSame(singleton1, singleton2);
        }
    }
}
