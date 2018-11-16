using System;
using System.Collections.Generic;
using System.Linq;

namespace cSharpWeek1wc2
{
    class Program
    {
        static void Main(string[] args)
        {
            Question firstJava = new Question()
            {
                Text = "Who was the inventor of Java?",
                Answer = "James Gosling",
                Category = "Java",
                Moeilijkheidsgraad = 3
            };

            ChoiceQuestion secondJava = new ChoiceQuestion()
            {
                Text = "In which country was the inventor of Java born?",
                Category = "Java",
                Moeilijkheidsgraad = 2
            };

            secondJava.AddChoice("Australia", false);
            secondJava.AddChoice("Denmark", false);
            secondJava.AddChoice("Canada", true);
            secondJava.AddChoice("United States", false);


            ChoiceQuestion thirdJava = new ChoiceQuestion()
            {
                Text = "Who is James Gosling",
                Category = "Java",
                Moeilijkheidsgraad = 1
            };

            thirdJava.AddChoice("The inventor of Java", true);
            thirdJava.AddChoice("The inventor of C#", false);
            thirdJava.AddChoice("The inventor of C++", false);
            thirdJava.AddChoice("The inventor of HTML", false);

            
            ChoiceQuestion secondCSharp = new ChoiceQuestion()
            {
                Text = "Wat is de standaardwaarde van string datatype?",
                Category = "Datatype",
                Moeilijkheidsgraad = 1
            };

            secondCSharp.AddChoice("1", false);
            secondCSharp.AddChoice("0",false);
            secondCSharp.AddChoice("null",true);

            ChoiceQuestion firstCSharp = new ChoiceQuestion()
            {
                Text = "Wat is de standaardwaarde van float datatype?",
                Category = "Datatype",
                Moeilijkheidsgraad = 3
            };

            firstCSharp.AddChoice("0.0", true);
            firstCSharp.AddChoice("0", false);
            firstCSharp.AddChoice("null", false);

            ChoiceQuestion thirdCSharp = new ChoiceQuestion()
            {
                Text = "Wat is de standaardwaarde van integer datatype?",
                Category = "Datatype",
                Moeilijkheidsgraad = 3
            };

            thirdCSharp.AddChoice("1", false);
            thirdCSharp.AddChoice("0", true);
            thirdCSharp.AddChoice("null", false);

            int moeilijkheidsgraadGekozen = Convert.ToInt32(getMoeilijkheidsgraad());
            string categoryGekozen = getCategory();

            List<Question> questionJava = new List<Question>() { firstJava,secondJava, thirdJava};
            List<Question> questionCSharp = new List<Question>() { secondCSharp,firstCSharp,thirdCSharp};

            var questionJ = questionJava.OrderBy(qj => qj.Moeilijkheidsgraad).ToList();
            var questionC = questionCSharp.OrderBy(qc => qc.Moeilijkheidsgraad).ToList();
            
            /*
            PresentQuestion(first);
            PresentQuestion(second);
            PresentQuestion(thirdJava);
            */

            Console.ReadKey(true);
        }

        public static void PresentQuestion(Question q)
         {
            q.Display();
            Console.WriteLine("Your answer: ");
            String response = Console.ReadLine();
            Console.WriteLine(q.CheckAnswer(response));
         }

        public static string getMoeilijkheidsgraad()
        {
            Console.WriteLine("Kies de moelijkheidsgraadniveau: \n" +
                "1 \n" +
                "2 \n" +
                "3 \n");
            String response = Console.ReadLine();
            Console.WriteLine("U hebt moeilijkheidsgraadniveau: " + response + "gekozen");
            return response;
        }

        public static string getCategory()
        {
            Console.WriteLine("Kies de category: \n" +
                "Java \n" +
                "C# \n");
            String response = Console.ReadLine();
            Console.WriteLine("U hebt category: " + response + "gekozen");
            return response;
        }
    }
        
}
