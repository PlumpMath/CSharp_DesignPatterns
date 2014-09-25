using System;

namespace DesignStrategies_JonSkeet
{

    /// <summary>
    /// Bad Implementation example
    /// </summary>
    public class NotASingleton
    {

        public void DoSomething()
        {
            
        }
    }

    //good solution if not state is needed
    public static class SingletonLike
    {
        public static void DoSomething()
        {
            double pi = Math.PI;
        }
    }


    //pretty good but not thread safe
    public class Singleton
    {
        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }


        public void DoSomething()
        {

        }
    }

    //thread safe singleton with double check lock
    public class ThreadSafeSingleton
    {
        private static readonly object mutext;
        private static volatile ThreadSafeSingleton instance;

        private int foo = 10; //some class state

        private ThreadSafeSingleton()
        {
            //Stuff that must only happen once.
        }

        public static ThreadSafeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mutext)
                    {
                        if (instance == null)
                        {
                            instance = new ThreadSafeSingleton();
                        }
                    }
                }

                return instance;
            }
        }


        public void DoSomething()
        {
            //this must be thread safe!
        }
    }

 /*The volatile keyword indicates that a field might be modified by multiple threads that are executing at the same time. Fields that are declared volatile are not subject to compiler optimizations that assume access by a single thread. This ensures 
 * that the most up-to-date value is present in the field at all times.*/




    // A much simpler solution!
    //- Thread Safe (the instance field is readonly which allows the clr to manage locking, mutex, and volatile stuff)
    //- Almost Lazy Initialized (when calling a static method like SayHi it will call the static ctor and initialize and instance)
    public class ThreadSafeSingletonShort
    {
        private static readonly ThreadSafeSingletonShort instance = new ThreadSafeSingletonShort();

        private int foo = 10; //some class state

        //Empty static constructor - forces laziness
        static ThreadSafeSingletonShort() {}

        private ThreadSafeSingletonShort()
        {
            //Stuff that must only happen once.
            Console.WriteLine("ThreadSafeSingletonShort constructor");
        }

        public static ThreadSafeSingletonShort Instance { get { return instance; } }

        public static void SayHi()
        {
            Console.WriteLine("Say Hi");
        }

        public void DoSomething()
        {
            //this must be thread safe!
        }

    }

    //- Thread Safe
    //- Fully Lazy Initialized

    public class ThreadSafeSingletonShortLazy
    {
        private static class SingletonHolder
        {
            internal static readonly ThreadSafeSingletonShortLazy instance = new ThreadSafeSingletonShortLazy();
            //Empty static constructor - forces laziness
            static SingletonHolder() { }
        }

        private ThreadSafeSingletonShortLazy()
        {
            //Stuff that must only happen once.
            Console.WriteLine("ThreadSafeSingletonShort constructor");
        }

        public static ThreadSafeSingletonShortLazy Instance { get { return SingletonHolder.instance; } }

        public static void SayHi()
        {
            Console.WriteLine("Say Hi");
        }

        public void DoSomething()
        {
            //this must be thread safe!
        }

    }

}
