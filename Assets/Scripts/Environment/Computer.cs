using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        Utility.GenericQueue<DebugPrintTask> taskQueue = new Utility.GenericQueue<DebugPrintTask>(); // Put your stack/queue here :)

        public void OnInteract() {
            while(taskQueue.Count() > 0) {
                taskQueue.Dequeue().Execute();
            }
        }
    }
}
