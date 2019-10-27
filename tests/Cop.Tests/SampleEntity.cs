using System;
using System.Collections.Generic;

namespace Cop.Tests
{
    public class SampleEntity
    {
        public virtual Guid Guid { get; set; }
        [Copy]
        public virtual string Name { get; set; }
        [Copy]
        public virtual bool IsActive { get; set; }
        [Copy]
        public virtual List<string> Pets { get; set; }
        [Copy]
        public virtual List<string> FavoritePets { get; set; }
        public virtual DateTime Created { get; set; }
        [Copy]
        public virtual string NickName { get; set; }
        public virtual int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        public static SampleEntity GetSampleEntity(User user, DateTime now)
            => new SampleEntity
            {
                Guid = Guid.NewGuid(),
                Name = "John",
                IsActive = true,
                Pets = new List<string> { "dog", "cat" },
                Created = now,
                CreatedById = 1111,
                CreatedBy = user
            };
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public static User GetSampleUser()
            => new User
            {
                Id = 1111,
                Name = "John",
                Lastname = "Kowalsky"
            };
    }
}
