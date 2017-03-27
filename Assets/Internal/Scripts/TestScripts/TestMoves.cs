using UnityEngine;
using System;

public class TestMoves : MonoBehaviour
{
    // Action
    public Action<bool> boolEvent;

    // Delegate
    public delegate int TestEvent(bool _value);
    public event TestEvent test;
    

    public Move[] moves;

    private void OnValidate()
    {
        Transform myTransform = this.transform;

		if (myTransform.childCount > 0)
		{
			moves = new Move[myTransform.childCount];

			for (int i = 0; i < moves.Length; i++)
			{
                Move currentMove = myTransform.GetChild(i).GetComponent<Move>();

                if (currentMove != null)
                    moves[i] = currentMove;
                else
                    Debug.LogError("Move " + (i + 1) + " haven't component\n");
			}
		}
    }
}