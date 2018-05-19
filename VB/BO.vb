Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace FilterObjectType
	<System.ComponentModel.DefaultProperty("Title")> _
	Public Class Department
		Inherits XPObject
		Private title_Renamed As String
		Private office_Renamed As String
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Property Title() As String
			Get
				Return title_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Title", title_Renamed, value)
			End Set
		End Property
		Public Property Office() As String
			Get
				Return office_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Office", office_Renamed, value)
			End Set
		End Property
		<Association("Department-Employees")> _
		Public ReadOnly Property Employees() As XPCollection(Of EmployeeBase)
			Get
				Return GetCollection(Of EmployeeBase)("Employees")
			End Get
		End Property
	End Class
	Public Class EmployeeBase
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private name_Renamed As String
		Private email_Renamed As String
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Renamed, value)
			End Set
		End Property
		Public Property Email() As String
			Get
				Return email_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Email", email_Renamed, value)
			End Set
		End Property
		Private department_Renamed As Department
		<Association("Department-Employees", GetType(Department))> _
		Public Property Department() As Department
			Get
				Return department_Renamed
			End Get
			Set(ByVal value As Department)
				SetPropertyValue("Department", department_Renamed, value)
			End Set
		End Property
	End Class
	Public Class LocalEmployee
		Inherits EmployeeBase
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private insurancePolicyNumber_Renamed As String
		Public Property InsurancePolicyNumber() As String
			Get
				Return insurancePolicyNumber_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("InsurancePolicyNumber", insurancePolicyNumber_Renamed, value)
			End Set
		End Property
	End Class
	Public Class ForeignEmployee
		Inherits EmployeeBase
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private visaExpirationDate_Renamed As DateTime
		Public Property VisaExpirationDate() As DateTime
			Get
				Return visaExpirationDate_Renamed
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("VisaExpirationDate", visaExpirationDate_Renamed, value)
			End Set
		End Property
	End Class
End Namespace