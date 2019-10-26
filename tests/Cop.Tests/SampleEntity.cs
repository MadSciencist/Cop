using System;
using System.Collections.Generic;

namespace Cop.Tests
{
    public class SampleDto
    {
        public virtual Guid Guid { get; set; }
        [Copy]
        public virtual string Name { get; set; }
        [Copy]
        public virtual bool IsActive { get; set; }
        [Copy]
        public virtual List<string> Pets { get; set; }
    }

    public class SampleCopyAlwaysDto : SampleDto
    {
        [Copy(CopyOption.CopyAlways)]
        public override string Name { get; set; }
        [Copy(CopyOption.CopyAlways)]
        public override List<string> Pets { get; set; }
        [Copy(CopyOption.CopyAlways)]
        public override bool IsActive { get; set; }
    }

    public class SampleSkipIfNullDto : SampleDto
    {
        [Copy(CopyOption.SkipIfInputNull)]
        public override string Name { get; set; }
        [Copy(CopyOption.SkipIfInputNull)]
        public override List<string> Pets { get; set; }
        [Copy(CopyOption.SkipIfInputNull)]
        public override bool IsActive { get; set; }
    }

    public class SampleCopyAllToDifferentTargetDto : SampleDto
    {
        [Copy(nameof(SampleEntity.NickName))]
        public override string Name { get; set; }
        [Copy(nameof(SampleEntity.FavoritePets))]
        public override List<string> Pets { get; set; }
    }

    public class SampleSkipIfNullToDifferentTargetDto : SampleDto
    {
        [Copy(nameof(SampleEntity.NickName), CopyOption.SkipIfInputNull)]
        public override string Name { get; set; }
        [Copy(nameof(SampleEntity.FavoritePets), CopyOption.SkipIfInputNull)]
        public override List<string> Pets { get; set; }
    }

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
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
