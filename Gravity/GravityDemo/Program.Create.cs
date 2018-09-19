using System;
using System.Collections.Generic;
using Gravity.Test.Helpers;
using Gravity.Test.TestClasses;
using Relativity.Test.Helpers;

namespace GravityDemo
{
	public partial class Program
	{
		static int Create()
		{
			var gravityLevel3 = new Gravity.Test.TestClasses.GravityLevel3 {
				Name = $"GravityLevel3-{Guid.NewGuid()}",
			};

			var gravityLevel2 = new Gravity.Test.TestClasses.GravityLevel2 {
				Name = $"GravityLevel2-{Guid.NewGuid()}",
				GravityLevel3SingleObj = gravityLevel3
			};

			var gravityLevelOne = new Gravity.Test.TestClasses.GravityLevelOne {
				Name = $"GravityLevelOne-{Guid.NewGuid()}",
				GravityLevel2Obj = gravityLevel2,
				MultipleChoiceFieldChoices = new[] { MultipleChoiceFieldChoices.MultipleChoice2, MultipleChoiceFieldChoices.MultipleChoice3 }
			};

			return rsapiDao.Insert(gravityLevelOne, Gravity.Base.ObjectFieldsDepthLevel.FullyRecursive);
		}
	}
}
