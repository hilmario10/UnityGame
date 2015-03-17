using System;
using System.Collections.Generic;
using System.Linq;
using ProjectLokaverkefni.Models.Transfer;

namespace ProjectLokaverkefni.Models.Transfer
{
	public class AnswersModel
	{
		public int userid {get; set; }
		public int gameid {get; set; }
		public int sceneid {get; set; }
		public int typeid {get; set; }
		public int objectid {get; set; }
		public int correct {get; set; }
		public DateTime answerdate {get; set; }
		public float answertime {get; set; }
		public List<AnswersModel> answersList {get; set; }

		
	}
}
