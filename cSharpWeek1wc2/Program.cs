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
                Moeilijkheidsgraad = 2
            };

            thirdCSharp.AddChoice("1", false);
            thirdCSharp.AddChoice("0", true);
            thirdCSharp.AddChoice("null", false);

            int moeilijkheidsgraadGekozen = Convert.ToInt32(getMoeilijkheidsgraad());
            string categoryGekozen = getCategory();

            List<Question> questionJava = new List<Question>() { firstJava,secondJava, thirdJava};
            List<Question> questionCSharp = new List<Question>() { secondCSharp,firstCSharp,thirdCSharp};

            //LINQ
            var questionJ = questionJava.OrderBy(qj => qj.Moeilijkheidsgraad).ToList();
            var questionC = questionCSharp.OrderBy(qc => qc.Moeilijkheidsgraad).ToList();

            //bron: https://stackoverflow.com/questions/1528171/joining-two-lists-together
            var allQuestion = questionC.Concat(questionJ);

            List<Question> SelectedQuestion = (from q in allQuestion
                                         where q.Category.Equals(categoryGekozen)
                                         select q).ToList();

            //bron: https://stackoverflow.com/questions/6015081/c-sharp-linq-how-to-retrieve-a-single-result

            Question result = (from q in SelectedQuestion
                               where q.Moeilijkheidsgraad == moeilijkheidsgraadGekozen
                              select q ).Single();

            
            PresentQuestion(result);
           /* PresentQuestion(second);
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
           while(Convert.ToInt32(response) > 3 || Convert.ToInt32(response) < 1)
            {
                Console.WriteLine("Kies alstublieft alleen bovenstaande moeilijkheidsgraad. ");
                response = Console.ReadLine();
            }
            Console.WriteLine("U hebt moeilijkheidsgraadniveau: " + response + " gekozen.\n");
            return response;
        }

        public static string getCategory()
        {
            Console.WriteLine("Kies de category: \n" +
                "Java \n" +
                "C# \n");
            String response = Console.ReadLine();

            // bron: https://stackoverflow.com/questions/6371150/comparing-two-strings-ignoring-case-in-c-sharp 
            while (!response.Equals("java", StringComparison.InvariantCultureIgnoreCase) 
                && !response.Equals("c#", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Kies alstublieft alleen bovenstaande category. ");
                response = Console.ReadLine();
            }
            Console.WriteLine("U hebt category: " + response + " gekozen.\n");

            return UppercaseFirst(response);
        }
        //bron: https://www.dotnetperls.com/uppercase-first-letter
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
        
}
