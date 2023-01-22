using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }
        private bool finishLine = false;
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            for (int i = 0; i < input.Length; i++)
            {
                if (finishLine)
                {
                    break;
                }
                textHolder.text += input[i];
                SoundManager.Instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            textHolder.text = input;

            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            finished = true;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                finishLine = true;
            }
        }
    }
}
