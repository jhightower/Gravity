using System;
using System.Diagnostics;
using Gravity.Test.TestClasses;

namespace GravityDemo
{
	public partial class Program
	{
		static void Query(int artifactId)
		{
			var gravityLevelOneParentOnly = rsapiDao.Get<GravityLevelOne>(artifactId, Gravity.Base.ObjectFieldsDepthLevel.OnlyParentObject);
			var nameFieldGuid = Guid.Parse("E1FA93B9-C2DB-442A-9978-84EEB6B61A3F");
			var textCondition = new kCura.Relativity.Client.TextCondition(nameFieldGuid, kCura.Relativity.Client.TextConditionEnum.EqualTo, gravityLevelOneParentOnly.Name);
			var gravityLevelOnes = rsapiDao.Query<GravityLevelOne>(textCondition, Gravity.Base.ObjectFieldsDepthLevel.OnlyParentObject);
			Console.WriteLine(ObjectDumper.Dump(gravityLevelOnes));
		}
	}
}
