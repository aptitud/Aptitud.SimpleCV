using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Model {
	public class Project {
		public string Name { get; set; }
		public string Description { get; set; }
		public string Customer { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public IEnumerable<Skill> Skills { get; set; }

		public IEnumerable<string> GetSkills(string skillType) {
			return Skills.Where(p => p.SkillType == skillType).Select(p => p.Name);
		}

	}
}
