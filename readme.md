### CI Status
![](https://github.com/MadSciencist/Cop/workflows/ci/badge.svg)

### What is Cop?
Cop is a simple, zero-dependencies, reflection based solution for automatical property copying. It's usefull when mapping DTO's to domain entities but unlike Automapper it does not create new object. This might benefit when user wants to update an entity, but we do not wan't to map all properties (i.e. skip some safty properties like CreatedBy, Roles and so on).

### How to use Cop?
The goal was to make it simple.

First, add [Copy] attribute on your DTO and entity, then simple call:

```csharp
ICop cop = new Cop();
entity = cop.Copy<SampleEntity, SampleDto>(entity, dto);
```

By default, it uses naming convention.
The entity and DTO should be decorated with [Copy] attribute as follows:
```csharp
    public class SampleEntity
    {
        [Copy]
        public string Name { get; set; }

        [Copy]
        public List<string> Pets { get; set; }

        [Copy]
        public List<string> FavoritePets { get; set; }

        public int CreatedById { get; set; }
    }
```
Only those properties can be targets of mappings. Otherwise Cop will throw.

The DTO might look like this:
```csharp
        [Copy]
        public string Name { get; set; }

        [Copy(CopyOption.SkipIfInputNull)]
        public List<string> Pets { get; set; }

        [Copy(nameof(SampleEntity.FavoritePets))]
        public List<string> OtherPets { get; set; }

    }
```
That means:
 *  The value of Name property of DTO will be applied to the Name property of Entity (always by default);
 *  The Pets list will be applied to Pets list only if DTO pets list is not null;
 *  The OtherPets list wiill be applied to FavoritePets lists on the entity object (here we are breaking default naming convention);
 *  The CreatedById property will stay untauched.

Simple as that!