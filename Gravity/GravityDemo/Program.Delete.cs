using System;
using Gravity.Test.Helpers;
using Gravity.Test.TestClasses;
using Relativity.Test.Helpers;

namespace GravityDemo
{
	public partial class Program
	{
		static void Delete(int artifactId)
		{
			//var gravityLevelOne = rsapiDao.Get<GravityLevelOne>(artifactId, Gravity.Base.ObjectFieldsDepthLevel.FullyRecursive);
			rsapiDao.Delete<GravityLevelOne>(artifactId, Gravity.Base.ObjectFieldsDepthLevel.FullyRecursive);
		}
	}
}
