using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Hashtable _classrooms = new Hashtable();

    public void Add(string student, int grade)
    {
        if(_classrooms.ContainsKey(grade))
        {
            var classroom = (SortedSet<string>)_classrooms[grade];
            classroom.Add(student);
        }
        else
        {
            _classrooms.Add(grade, new SortedSet<string> { student });
        }
    }

    public IEnumerable<string> Roster()
    {
        List<string> allStudents = new List<string>();
        SortedSet<int> grades = new SortedSet<int>();
        
        foreach(var grade in _classrooms.Keys)
        {
            grades.Add((int)grade);
        }
  
        foreach (var grade in grades)
        {
            foreach (var student in (SortedSet<string>)_classrooms[grade])
            {
                allStudents.Add(student);
            }
        }

        return allStudents;
    }

    public IEnumerable<string> Grade(int grade) => (SortedSet<string>)_classrooms[grade] ?? new SortedSet<string>();
}