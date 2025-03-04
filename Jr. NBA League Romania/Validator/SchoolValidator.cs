using System.ComponentModel.DataAnnotations;
using System.Text;
using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Validator;

public class SchoolValidator
{
    private readonly SchoolsRepository _schoolsRepository = new();

    public void ValidateSchool(School school)
    {
        var sb = new StringBuilder();
        var notValid = IdAlreadyExists(sb, school);
        
        if(notValid) throw new ValidationException(sb.ToString());
    }

    private bool IdAlreadyExists(StringBuilder sb, School school)
    {
        if(_schoolsRepository.FindOne(school.Id) == null) return false;
        
        sb.Append($"School with Id {school.Id} already exists.");
        return true;
    }
}