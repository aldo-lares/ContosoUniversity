using System.Linq;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Reports
{
    public static class ReportFunctions
    {
        // Calcula el total de estudiantes
        public static int GetTotalStudents(SchoolContext context)
        {
            return context.Students.Count();
        }

        // Genera datos demográficos agrupados por cualquier propiedad
        public static Dictionary<object, int> GetStudentDemographics<T>(SchoolContext context, Func<Student, T> keySelector)
        {
            return context.Students
                .GroupBy(keySelector)
                .ToDictionary(g => (object)g.Key, g => g.Count());
        }

        // Calcula el total de cursos
        public static int GetTotalCourses(SchoolContext context)
        {
            return context.Courses.Count();
        }

        // Calcula el promedio de alumnos por curso
        public static double GetAverageStudentsPerCourse(SchoolContext context)
        {
            var courseCounts = context.Courses
                .Select(c => context.Enrollments.Count(e => e.CourseID == c.CourseID));
            return courseCounts.Any() ? courseCounts.Average() : 0.0;
        }
    }
}
