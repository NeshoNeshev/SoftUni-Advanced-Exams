using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> Students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get { return this.Students.Count(); } }
        public string RegisterStudent(Student student)
        {
            if (Capacity > 0)
            {
                Capacity--;
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }

        }
        public string DismissStudent(string firstName, string lastName)
        {
            var existStudent = Students.Where(f => f.FirstName == firstName).Where(l => l.LastName == lastName).FirstOrDefault();
            if (existStudent != null)
            {
                Students.Remove(existStudent);
                Capacity++;
                return $"Dismissed student {existStudent.FirstName} {existStudent.LastName}";
            }
            else
            {
                return "Student not found";
            }

        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            var currentSubject = Students.Where(s => s.Subject == subject).ToList();
            if (currentSubject.Count>0)
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var item in currentSubject)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }

        }
        public int GetStudentsCount()
        {
            return Students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            var exist = Students.Where(f => f.FirstName == firstName).Where(l => l.LastName == lastName).FirstOrDefault();
            return exist;
        
        }
    }
}
