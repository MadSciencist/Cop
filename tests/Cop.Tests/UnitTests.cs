using System;
using System.Collections.Generic;
using Xunit;

namespace Cop.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Cop_CanCopyPropertiesWithCopyAttributeAndSameName()
        {
            var dto = new SampleDto
            {
                Name = "Updated name",
                IsActive = false,
                Pets = new List<string> { "updated dog", "updated cat" }
            };

            var now = DateTime.UtcNow;
            var user = GetSampleUser();
            var entity = GetSampleEntity(user, now);

            var cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            Assert.Equal(entity.Name, dto.Name);
            Assert.Equal(entity.IsActive, dto.IsActive);
            Assert.Equal(entity.Pets, dto.Pets);

            Assert.Equal(1111, entity.CreatedById);
            Assert.Equal(user, entity.CreatedBy);
            Assert.Equal(now, entity.Created);
        }

        [Fact]
        public void Cop_CanCopyPropertiesWithCopyAttribute_AlwaysCopy_AndSameName()
        {
            var dto = new SampleCopyAlwaysDto
            {
                Name = "Updated name",
                IsActive = false,
                Pets = new List<string> { "updated dog", "updated cat" }
            };

            var now = DateTime.UtcNow;
            var user = GetSampleUser();
            var entity = GetSampleEntity(user, now);

            var cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            Assert.Equal(entity.Name, dto.Name);
            Assert.Equal(entity.IsActive, dto.IsActive);
            Assert.Equal(entity.Pets, dto.Pets);

            Assert.Equal(1111, entity.CreatedById);
            Assert.Equal(user, entity.CreatedBy);
            Assert.Equal(now, entity.Created);
        }

        [Fact]
        public void Cop_CanCopyPropertiesWithCopyAttribute_SkipIfInputNull_AndSameName()
        {
            var dto = new SampleCopyAlwaysDto
            {
                Name = null,
                IsActive = false,
                Pets = null
            };

            var now = DateTime.UtcNow;
            var user = GetSampleUser();
            var entity = GetSampleEntity(user, now);

            var cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            Assert.NotNull(entity.Name);
            Assert.NotNull(entity.Pets);
            Assert.Equal(entity.IsActive, dto.IsActive);

            Assert.Equal(1111, entity.CreatedById);
            Assert.Equal(user, entity.CreatedBy);
            Assert.Equal(now, entity.Created);
        }

        private static User GetSampleUser()
            => new User
            {
                Id = 1111,
                Name = "John",
                Lastname = "Kowalsky"
            };

        private static SampleEntity GetSampleEntity(User user, DateTime now)
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
}
