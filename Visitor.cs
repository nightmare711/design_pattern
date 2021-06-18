using System;
namespace design_pattern
{
    public interface User {
        void search(Visitor v);
    }
    public class Student: User {
        public void search(Visitor v) {
            v.visit(this);
        }
    
        public string getData() {
            return "You can't use search engine!";
        }
    }
    public interface Authority: User {
        string getResource();
    }
    public class Teacher : Authority {
    
        public void search(Visitor v) {
            v.visit(this);
        }
        public string getResource() {
            return "Resource get from table students";
        }
        public string getStudents() {
            return "You can get all students!";
        }
    }
    public class Admin : Authority {
 
        public void search(Visitor v) {
            v.visit(this);
        }
    
        public string getResource() {
            return "Resource get from table students and teacher";
        }
    
        public string getStudentsAndTeacher() {
            return "You can get all students and teachers!";
        }
    }
    public interface Visitor {
 
        void visit(Student student);
    
        void visit(Teacher teacher);
    
        void visit(Admin admin);
    }
    public class VisitorImpl: Visitor {
        public void visit(Student student) {
            Console.WriteLine(student.getData());
        }
    
        public void visit(Teacher teacher) {
            Console.WriteLine(teacher.getStudents());
        }
    
        public void visit(Admin admin) {
            Console.WriteLine(admin.getStudentsAndTeacher());
        }
    }

}