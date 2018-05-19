using System;
using DevExpress.Xpo;

namespace FilterObjectType {
    [System.ComponentModel.DefaultProperty("Title")]
    public class Department : XPObject {
        private string title;
        private string office;
        public Department(Session session) : base(session) { }
        public string Title {
            get { return title; }
            set { SetPropertyValue("Title", ref title, value); }
        }
        public string Office {
            get { return office; }
            set { SetPropertyValue("Office", ref office, value); }
        }
        [Association("Department-Employees")]
        public XPCollection<EmployeeBase> Employees { get { return GetCollection<EmployeeBase>("Employees"); } }
    }
    public class EmployeeBase : XPObject {
        public EmployeeBase(Session session) : base(session) { }
        private string name;
        private string email;
        public string Name {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        public string Email {
            get { return email; }
            set { SetPropertyValue("Email", ref email, value); }
        }
        private Department department;
        [Association("Department-Employees", typeof(Department))]
        public Department Department {
            get { return department; }
            set { SetPropertyValue("Department", ref department, value); }
        }
    }
    public class LocalEmployee : EmployeeBase {
        public LocalEmployee(Session session) : base(session) { }
        private string insurancePolicyNumber;
        public string InsurancePolicyNumber {
            get { return insurancePolicyNumber; }
            set { SetPropertyValue("InsurancePolicyNumber", ref insurancePolicyNumber, value); }
        }
    }
    public class ForeignEmployee : EmployeeBase {
        public ForeignEmployee(Session session) : base(session) { }
        private DateTime visaExpirationDate;
        public DateTime VisaExpirationDate {
            get { return visaExpirationDate; }
            set { SetPropertyValue("VisaExpirationDate", ref visaExpirationDate, value); }
        }
    }
}