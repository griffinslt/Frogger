using UnityEngine;

namespace ButtonBehaviours
{
    public class SaveButtonBehaviour : MonoBehaviour
    {
        public void OnButtonPress()
        {
            Saver.Instance.Save();
        }
    }
}
