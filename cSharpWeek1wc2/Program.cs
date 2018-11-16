using System;

namespace cSharpWeek1wc2
{
    class Program
    {
        static void Main(string[] args)
        {
            ChoiceQuestion second = new ChoiceQuestion()
            {
                Text = "In which country was the inventor of Java born?"
            };

            second.AddChoice("Australia",false);
            second.AddChoice("Denmark",false);
            second.AddChoice("Canada",true);
            second.AddChoice("United States",false);

            presentQuestion(second);
            Console.ReadKey(true);
        }

        public static void PresentQuestion(Question q)
         {
            q.Display();
            Console.WriteLine("Your answer: ");
            String response = Console.ReadLine();
            Console.WriteLine(q.CheckAnswer(response));
         }
}
}
