Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports DevExpress.Xpo
Imports NUnit.Framework
Imports DevExpress.Xpo.DB
Imports DevExpress.Data.Filtering

Namespace FilterObjectType
	Public MustInherit Class BaseXpoTest
		Private session_Renamed As UnitOfWork
		Protected dataSet As DataSet
		<SetUp> _
		Public Overridable Sub SetUp()
			DevExpress.Xpo.Session.DefaultSession.Disconnect()
			dataSet = New DataSet()
			XpoDefault.DataLayer = New SimpleDataLayer(New DataSetDataStore(dataSet, AutoCreateOption.SchemaOnly))
			session_Renamed = New UnitOfWork()
		End Sub
		Protected Function CreateSession() As Session
			Return New UnitOfWork()
		End Function
		Public ReadOnly Property Session() As UnitOfWork
			Get
				Return session_Renamed
			End Get
		End Property
	End Class
	<TestFixture> _
	Public Class FilterObjectTypeTests
		Inherits BaseXpoTest
		<Test> _
		Public Sub TestSimple()
			Dim dept As New Department(Session)
			dept.Title = "Test Department"
			Dim local As New LocalEmployee(Session)
			local.Name = "LocalEmployee"
			Dim foreign As New ForeignEmployee(Session)
			foreign.Name = "ForeignEmployee"
			dept.Employees.Add(local)
			dept.Employees.Add(foreign)
			Session.CommitChanges()

			Dim employees As New XPCollection(Of EmployeeBase)(Session)
			Assert.IsTrue(employees.Count = 2)
			employees.Criteria = PersistentBase.Fields.ObjectType.TypeName = GetType(ForeignEmployee).FullName
			'OR
			'employees.Criteria = CriteriaOperator.Parse("ObjectType.TypeName=?", GetType(ForeignEmployee).FullName)
			Assert.IsTrue(employees.Count = 1)
		End Sub
	End Class
End Namespace
