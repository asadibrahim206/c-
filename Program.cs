using System;
    
    namespace myProgram
{
    class Program
    {   
        static void Main()
        {   
            
            const int TotalStudents = 5;
            int[] score = new int[TotalStudents];
           
            
            for(int i = 0; i < score.Length; i++)
            {
                Console.WriteLine("---enter score of student 1 ---");
                score[i] = int.Parse(Console.ReadLine());

                char grade = CalculateGrade(score[i]);
                Console.WriteLine($"STUDENT GRADE {grade}");
            }
                
        }
        static char CalculateGrade(int score)
        {
            if (score >= 90) 
                return 'A';
            else if (score >= 80 )
                return 'B';
            else if (score >= 70)
                return 'C';
            else 
                return 'F' ;
        }
      
        
    }
}


