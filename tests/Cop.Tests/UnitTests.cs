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
            // Arrange:
            var dto = new SampleDto
            {
                Name = "Updated name",
                IsActive = false,
                Pets = new List<string> { "updated dog", "updated cat" }
            };

            var now = DateTime.UtcNow;
            var user = User.GetSampleUser();
            var entity = SampleEntity.GetSampleEntity(user, now);

            // Act:
            ICop cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);


            // Assert:
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
            // Arrange:
            var dto = new SampleCopyAlwaysDto
            {
                Name = "Updated name",
                IsActive = false,
                Pets = new List<string> { "updated dog", "updated cat" }
            };

            var now = DateTime.UtcNow;
            var user = User.GetSampleUser();
            var entity = SampleEntity.GetSampleEntity(user, now);

            // Act:
            ICop cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            // Assert:
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
            // Arrange:
            var dto = new SampleSkipIfNullDto
            {
                Name = null,
                IsActive = true,
                Pets = null
            };

            var now = DateTime.UtcNow;
            var user = User.GetSampleUser();
            var entity = SampleEntity.GetSampleEntity(user, now);

            // Act:
            ICop cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            // Assert:
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
            // Arrange:
            var dto = new SampleCopyAllToDifferentTargetDto
            {
                Name = "Rychu",
                Pets = new List<string> { "bird", "unicorn" }
            };

            var now = DateTime.UtcNow;
            var user = User.GetSampleUser();
            var entity = SampleEntity.GetSampleEntity(user, now);

            // Act:
            ICop cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            // Assert:
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
            // Arrange:
            var dto = new SampleSkipIfNullToDifferentTargetDto
            {
                Name = "Rychu",
                Pets = null
            };

            var now = DateTime.UtcNow;
            var user = User.GetSampleUser();
            var entity = SampleEntity.GetSampleEntity(user, now);

            // Act:
            ICop cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            // Assert:
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
            // Arrange:
            var dto = new SampleSkipIfNullToDifferentTargetDto
            {
                Name = "Rychu",
                Pets = null
            };

            var now = DateTime.UtcNow;
            var user = User.GetSampleUser();
            var entity = SampleEntity.GetSampleEntity(user, now);

            // Act:
            ICop cop = new Cop();
            entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);

            // Assert:
            Assert.NotNull(entity.Name);
            Assert.NotNull(entity.Pets);
            Assert.Equal(2, entity.Pets.Count);
            Assert.Equal(1111, entity.CreatedById);
            Assert.Equal(user, entity.CreatedBy);
            Assert.Equal(now, entity.Created);
        }

        [Fact]
        public void Cop_Guard_ThrowsWhenInputNull()
        {
            //Arrange::
            var entity = new object();

            // Act:
            ICop cop = new Cop();

            //Assert:
            Assert.Throws<ArgumentNullException>(() => entity = cop.Copy<object, object>(entity, null));
        }

        [Fact]
        public void Cop_ProceedsWhenNoCopyAttribute()
        {
            // Arrange:
            var entity = new object();

            //Act & Validate don't throws
            ICop cop = new Cop();
            entity = cop.Copy(entity, entity);
        }
    }
}
