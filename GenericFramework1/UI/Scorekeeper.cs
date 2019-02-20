using UnityEngine;
using System.Collections;
using TMPro;
//using UnityEngine.UI;
//using MEC;

namespace Stahle.UI
{
    //ScoreKeeper keeps track of a score. Inherit from Singleton if theres one
    public class ScoreKeeper : MonoBehaviour
    {
        TextMeshProUGUI scoreText;
        //Text scoreText;
        private int _baseScoreMultiplier;
        private int _currentScoreMultiplier;
        public int _currentScore;

        //[SerializeField] private TextMeshProUGUI ptsTextPopupForCanvas; //dragged in 
        //[SerializeField] private Text ptsTextPopupForCanvas; //dragged in 

        void Start()
        {
            //set the baseScoreMultiplier
            _baseScoreMultiplier = 1;
            //set the currentMultiplier to the standard base multiplier
            _currentScoreMultiplier = _baseScoreMultiplier;
            //get a reference to my tmp text
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
            //scoreText = GetComponentInChildren<Text>();

            //! dont forget to subscribe to event that gives score info
        }

        private void Handle_OnScoreNeedsToBeUpdated()
        {
            //! If you're subscribed to an event that sends you score info
        }

        private void UpdateScoreBoardUI()
        {
            //StartCoroutine(ShowPointsObjectWasWorthOnCanvas(asteroidItem));
            scoreText.SetText(_currentScore.ToString());
            //scoreText.text = _currentScore.ToString(); 
        }

        private void CalculateScoreWithCurrentMultiplier(int points)
        {
            _currentScore += (points * _currentScoreMultiplier);
            UpdateScoreBoardUI();
        }

        private void ResetThisClass()
        {
            _currentScoreMultiplier = 1;
            _currentScore = 0;
            //! dont forget to unsubscribe to static events below!

        }

        //IEnumerator<float> ShowPointsObjectWasWorthOnCanvas(GameObject thingWorthPoints)
        //{
        //    //get last location of object when it died
        //    Vector2 diedHere = thingWorthPoints.transform.localPosition;
        //    //convert that position to viewport space

        //    //change anchors to the viewport location as a hack around converting to canvas space
        //    ptsTextPopupForCanvas.rectTransform.anchorMin = viewportLocation;
        //    ptsTextPopupForCanvas.rectTransform.anchorMax = viewportLocation;

        //    //set text with the amt of pts the object was worth
        //    ptsTextPopupForCanvas.SetText("+" + thingWorthPoints.PublicScriptableObjectReference.numPoints);
        //    //show it on screen for x amount of time
        //    yield return Timing.WaitForSeconds(1f);
        //    //clear the text out, making it "invisible"
        //    ptsTextPopupForCanvas.SetText("");
        //    //ptsTextPopupForCanvas.Text = "";
        //}
    }
}