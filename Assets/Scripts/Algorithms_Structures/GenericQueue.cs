using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {
    [System.Serializable]
    public class GenericQueue<T> {
        [SerializeField]
        private List<T> queue;

        public GenericQueue() {
            queue = new List<T>();
        }

        public void Enqueue(T passedValue) {
            queue.Add(passedValue);
        }

        public T Peek() {
            if(queue.Count == 0) {
                throw new AccessViolationException("Queue is empty, cannot peek");
            }

            return queue[0];
        }

        public T Dequeue() {
            if(queue.Count == 0) {
                throw new AccessViolationException("Queue is empty, cannot dequeu");
            }

            T topOfQueue = queue[0];
            queue.RemoveAt(0);

            return topOfQueue;
        }

        public int Count() {
            return queue.Count;
        }

        public void Clear() {
            queue.Clear();
        }
    }
}

