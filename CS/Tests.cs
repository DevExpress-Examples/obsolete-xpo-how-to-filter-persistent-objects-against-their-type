using System;
using System.Data;
using DevExpress.Xpo;
using NUnit.Framework;
using DevExpress.Xpo.DB;
using DevExpress.Data.Filtering;

namespace FilterObjectType {
    public abstract class BaseXpoTest {
        private UnitOfWork session;
        protected DataSet dataSet;
        [SetUp]
        public virtual void SetUp() {
            DevExpress.Xpo.Session.DefaultSession.Disconnect();
            dataSet = new DataSet();
            XpoDefault.DataLayer = new SimpleDataLayer(new DataSetDataStore(dataSet, AutoCreateOption.SchemaOnly));
            session = new UnitOfWork();
        }
        protected Session CreateSession() {
            return new UnitOfWork();
        }
        public UnitOfWork Session {
            get { return session; }
        }
    }
    [TestFixture]
    public class FilterObjectTypeTests : BaseXpoTest {
        [Test]
        public void TestSimple() {
            Department dept = new Department(Session);
            dept.Title = "Test Department";
            LocalEmployee local = new LocalEmployee(Session);
            local.Name = "LocalEmployee";
            ForeignEmployee foreign = new ForeignEmployee(Session);
            foreign.Name = "ForeignEmployee";
            dept.Employees.Add(local);
            dept.Employees.Add(foreign);
            Session.CommitChanges();

            XPCollection<EmployeeBase> employees = new XPCollection<EmployeeBase>(Session);
            Assert.IsTrue(employees.Count == 2);
            employees.Criteria = PersistentBase.Fields.ObjectType.TypeName == typeof(ForeignEmployee).FullName;
            //OR
            //employees.Criteria = CriteriaOperator.Parse("ObjectType.TypeName=?", typeof(ForeignEmployee).FullName);
            Assert.IsTrue(employees.Count == 1);
        }
    }
}
