using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public int strengthModifier = 2;
    public int charismaModifier = 3;
    public int intelligenceModifier = 1;
    public int questDifficulty = 12;

    void Start()
    {
        Debug.Log("Гра готова! Натискайте клавіші 1, 2, 3");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RollDice("Сила", strengthModifier);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RollDice("Харизма", charismaModifier);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            RollDice("Інтелект", intelligenceModifier);
        }
    }

    void RollDice(string skillName, int modifier)
    {
        int roll = Random.Range(1, 21);
        int total = roll + modifier;

        Debug.Log($"Кидок {skillName}: d20 = {roll} + {modifier} = {total} (Потрібно > {questDifficulty})");

        if (total > questDifficulty)
            Debug.Log($"✅ УСПІХ!");
        else
            Debug.Log($"❌ ПРОВАЛ!");
    }
}
