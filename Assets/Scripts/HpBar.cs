using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;
        [SerializeField]
        private Text _text;

        public void SetData(int hp)
        {
            _slider.value = hp;
            _text.text = hp.ToString();
        }
    }
}