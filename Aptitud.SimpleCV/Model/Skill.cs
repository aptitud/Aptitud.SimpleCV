using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Model {
	public class Skill {
        public Skill(string name, String skillType)
        {
            Name = name;
            SkillType = skillType;
        }
		public string Name { get; set; }
		public string SkillType { get; set; }
	}
}
