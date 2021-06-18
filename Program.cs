using System;

namespace design_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            User student = new Student();
            User teacher = new Teacher();
            User admin = new Admin();
            Visitor v = new VisitorImpl();
            student.search(v);
            teacher.search(v);
            admin.search(v);
        }
    }
}
