using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aptitud.SimpleCV.Repository {
	public class ConsultantRepository {

		public Model.Consultant GetById(string Id) {
			return new Model.Consultant {
				Id = Id,
				FirstName = "Tomas",
				LastName = "Näslund",
				EmailAddress = "tomas.naslund@aptitud.se",
				Title = "Nasare",
				Summary = "Jag är bra",
				
				Skills = new List<Model.Skill> {
					new Model.Skill {
						Name = "C#",
						SkillType = "DevLanguages"
					},
					new Model.Skill {
						Name = "VB.Net",
						SkillType = "DevLanguages"
					},
					new Model.Skill {
						Name = "Scrum",
						SkillType = "Methods"
					},
					new Model.Skill {
						Name = "Entity Framework",
						SkillType = "Frameworks"
					},
					new Model.Skill {
						Name = "WCF",
						SkillType = "Frameworks"
					}
				},

				Educations = new List<Model.Education> {
					new Model.Education {
						Name = "Sälj för Dummies",
						Description = "På denna kurs lärde jag mig allt jag kan!",
						StartDate = new DateTime(2010,1,1),
						EndDate = new DateTime(2010,1,1),
					}
				},
				Projects = new List<Model.Project> {
					new Model.Project {
						Name = "Project 1",
						Description = "Detta är mitt första projekt",
						Customer = "Kund ABC",
						StartDate = new DateTime(2012,1,1),
						EndDate = new DateTime(2012,3,1),
						Skills = new List<Model.Skill> {
							new Model.Skill {
								Name = "C#",
								SkillType = "DevLanguages"
							},
							new Model.Skill {
								Name = "VB.Net",
								SkillType = "DevLanguages"
							},
							new Model.Skill {
								Name = "Scrum",
								SkillType = "Methods"
							},
							new Model.Skill {
								Name = "Entity Framework",
								SkillType = "Frameworks"
							},
							new Model.Skill {
								Name = "WCF",
								SkillType = "Frameworks"
							}
						}	
					},
					new Model.Project {
						Name = "Project 2",
						Description = "Detta är mitt andra projekt",
						Customer = "Kund XXX",
						StartDate = new DateTime(2012,4,1),
						EndDate = new DateTime(2013,3,1),
						Skills = new List<Model.Skill> {
							new Model.Skill {
								Name = "Scrum",
								SkillType = "Methods"
							},
							new Model.Skill {
								Name = "Entity Framework",
								SkillType = "Frameworks"
							},
							new Model.Skill {
								Name = "WCF",
								SkillType = "Frameworks"
							}
						}	
					}
				}
			};
		}
	}
}