using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Keyboard : MonoBehaviour
    {
        public TextMeshProUGUI textResult;
        [Space] 
        public UnityEvent enterNumber;
        public UnityEvent ifRightResult;
        public UnityEvent ifFailResult;

        private int _countNumberMax = 3;
        private int _countNumber = 0;

        public void AddNumber(string number)
        {
            textResult.color = Color.white;
            _countNumber++;
            if (_countNumber > _countNumberMax)
            {
                textResult.text = string.Empty;
                _countNumber = 1;
            }
            textResult.text += number;
            enterNumber?.Invoke();
            if (_countNumber == _countNumberMax)
            {
                if (textResult.text == "9 3 1 ")
                {
                    ifRightResult?.Invoke();
                    textResult.color = Color.green;
                }
                else
                {
                    ifFailResult?.Invoke();
                    textResult.color = Color.red;
                }
            }
        }
    }
}