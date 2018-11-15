<!-- default file list -->
*Files to look at*:

* [BO.cs](./CS/BO.cs) (VB: [BO.vb](./VB/BO.vb))
* [Tests.cs](./CS/Tests.cs) (VB: [Tests.vb](./VB/Tests.vb))
<!-- default file list end -->
# OBSOLETE - How to filter persistent objects against their type


<p><strong>===================================================</strong><br /><strong>This example is now obsolete. Refer to the following documentation articles for more details:</strong><br /><strong><u><a href="http://documentation.devexpress.com/#XPO/CustomDocument2632">When and Why XPO Extends the Database Schema</a></u></strong><br /><strong><u><a href="http://documentation.devexpress.com/#XPO/CustomDocument7548">How to: Filter Persistent Objects by Type</a><br /><a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoMetadataIsInstanceOfTypeFunctiontopic">IsInstanceOfTypeFunction Class</a> <br /><a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoMetadataIsExactTypeFunctiontopic">IsExactTypeFunction Class</a><br /></u>===================================================<br />Scenario</strong></p>
<p>We have a Department object that has a collection of Employees. Employees can be either objects of the <em>LocalEmployee</em> or <em>ForeignEmployee </em>types - descendants of the <em>EmployeeBase </em>class.<br /> Our goal is to filter out a collection of employees by their type in code. In addition, there should be a capability to easily determine the employee type if a collection of <em>EmployeeBase </em>records is shown in the UI, e.g., by having a computed string property that returns the actual object type name.</p>
<br />
<p><strong>Solution</strong><br /> To filter by the type, employ the service <em>ObjectType</em> field (or <em>ObjectType.TypeName</em>) or built-in <em>IsExactType</em><em>, IsInstanceOfType</em> criteria functions provided by XPO.<br /> Take special note that you can use these means with the <a href="http://documentation.devexpress.com/#XPO/clsDevExpressXpoPersistentAliasAttributetopic"><u>PersistentAliasAttribute</u></a> for filtering on the server side (see the <em>EntityType </em>property within the <em>EmployeeBase </em>class).<br /> Check out the attached sample for a complete implementation and unit tests for this functionality.<br /><strong><br />IMPORTANT NOTES</strong></p>
<p>This sample requires <a href="http://www.nunit.org/index.php"><u>NUnit Framework</u></a>.</p>
<p><strong>See Also:</strong><br /> <a href="http://documentation.devexpress.com/#XPO/CustomDocument4928"><u>Criteria Language Syntax</u></a><br /> <a href="http://documentation.devexpress.com/#XPO/CustomDocument2537"><u>Simplified Criteria Syntax</u></a><br /> <a href="http://documentation.devexpress.com/#XPO/CustomDocument2650"><u>UpCasting</u></a></p>

<br/>


