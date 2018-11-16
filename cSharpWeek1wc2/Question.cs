using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpWeek1wc2
{
    
   public class Question
    {
        public String Text { get; set; }
        public String Answer { get; set; }
        public String Category { get; set; }
        public int Moeilijkheidsgraad { get; set; }

        public Question(String text= "", String answer = "")
        {
            Text = text;
            Answer = answer;
        }

        public Boolean CheckAnswer(String response)
        {
            return response.Equals(Answer, StringComparison.InvariantCultureIgnoreCase);
        }

        public virtual void Display()
        {
            Console.WriteLine(Text +"?" );
        }
    }
}
