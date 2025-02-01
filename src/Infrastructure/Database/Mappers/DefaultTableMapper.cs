using DapperExtensions.Mapper;

namespace Infrastructure.Database.Mappers;

public class DefaultTableMapper<T> : AutoClassMapper<T> where T : class 
{
    private const string entitySufix = "Entity";

    public override void Table(string tableName)
    {
        tableName = tableName.Replace(entitySufix, string.Empty);
        
        base.Table(tableName);
    }
}
