using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        Utility.GenericQueue<Task> taskQueue = new Utility.GenericQueue<Task>();

        public void OnInteract() {
            while(taskQueue.Count() > 0) {
                taskQueue.Dequeue().Execute();
            }
        }
    }
}
