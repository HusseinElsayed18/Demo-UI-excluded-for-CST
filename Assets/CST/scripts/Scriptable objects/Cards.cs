using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CST
{

    [CreateAssetMenu(fileName = "Cards", menuName = "Create Cards")]

    public class Cards : ScriptableObject
    {

        [SerializeField] public List<Card> cards;

    }

}
