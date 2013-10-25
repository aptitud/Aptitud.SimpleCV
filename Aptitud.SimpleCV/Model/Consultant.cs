using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Model {
	public class Consultant {

		public Consultant() {
			Skills = new List<Skill>();
			Projects = new List<Project>();
			Educations = new List<Education>();
		}

		public string Id { get; set; }

		private string _name = string.Empty;
		public string Name { get { return _name ?? string.Empty; } set { _name = value; } }

		private string _emailAddress = string.Empty;
		public string EmailAddress { get { return _emailAddress ?? string.Empty; } set { _emailAddress = value; } }

		private string _title = string.Empty;
		public string Title { get { return _title ?? string.Empty; } set { _title = value; } }

		private string _summary = string.Empty;
		public string Summary { get { return _summary ?? string.Empty; } set { _summary = value; } }

		private IEnumerable<Skill> _skills = new List<Skill>();
		public IEnumerable<Skill> Skills { get { return _skills ?? new List<Skill>(); } set { _skills = value; } }

		private IEnumerable<Project> _projects = new List<Project>();
		public IEnumerable<Project> Projects { get { return _projects ?? new List<Project>(); } set { _projects = value; } }

		private IEnumerable<Education> _educations = new List<Education>();
		public IEnumerable<Education> Educations { get { return _educations ?? new List<Education>(); } set { _educations = value; } }

	    public IEnumerable<string> GetSkills(string skillType) {
			return Skills.Where(p => p.SkillType == skillType).Select(p => p.Name);
		}
	}
}
