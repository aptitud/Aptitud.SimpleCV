using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Model {
	public class Consultant {
		public string Id { get; set; }
		
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Title { get; set; }

		public string Summary { get; set; }
		public IEnumerable<Skill> Skills { get; set; }
		public IEnumerable<Project> Projects { get; set; }
		public IEnumerable<Education> Educations { get; set; }

		public IEnumerable<string> GetSkills(string skillType) {
			return Skills.Where(p => p.SkillType == skillType).Select(p => p.Name);
		}
	}
}
