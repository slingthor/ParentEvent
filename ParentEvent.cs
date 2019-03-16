namespace CG.Events
{
    using System;
    using System.Collections.Generic;

    public static class ParentEventUtils
    {
        public static string nullListenerMessage = "A null listener exists, most likely an object didn't"
                                                    + " remove it as listener before cleanup";
    }

    /// <summary>A parameter-less global event to derive a typed global event into</summary>
    /// <typeparam name="Derived">The derived class</typeparam>
    public abstract class ParentEvent<Derived> where Derived : ParentEvent<Derived>, new()
    {
        private static readonly Derived instance;
        private HashSet<Action> listeners;

        static ParentEvent()
        {
            instance = new Derived { listeners = new HashSet<Action>() };
        }

        /// <summary>Pushes a notification to all listeners</summary>
        public static void PushEvent()
        {
            foreach (var listener in instance.listeners)
            {
                if (listener == null)
                {
                    throw new ArgumentNullException(ParentEventUtils.nullListenerMessage);
                }
                listener.Invoke();
            }
        }

        /// <summary>Adds a listener to be notified when a message is pushed</summary>
        /// <param name="onFired">Any parameter-less function</param>
        public static void AddListener(Action onFired)
        {
            instance.listeners.Add(onFired);
        }

        /// <summary>Given the same instance of a function passed in AddListener, removes it as a notification receiver</summary>
        /// <param name="onFired">an already listening parameter-less function</param>
        public static void RemoveListener(Action onFired)
        {
            instance.listeners.Remove(onFired);
        }
    }

    /// <summary>A single parameter global event to derive a typed global event into</summary>
    /// <typeparam name="Derived">The derived class</typeparam>
    /// <typeparam name="T1">The type of the passed message</typeparam>
    public abstract class ParentEvent<Derived, T1> where Derived : ParentEvent<Derived, T1>, new()
    {
        private static readonly Derived instance;
        private HashSet<Action<T1>> listeners;

        static ParentEvent()
        {
            instance = new Derived { listeners = new HashSet<Action<T1>>() };
        }


        /// <summary>Pushes a notification to all listeners</summary>
        /// <param name="message">Parameter that is passed to all receivers</param>
        public static void PushEvent(T1 message)
        {
            foreach (var listener in instance.listeners)
            {
                if (listener == null)
                {
                    throw new ArgumentNullException(ParentEventUtils.nullListenerMessage);
                }
                listener.Invoke(message);
            }
        }

        /// <summary>Adds a listener to be notified when a message is pushed</summary>
        /// <param name="onFired">Any single parameter function</param>
        public static void AddListener(Action<T1> onFired)
        {
            instance.listeners.Add(onFired);
        }

        /// <summary>Given the same instance of a function passed in AddListener, removes it as a notification receiver</summary>
        /// <param name="onFired">an already listening single parameter function</param>
        public static void RemoveListener(Action<T1> onFired)
        {
            instance.listeners.Remove(onFired);
        }
    }

    /// <summary>A two parameter global event to derive a typed global event into</summary>
    /// <typeparam name="Derived">The derived class</typeparam>
    /// <typeparam name="T1">The type of the passed message</typeparam>
    public abstract class ParentEvent<Derived, T1, T2> where Derived : ParentEvent<Derived, T1, T2>, new()
    {

        private static readonly Derived instance;
        private HashSet<Action<T1, T2>> listeners;

        static ParentEvent()
        {
            instance = new Derived { listeners = new HashSet<Action<T1, T2>>() };
        }

        /// <summary>Pushes a notification to all listeners</summary>
        /// <param name="message1">First parameter that is passed to all receivers</param>
        /// <param name="message2">Second parameter that is passed to all receivers</param>
        public static void PushEvent(T1 message1, T2 message2)
        {
            foreach (var listener in instance.listeners)
            {
                if (listener == null)
                {
                    throw new ArgumentNullException(ParentEventUtils.nullListenerMessage);
                }
                listener.Invoke(message1, message2);
            }
        }

        /// <summary>Adds a listener to be notified when a message is pushed</summary>
        /// <param name="onFired">Any two parameter function</param>
        public static void AddListener(Action<T1, T2> onFired)
        {
            instance.listeners.Add(onFired);
        }

        /// <summary>Given the same instance of a function passed in AddListener, removes it as a notification receiver</summary>
        /// <param name="onFired">an already listening two parameter function</param>
        public static void RemoveListener(Action<T1, T2> onFired)
        {
            instance.listeners.Remove(onFired);
        }
    }
}