using System;


namespace StudentRecordTool
{
    class Student
    {
        //Print for single student 
        public string Name;
        public int Age;
        public double Mark;
    }
    class Program
    {
        // Global variables
        static String programName = "Student Record Tool v1.5";
        static int totalStudents = 0;

        // An array that holds Students instead of loose variables
        static Student[] students = new Student[5];


        static void Main(string[] args)
        {
            ShowWelcome();
            RunProgram();
        }


        static void ShowWelcome()
        {
            Console.WriteLine("================================");
            Console.WriteLine("     " + programName);
            Console.WriteLine("================================");
            Console.WriteLine();
        }


        static void RunProgram()
        {
            // Adding students to our system
            AddStudent("Mpho", 20, 74.5);
            AddStudent("Lerato", 21, 88.0);
            AddStudent("Thabo", 19, 51.3);

            Console.WriteLine("── STUDENT RECORDS ──");
            Console.WriteLine();
            DisplayAllStudents();

            // Calling the new method to display the top performing student
            DisplayTopStudent();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void AddStudent(string name, int age, double mark) //The conditions in the bracktes were changed....
        {
            if (totalStudents < 5)
            {
                //1st Bug Fix - Makes a new Student using the "new" keyword before adding the information. 
                Student newStudent = new Student();
                newStudent.Name = name;
                newStudent.Age = age;
                newStudent.Mark = mark;

                //2nd Bug Fix - Places the new student in a the student list/array at the current student number.
                students[totalStudents] = newStudent;

                totalStudents++;
                Console.WriteLine(name   + " added successfully.  ");
            }
            else
            {
                Console.WriteLine("Record list is full.");
            }
        }


        static void DisplayAllStudents()      // Had to remove content inside the bracket in order to Call this method in the RunProgram method....
        {
            // Bug zone: check this loop carefully
            //Fix off-by-one error: use < instead of <= to avoid accessing an invalid index.
            for (int i = 0; i < totalStudents; i++)                    
            {
                //3rd Bug Fix - Uses the student's number to find their place in the student list. 
                Student current = students[i];

                //4th Bug Fix - Uses the information from the current student instead of using variables that are not there.
                Console.WriteLine("Name        : " + current.Name);
                Console.WriteLine("Age         : " + current.Age);
                Console.WriteLine("Mark        : " + current.Mark + "%");
                Console.WriteLine("Grade       : " + GetGrade(current.Mark));
                Console.WriteLine();
            }
        }
        //Group A Task: Display the student with the highest mark 
        static void DisplayTopStudent()
        {
            if (totalStudents == 0)
            {
                Console.WriteLine("No student records available.");
                return;
            }
            //Start by thinking the first student left has the highest mark...
            Student topStudent = students[0];

            for (int i = 1; i < totalStudents; i++)
            {
                if (students[i].Mark > topStudent.Mark)
                {
                    topStudent = students[i];
                }
            }

            //Output the top student'a full profile
            Console.WriteLine("___ TOP PERFORMER ___");
            Console.WriteLine("Name    : " + topStudent.Name);
            Console.WriteLine("Age     : " + topStudent.Age);
            Console.WriteLine("Mark    : " + topStudent.Mark + "%");
            Console.WriteLine("Grade   : " + GetGrade(topStudent.Mark));

        }


        static string GetGrade(double mark)
        {
            // Bug zone: check the conditions — do they make sense?
            if (mark >= 75)
                return "Distinction";
            // Fix duplicate condition: change the second mark >= 75 to mark >= 60.
            if (mark >= 60)                
                return "Merit";
            if (mark >= 50)
                return "Pass";
            else
                return "Fail";
        }


       
       
        
    }
}

