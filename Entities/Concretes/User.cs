﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class User : Entity<Guid>
    {
        // duyuru
        // sınav
        // anket
        // başvurular
        // katalog
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsInstructor { get; set; }



        //public PersonalInfo PersonalInfo { get; set; }
        //public List<Skill> Skills { get; set; }
        //public List<Certificate> Certificates { get; set; }
        //public List<SocialMedia> SocialMedias { get; set; }
        //public List<Course> Courses { get; set; } //DAL'da bakılacak. ID'si yok. Migration. ÇOK-ÇOK İlişki.
        //public List<Education> Educations { get; set; }
        //public List<Experience> Experiences { get; set; }
        //public List<ForeignLanguage> ForeignLanguages { get; set; }
    }
}