using System;
using System.Collections.Generic;
using Xunit;

namespace Cop.Tests
{
    public class UnitTests
    {
        [Fact]
        public void Cop_CanCopyPropertiesWithCopyAttribute_SameTargetName()
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
        public void Cop_CanCopyPropertiesWithCopyAttribute_AlwaysCopy_SameTargetName()
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
        public void Cop_CanCopyPropertiesWithCopyAttribute_SkipIfInputNull_SameTargetName()
        {
            var dto = new SampleSkipIfNullDto
            {
                Name = null,
                IsActive = true,
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

        [Fact]
        public void Cop_CanCopyPropertiesWithCopyAttribute_CopyAll_DifferentTargetName()
        {
            var dto = new SampleCopyAllToDifferentTargetDto
            {
                Name = "Rychu",
                Pets = new List<string> { "bird", "unicorn" }
            };

            var now = DateTime.UtcNow;
            var user = GetSampleUser();
            var entity = GetSampleEntity(user, now);

            var cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            Assert.NotNull(entity.Name);
            Assert.Equal("John", entity.Name);
            Assert.NotNull(entity.Pets);
            Assert.Equal(dto.Pets, entity.FavoritePets);
            Assert.Equal(dto.Name, entity.NickName);

            Assert.Equal(1111, entity.CreatedById);
            Assert.Equal(user, entity.CreatedBy);
            Assert.Equal(now, entity.Created);
        }

        [Fact]
        public void Cop_CanCopyPropertiesWithCopyAttribute_SkipIfInputNull_DifferentTargetName()
        {
            var dto = new SampleSkipIfNullToDifferentTargetDto
            {
                Name = "Rychu",
                Pets = null
            };

            var now = DateTime.UtcNow;
            var user = GetSampleUser();
            var entity = GetSampleEntity(user, now);

            var cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            Assert.NotNull(entity.Name);
            Assert.NotNull(entity.Pets);
            Assert.Equal(2, entity.Pets.Count);
            Assert.Equal(1111, entity.CreatedById);
            Assert.Equal(user, entity.CreatedBy);
            Assert.Equal(now, entity.Created);
        }

        [Fact]
        public void Cop_CanCopyAllPropertiesWithCopyAttribute_DifferentTargetName()
        {
            var dto = new SampleSkipIfNullToDifferentTargetDto
            {
                Name = "Rychu",
                Pets = null
            };

            var now = DateTime.UtcNow;
            var user = GetSampleUser();
            var entity = GetSampleEntity(user, now);

            var cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            Assert.NotNull(entity.Name);
            Assert.NotNull(entity.Pets);
            Assert.Equal(2, entity.Pets.Count);
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
