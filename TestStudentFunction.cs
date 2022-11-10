using Newtonsoft.Json.Linq;
using static System.Formats.Asn1.AsnWriter;
using StudentService;

namespace TestProjectStudent
{
    [TestClass]
    public class TestStudentFunction
    {
        [TestMethod]
        public void Add_FirstStudent_Should_Success()
        {
            StudentService.StudentService service = new StudentService.StudentService();
            Student s = new Student() { Id = 1, Name = "Ly", Age = 22, Score = 9.0 };

            bool status = service.addStudent(s);
            int length = service.size();

            Assert.IsTrue(status);
            Assert.AreEqual(1, length);
        }

        [TestMethod]
        public void Add_DuplicateStudentFail_Should_ReturnFalse()
        {
            StudentService.StudentService service = new StudentService.StudentService();
            Student s1 = new Student() { Id = 1, Name = "Ly", Age = 23, Score = 9.0 };
            Student s2 = new Student() { Id = 1, Name = "Hue", Age = 21, Score = 8.0 };

            service.addStudent(s1);
            bool status = service.addStudent(s2);

            Assert.IsFalse(status);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void passingNullParam_ShouldThrow_NullRefExcept()
        {
            StudentService.StudentService sv = new StudentService.StudentService();
            sv.addStudent(null);
        }

        [TestMethod]
        public void findStudent_byAge_returnFirstStudent()
        {
            StudentService.StudentService service = new StudentService.StudentService();
            Student s1 = new Student() { Id = 1, Name = "Ly", Age = 23, Score = 9.0 };
            Student s2 = new Student() { Id = 2, Name = "Hue", Age = 21, Score = 8.0 };
            Student s3 = new Student() { Id = 3, Name = "Dung", Age = 21, Score = 8.0 };
            Student s4 = new Student() { Id = 4, Name = "Duong", Age = 25, Score = 8.0 };

            service.addStudent(s1);
            service.addStudent(s2);
            service.addStudent(s3);
            service.addStudent(s4);

            service.findStudentByAge(21);
            Assert.AreSame(s2, service.findStudentByAge(21));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void findStudent_byAge_Fail_returnNull()
        {
            StudentService.StudentService service1 = new StudentService.StudentService();
            Student s1 = new Student() { Id = 1, Name = "Ly", Age = 23, Score = 9.0 };
            Student s2 = new Student() { Id = 2, Name = "Hue", Age = 21, Score = 8.0 };
            Student s3 = new Student() { Id = 3, Name = "Dung", Age = 21, Score = 8.0 };
            Student s4 = new Student() { Id = 4, Name = "Duong", Age = 25, Score = 8.0 };

            service1.addStudent(s1);
            service1.addStudent(s2);
            service1.addStudent(s3);
            service1.addStudent(s4);

            service1.findStudentByAge(30);
        }

        [TestMethod]
        public void getAverage_ofAllStudent()
        {
            StudentService.StudentService service1 = new StudentService.StudentService();
            Student s1 = new Student() { Id = 1, Name = "Ly", Age = 23, Score = 9.0 };
            Student s2 = new Student() { Id = 2, Name = "Hue", Age = 21, Score = 8.0 };
            Student s3 = new Student() { Id = 3, Name = "Dung", Age = 21, Score = 7.0 };
            Student s4 = new Student() { Id = 4, Name = "Duong", Age = 25, Score = 6.0 };

            service1.addStudent(s1);
            service1.addStudent(s2);
            service1.addStudent(s3);
            service1.addStudent(s4);

            Assert.AreEqual(service1.getAverageScore(), 7.5);
            
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException))]
        public void getAverage_ofAllStudent_emptyList_returnSysExcept()
        {
            StudentService.StudentService service1 = new StudentService.StudentService();
     
            Assert.AreEqual(service1.getAverageScore(), 7.5);

        }
    }
}