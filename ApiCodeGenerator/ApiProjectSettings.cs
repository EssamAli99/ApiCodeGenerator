namespace ApiCodeGenerator;

public class ApiProjectSettings
{
    public string ApiProjectName { get; set; } = "test";
    public string ApiName { get; set; } = "test";
    public string ProjectFolder { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string AuthenticationType { get; set; } = "None"; // Default to "None"
    public List<EntityDefinition> Entities { get; set; } = new List<EntityDefinition>();
}

public class EntityDefinition
{
    public string EntityName { get; set; } = "test";
    public List<PropertyDefinition> Properties { get; set; } = new List<PropertyDefinition>();
}

public class PropertyDefinition
{
    public string PropertyName { get; set; } = "test";
    public string PropertyType { get; set; } = "test";
}