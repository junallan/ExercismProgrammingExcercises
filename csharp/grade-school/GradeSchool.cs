using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private SortedList<int, SortedSet<string>> _classrooms = new SortedList<int, SortedSet<string>>();

    public void Add(string student, int grade)
    {
        if(_classrooms.ContainsKey(grade))
        {
            var classroom = _classrooms[grade];
            classroom.Add(student);
        }
        else
        {
            _classrooms.Add(grade, new SortedSet<string> { student });
        }
    }

    public IEnumerable<string> Roster() => _classrooms.Values.SelectMany(student => student);

    public IEnumerable<string> Grade(int grade) => _classrooms.GetValueOrDefault(grade, new SortedSet<string>()); 
}