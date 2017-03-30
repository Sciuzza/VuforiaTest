using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoveScriptable))]
public class CustomMoveInspector : Editor
{
    MoveScriptable move;

    void OnEnable()
    {
        move = (MoveScriptable) target;
    }

    public override void OnInspectorGUI()
    {
        #region Common to all moves
        move.moveName = EditorGUILayout.TextField("Name: ", move.moveName);
        move.iD = EditorGUILayout.IntField("Id: ", move.iD);
        move.description = EditorGUILayout.TextField("Description: ", move.description);
        move.type = (ElementalType)EditorGUILayout.EnumPopup("Type: ", move.type);
        move.manaCost = EditorGUILayout.IntField("Mana cost: ", move.manaCost);
        move.gesture = (GestureType)EditorGUILayout.EnumPopup("Gesture type: ", move.gesture);
        move.gestureProbability = EditorGUILayout.IntSlider("Gesture probability: ", move.gestureProbability, 0, 100);
        move.speed = EditorGUILayout.IntField("Speed: ", move.speed);
        move.precision = EditorGUILayout.IntSlider("Precision: ", move.precision, 0, 100);
        move.contact = EditorGUILayout.Toggle("Contact? ", move.contact); 
        #endregion

        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("EFFECTS:", MessageType.None);
        
        #region Effects
        
        #region Physical
        move.effects.physical.active = EditorGUILayout.Toggle("Physical", move.effects.physical.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.physical.active)))
        {
            if (group.visible)
            {
                move.effects.physical.damage = EditorGUILayout.IntField("Damage: ", move.effects.physical.damage);
                move.effects.physical.critRate = EditorGUILayout.IntSlider("Crit rate: ", move.effects.physical.critRate, 0, 100);
                move.effects.physical.knockback = EditorGUILayout.IntSlider("Knockback: ", move.effects.physical.knockback, 0, 100);
            }
        }
        #endregion
        
        #region Elemental
        move.effects.elemental.active = EditorGUILayout.Toggle("Elemental", move.effects.elemental.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.elemental.active)))
        {
            if (group.visible)
            {
                move.effects.elemental.damage = EditorGUILayout.IntField("Damage: ", move.effects.elemental.damage);
                move.effects.elemental.critRate = EditorGUILayout.IntSlider("Crit rate: ", move.effects.elemental.critRate, 0, 100);
            }
        }
        #endregion

        #region Buff
        move.effects.buff.active = EditorGUILayout.Toggle("Buff", move.effects.buff.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.buff.active)))
        {
            if (group.visible)
            {
                move.effects.buff.rate = EditorGUILayout.IntSlider("Rate: ", move.effects.buff.rate, 0, 100);
                //serializing Stats[]
                SerializedObject obj = new SerializedObject(move);
                SerializedProperty statsProperty = obj.FindProperty("effects.buff.influencedStats");
                EditorGUILayout.PropertyField(statsProperty, true);
                obj.ApplyModifiedProperties();
                //
                move.effects.buff.buffLevel = EditorGUILayout.IntSlider("Stat variation: ", move.effects.buff.buffLevel, 1, 3);
            }
        }
        #endregion

        #region Debuff
        move.effects.debuff.active = EditorGUILayout.Toggle("Debuff", move.effects.debuff.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.debuff.active)))
        {
            if (group.visible)
            {
                move.effects.debuff.rate = EditorGUILayout.IntSlider("Rate: ", move.effects.debuff.rate, 0, 100);
                //serializing Stats[]
                SerializedObject obj = new SerializedObject(move);
                SerializedProperty statsProperty = obj.FindProperty("effects.debuff.influencedStats");
                EditorGUILayout.PropertyField(statsProperty, true);
                obj.ApplyModifiedProperties();

                move.effects.debuff.debuffLevel = EditorGUILayout.IntSlider("Stat variation: ", move.effects.debuff.debuffLevel, 1, 3);
            }
        }
        #endregion

        #region Status
        move.effects.status.active = EditorGUILayout.Toggle("Status", move.effects.status.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.status.active)))
        {
            if (group.visible)
            {
                //serializing StatusAlteration[]
                SerializedObject obj = new SerializedObject(move);
                SerializedProperty alterationProperty = obj.FindProperty("effects.status.alteration");
                EditorGUILayout.PropertyField(alterationProperty, true);

                move.effects.status.damageRate = EditorGUILayout.IntSlider("Damage rate: ", move.effects.status.damageRate, 0, 100);
                //serializing Turns[]
                SerializedProperty turnProperty = obj.FindProperty("effects.status.turns");
                turnProperty.arraySize = EditorGUILayout.IntField("How many turns? ", turnProperty.arraySize);
                for (int i = 0; i < turnProperty.arraySize; i++)
                {
                    EditorGUILayout.PropertyField(turnProperty.GetArrayElementAtIndex(i), new GUIContent("Rate at turn " + (i + 1) + " : "));
                }
                //EditorGUILayout.PropertyField(turnProperty, true);
                obj.ApplyModifiedProperties();

            }
        }
        #endregion

        #region Drain
        move.effects.drain.active = EditorGUILayout.Toggle("Drain", move.effects.drain.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.drain.active)))
        {
            if (group.visible)
            {
                move.effects.drain.amountDrained = EditorGUILayout.IntSlider("Drain rate: ", move.effects.drain.amountDrained, 0, 100);
                EditorGUILayout.BeginHorizontal();
                move.effects.drain.amountGained = EditorGUILayout.IntSlider("Gain rate: ", move.effects.drain.amountGained, 0, 100);
                EditorGUILayout.LabelField("% of " + move.effects.drain.amountDrained + "%");
                EditorGUILayout.EndHorizontal();
            }
        }
        #endregion

        #region Heal
        move.effects.heal.active = EditorGUILayout.Toggle("Heal", move.effects.heal.active);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(move.effects.heal.active)))
        {
            if (group.visible)
            {
                move.effects.heal.amountHealed = EditorGUILayout.IntSlider("Heal rate: ", move.effects.heal.amountHealed, 0, 100);
            }
        }
        #endregion 

        #endregion
    }

}
