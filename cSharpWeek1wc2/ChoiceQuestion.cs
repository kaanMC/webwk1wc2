using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpWeek1wc2
{
    public class ChoiceQuestion : Question
    {
        public List<String> Choices;

        public ChoiceQuestion(string text = "", string answer = "") : base(text)
        {
            Choices = new List<String>();
        }

        public void AddChoice(string answer, Boolean correct)
        {
            if (correct) Answer = answer;
            Choices.Add(answer);
        }

        public override void Display()
        {
            String choice = "";
            foreach(string c in Choices)
            {
                choice += c + "\n";
            }

            Console.WriteLine(Text + "\n\n" + choice);
        }
    }
} 