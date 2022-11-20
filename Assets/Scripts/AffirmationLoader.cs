using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AffirmationLoader : MonoBehaviour
{
    [SerializeField]
    private TMP_Text affirmationText;

    public void UpdateText()
    {
        var numberOfAffirmations = Affirmation.NumberOfAffirmations();

        int randomIndex = Random.Range(0, numberOfAffirmations);

        affirmationText.text = Affirmation.GetAffirmation(randomIndex);
    }
}
