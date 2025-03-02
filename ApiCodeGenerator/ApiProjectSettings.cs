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
    public string PropertyName { get; set; } = string.Empty;
    public string PropertyType { get; set; } = string.Empty;
    public bool Required { get; set; } = false;
    public int? MaxLength { get; set; } = null;
    public int? MinLength { get; set; } = null;
    public bool EmailAddress { get; set; } = false;
    public double? RangeMin { get; set; } = null;
    public double? RangeMax { get; set; } = null;
    public string RegexPattern { get; set; } = string.Empty;
}