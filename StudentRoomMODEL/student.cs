using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace StudentRoom.MODEL
{
    public class student
    {
        private int studentId;
        private string studentName;
        private string studentClass;
        private string studentIdenty;

        public string StudentIdenty
        {
            get { return studentIdenty; }
            set { studentIdenty = value; }
        }

        public string StudentClass
        {
            get { return studentClass; }
            set { studentClass = value; }
        }

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

    }
}
