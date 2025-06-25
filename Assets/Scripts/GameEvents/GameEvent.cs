using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameEvents
{
    [CreateAssetMenu(fileName = "Void Event", menuName = "Game Events/Void Event")]
    public abstract class GameEvent<T> : ScriptableObject
    {
        private List<GameEventListener<T>> listeners;

        private void OnEnable()
        {
            listeners = new List<GameEventListener<T>>();
        }

        private void OnDisable()
        {
            listeners.Clear();
        }

        public void SetUp()
        {
            listeners = new List<GameEventListener<T>>();
        }

        public void Raise(T value)
        {
            foreach (GameEventListener<T> sub in listeners)
            {
                sub.OnEventRaised(value);
            }
        }

        public void Register(GameEventListener<T> newListener)
        {
            if (listeners.Contains(newListener)) return;

            listeners.Add(newListener);
        }

        public void Unregister(GameEventListener<T> newListener)
        {
            if (!listeners.Contains(newListener)) return;

            listeners.Remove(newListener);
        }
    }
}