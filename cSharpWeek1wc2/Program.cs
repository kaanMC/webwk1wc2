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



            IList<Question> allQuestion = new List<Question>() { firstJava, secondJava, thirdJava, secondCSharp, firstCSharp, thirdCSharp };
            var allQuestionSorted = allQuestion.OrderBy(qj => qj.Moeilijkheidsgraad).ToList();

            
            Console.WriteLine("Welkom! QuizTime!! \n Kies: Category (1) of Moeilijkheidsgraad (2) \n Toets 1 of 2 in.");
            int response = int.Parse(Console.ReadLine());
            int? moeilijkheidsgraadGekozen = null;
            string categoryGekozen = null;

            if (response == 1) moeilijkheidsgraadGekozen = Convert.ToInt32(UserMoeilijkheidsgraad(allQuestionSorted));
            else categoryGekozen = UserCategory(allQuestionSorted);

            List<Question> displayQuestion = new List<Question>();

            if (categoryGekozen != null)
            {
                displayQuestion = (from q in allQuestion
                                   where q.Category.Equals(categoryGekozen)
                                   select q).ToList();
            }
            else
            {
                //bron: https://stackoverflow.com/questions/6015081/c-sharp-linq-how-to-retrieve-a-single-result
                displayQuestion = (from q in allQuestionSorted
                                         where q.Moeilijkheidsgraad == moeilijkheidsgraadGekozen
                                         select q).ToList();
            }
            
            PresentQuestion(displayQuestion);
            Console.WriteLine("EIND");
            Console.ReadKey(true);
        }

        public static void PresentQuestion(List<Question> Q)
         {
            foreach (Question q in Q)
            {
                q.Display();
                Console.WriteLine("Your answer: ");
                String response = Console.ReadLine();
                Console.WriteLine(q.CheckAnswer(response));
                Console.WriteLine("\n\n");
            }
        }

        public static string UserMoeilijkheidsgraad(IList<Question> allQuestion)
        {
            var mLijst = allQuestion.GroupBy(q => q.Moeilijkheidsgraad)
                   .Select(q => q.First())
                   .ToList();

            Console.WriteLine("Kies de moelijkheidsgraadniveau: \n");
            foreach (Question m in mLijst) Console.WriteLine(m.Moeilijkheidsgraad + "\n");

            int lowest = mLijst.Min(m => m.Moeilijkheidsgraad);
            int highest = mLijst.Max(m => m.Moeilijkheidsgraad);
            String response = Console.ReadLine();

            while(Convert.ToInt32(response) > highest || Convert.ToInt32(response) < lowest)
            {
                Console.WriteLine("Kies alstublieft alleen bovenstaande moeilijkheidsgraad. ");
                response = Console.ReadLine();
            }

            Console.WriteLine("U hebt moeilijkheidsgraadniveau: " + response + " gekozen.\n");
            return response;
        }

        public static string UserCategory(IList<Question> allQuestion)
        {
            List<Question> categoryLijst = allQuestion.GroupBy(q => q.Category)
                   .Select(q => q.First())
                   .ToList();

            Console.WriteLine("Kies de category: \n ");
            foreach (Question c in categoryLijst) Console.WriteLine(c.Category + "\n");

            String response = Console.ReadLine();
            IList<String> categories = categoryLijst.Select(c => c.Category).ToList();

            //bron: https://stackoverflow.com/questions/3947126/case-insensitive-list-search
            while (!categories.Contains(response, StringComparer.OrdinalIgnoreCase))
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
