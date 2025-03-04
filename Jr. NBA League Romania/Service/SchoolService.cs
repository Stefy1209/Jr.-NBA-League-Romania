using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;
using Jr._NBA_League_Romania.Validator;

namespace Jr._NBA_League_Romania.Service;

public class SchoolService
{
    private readonly SchoolsRepository _schoolsRepository = new();
    private readonly SchoolValidator _schoolValidator = new();

    public void SaveSchool(Guid id, string name)
    {
        var school = new School(id, name);
        
        _schoolValidator.ValidateSchool(school);
        
        _schoolsRepository.Save(school);
    }
}