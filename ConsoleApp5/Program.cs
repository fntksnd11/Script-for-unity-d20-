using System;
using System.Security.Cryptography;

class DiceQuestSystem
{
    static int strengthModifier = 2;
    static int charismaModifier = 3;
    static int intelligenceModifier = 1;
    static int questDifficulty = 12;

    static void Main()
    {
        Console.WriteLine("КИДАННЯ КУБИКА D20");
        Console.WriteLine("Введіть: strength(str), charisma(cha) або intelligence(int)\n");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.ToLower();

            switch (input)
            {
                case "str":
                    RollForAction("сили", strengthModifier);
                    break;
                case "cha":
                    RollForAction("харизми", charismaModifier);
                    break;
                case "int":
                    RollForAction("інтелекту", intelligenceModifier);
                    break;
                case "exit":
                    Console.WriteLine("До побачення!");
                    return;
                default:
                    Console.WriteLine("Невідома команда. Спробуйте: str, cha, int або exit");
                    break;
            }
        }
    }

    static void RollForAction(string skillName, int modifier)
    {
        int diceRoll = GetCryptoRandomNumber(1, 21);
        int totalResult = diceRoll + modifier;

        Console.WriteLine($"\n--- Кидок {skillName} ---");
        Console.WriteLine($"Кубик d20: {diceRoll}");
        Console.WriteLine($"Модифікатор ({skillName}): +{modifier}");
        Console.WriteLine($"Підсумок: {diceRoll} + {modifier} = {totalResult}");
        Console.WriteLine($"Складність квесту: {questDifficulty}");

        if (totalResult > questDifficulty)
        {
            Console.WriteLine($"✅ УСПІХ! {totalResult} > {questDifficulty}");
        }
        else
        {
            Console.WriteLine($"❌ ПРОВАЛ! {totalResult} <= {questDifficulty}");
        }
    }

    static int GetCryptoRandomNumber(int minValue, int maxValue)
    {
        if (minValue >= maxValue)
            throw new ArgumentException("minValue має бути менше maxValue");

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[4]; 
            rng.GetBytes(randomBytes);

            uint randomUInt = BitConverter.ToUInt32(randomBytes, 0);

            int range = maxValue - minValue;

            uint maxAcceptable = uint.MaxValue - (uint.MaxValue % (uint)range);

            while (randomUInt >= maxAcceptable)
            {
                rng.GetBytes(randomBytes);
                randomUInt = BitConverter.ToUInt32(randomBytes, 0);
            }

            return (int)(minValue + (randomUInt % (uint)range));
        }
    }
}