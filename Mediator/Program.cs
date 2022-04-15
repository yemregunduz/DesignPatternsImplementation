using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new ();
            Teacher teacher = new(mediator) { Name = "Yunus Emre Gündüz"};

            mediator.Teacher = teacher;
            Student fatmaNur = new Student(mediator) { Name = "Fatma Nur Karaman" };
            Student fatihMehmet = new Student(mediator) { Name = "Fatih Mehmet Gündüz" };

            mediator.Students = new List<Student> { fatmaNur, fatihMehmet };
            
            teacher.SendNewSlideUrl("newSlide.pptx");

            teacher.RecieveQuestion("What is your age?",fatihMehmet);

            fatihMehmet.RecieveAnswer("I'm 24");
        }
       
    }
    abstract class CourseMember
    {
        public string Name { get; set; }
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }

    }
    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveQuestion(string questionContent, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0} : {1}", student.Name, questionContent);
        }
        public void SendNewSlideUrl(string url)
        {
            Console.WriteLine("Techer changed slide: {0}", url);
            Mediator.UpdateImage(url);
        }
        public void AnswerQuestion(string answerContent, Student student)
        {
            Console.WriteLine("Teacher answered question: {0},{1}", student.Name, answerContent);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveSlide(string url)
        {
            Console.WriteLine("{0} recieved image: {1} ",Name, url);
        }

        public void RecieveAnswer(string answerContent)
        {
            Console.WriteLine("{0} recieved answer: {1}",Name, answerContent);
        }
    }
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveSlide(url);
            }
        }
        public void SendQuestion(string questionContent, Student student)
        {
            Teacher.RecieveQuestion(questionContent, student);
        }
        public void SendAnswer(string answerContent,Student student)
        {
            student.RecieveAnswer(answerContent);
        }
    }
}
