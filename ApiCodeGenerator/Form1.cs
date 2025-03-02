using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Text;
using Scriban;
using Scriban.Runtime;
using System.Diagnostics;

namespace ApiCodeGenerator;

public partial class frmMain : Form
{
    private ApiProjectSettings _settings = new ApiProjectSettings(); // Store settings in memory

    public frmMain()
    {
        InitializeComponent();
        // Initially show only Screen 1
        pnlScreen2.Visible = false;
        pnlScreen3.Visible = false;
        pnlScreen1.Dock = DockStyle.Fill;
        pnlScreen1.Location = new Point(0, 0);

        // Populate AuthType dropdown
        ddlAuthType.Items.Add("None");
        ddlAuthType.Items.Add("JWT");
        ddlAuthType.Items.Add("API Keys");
        ddlAuthType.Items.Add("OAuth 2.0");
        ddlAuthType.SelectedItem = "None"; // Set default selection
    }

    private void ShowPanel(Panel panelToShow)
    {
        // Hide all panels first
        pnlScreen1.Visible = false;
        pnlScreen2.Visible = false;
        pnlScreen3.Visible = false;

        // Show the desired panel
        panelToShow.Visible = true;
        panelToShow.Dock = DockStyle.Fill;
        panelToShow.Location = new Point(0, 0); // Ensure it starts at top-left
    }

    private void btnNext1_Click(object sender, EventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(txtApiProjectName.Text) ||
            string.IsNullOrWhiteSpace(txtApiName.Text) ||
            string.IsNullOrWhiteSpace(txtProjectFolder.Text))
        {
            MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; // Stop execution if validation fails
        }

        // Populate settings
        _settings.ApiProjectName = txtApiProjectName.Text;
        _settings.ApiName = txtApiName.Text;
        _settings.ProjectFolder = txtProjectFolder.Text;

        // Save to JSON file
        string jsonFilePath = Path.Combine(Environment.CurrentDirectory, "settings.json");

        try
        {
            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented); // Formatting.Indented for readability

            // Create the file if it doesn't exist, and overwrite if it does
            File.WriteAllText(jsonFilePath, json);

            // Navigate to the next screen
            ShowPanel(pnlScreen2);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnNext2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtConnectionString.Text))
        {
            MessageBox.Show("Connection string is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        _settings.ConnectionString = txtConnectionString.Text;
        _settings.AuthenticationType = ddlAuthType.SelectedItem?.ToString() ?? "None"; // Save Authentication 

        string jsonFilePath = Path.Combine(Environment.CurrentDirectory, "settings.json");

        try
        {
            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented); // Formatting.Indented for readability

            // Create the file if it doesn't exist, and overwrite if it does
            File.WriteAllText(jsonFilePath, json);

            // Navigate to the next screen
            LoadEntities();
            ShowPanel(pnlScreen3);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving settings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnPrevious2_Click(object sender, EventArgs e)
    {
        ShowPanel(pnlScreen1);
    }

    private void btnPrevious3_Click(object sender, EventArgs e)
    {
        ShowPanel(pnlScreen2);
    }

    private void btnTestConnection_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(txtConnectionString.Text))
            {
                connection.Open();
                MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadEntities()
    {
        checkedListBoxEntities.Items.Clear(); // Clear existing items

        try
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                connection.Open();

                // SQL query to retrieve tables and views
                string query = @"
                        SELECT TABLE_NAME, TABLE_TYPE
                        FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_TYPE IN ('BASE TABLE', 'VIEW')
                        ORDER BY TABLE_NAME;";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tableName = reader["TABLE_NAME"].ToString();
                        string tableType = reader["TABLE_TYPE"].ToString();

                        // Add the table/view name to the CheckedListBox
                        checkedListBoxEntities.Items.Add(tableName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading entities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
        // Get the selected entities from the CheckedListBox
        List<string> selectedEntities = new List<string>();
        foreach (var item in checkedListBoxEntities.CheckedItems)
        {
            selectedEntities.Add(item.ToString());
        }

        // Generate the entity classes
        GenerateEntityClasses(selectedEntities);
    }

    private void GenerateEntityClasses(List<string> entityNames)
    {
        string projectFolder = _settings.ProjectFolder;
        string entitiesFolder = Path.Combine(projectFolder, "Entities");
        string dataFolder = Path.Combine(projectFolder, "Data");
        string repositoriesFolder = Path.Combine(dataFolder, "Repositories");
        string specificationsFolder = Path.Combine(dataFolder, "Specifications");
        string configurationsFolder = Path.Combine(dataFolder, "Configurations");
        string modelsFolder = Path.Combine(projectFolder, "Models");
        string servicesFolder = Path.Combine(projectFolder, "Services");
        string controllersFolder = Path.Combine(projectFolder, "Controllers");
        string validationFolder = Path.Combine(projectFolder, "Validation");

        // Create directories if they don't exist
        Directory.CreateDirectory(entitiesFolder);
        Directory.CreateDirectory(dataFolder);
        Directory.CreateDirectory(repositoriesFolder);
        Directory.CreateDirectory(specificationsFolder);
        Directory.CreateDirectory(configurationsFolder);
        Directory.CreateDirectory(modelsFolder);
        Directory.CreateDirectory(servicesFolder);
        Directory.CreateDirectory(controllersFolder);
        Directory.CreateDirectory(validationFolder);
        
        try
        {
            using (SqlConnection connection = new SqlConnection(_settings.ConnectionString))
            {
                connection.Open();

                // Step 1: Retrieve Entities Properties and update the _settings.Entities List
                _settings.Entities.Clear(); // Clear any existing entities
                foreach (string entityName in entityNames)
                {
                    // Get the properties for the entity
                    List<PropertyDefinition> properties = GetEntityProperties(connection, entityName);
                    _settings.Entities.Add(new EntityDefinition { EntityName = entityName, Properties = properties });
                }
            }
        
            GenerateValidators(projectFolder);

            // Step 2: Generate Api Project File
            GenerateApiProjectFile(projectFolder);

            // Step 3: Generate Program File
            GenerateProgramFile(projectFolder);

            // Step 4: Generate appSettings File
            GenerateAppSettingsFile(projectFolder);

            // Step 5: Generate DbContext
            GenerateDbContextFile(projectFolder, dataFolder);

            // Step 6: Generate Entity Configuration files
            GenerateEntityConfigurationFiles(projectFolder, dataFolder);

            // Step 7: Generate Entity Classes
            GenerateEntities(projectFolder, entitiesFolder);

            // Step 8: Generate Controllers
            GenerateControllers(projectFolder);

            // Step 9: Copy Repository and Specification files
            CopyRepositoryAndSpecificationFiles(projectFolder);

            // Step 10: Generate ApiKey authentication options if selected
            if (_settings.AuthenticationType == "API Keys")
            {
                GenerateApiKeyOptions(servicesFolder);
            }

            MessageBox.Show("Entities generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error generating entities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void GenerateValidators(string projectFolder)
    {
        string validatorsFolder = Path.Combine(projectFolder, "Validation");
        Directory.CreateDirectory(validatorsFolder); // Create folder if it doesn't exists

        foreach (var entity in _settings.Entities)
        {
            string validatorCode = GenerateValidatorCode(entity);
            string validatorFilePath = Path.Combine(validatorsFolder, $"{entity.EntityName}Validator.cs");
            File.WriteAllText(validatorFilePath, validatorCode);
        }
    }

    private string GenerateValidatorCode(EntityDefinition entity)
    {
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "ValidatorTemplate.txt");
        string templateContent = File.ReadAllText(templatePath);

        // Create a Scriban template
        var template = Template.Parse(templateContent);

        // Create a Scriban template context
        var context = new TemplateContext();
        var scriptObject = new ScriptObject();

        // Add the data to the template context
        scriptObject.Add("ApiName", _settings.ApiName);
        scriptObject.Add("EntityName", entity.EntityName);
        scriptObject.Add("Properties", entity.Properties);
        context.PushGlobal(scriptObject);

        // Render the template
        string validatorCode = template.Render(context);

        return validatorCode;
    }

    private void GenerateApiKeyOptions(string servicesFolder)
    {
        string sourceFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates"); // Assuming "Templates" folder is in the same directory as the executable

        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "ApiKeyAuthenticationOptions.txt"), Path.Combine(servicesFolder, "ApiKeyAuthenticationOptions.cs"));
        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "ApiKeyAuthFilter.txt"), Path.Combine(servicesFolder, "ApiKeyAuthFilter.cs"));

    }

    // New Methods:

    private void GenerateAppSettingsFile(string projectFolder)
    {
        string appSettingsTemplate = @"{
  ""ConnectionStrings"": {
    ""DefaultConnection"": """ + _settings.ConnectionString.Replace(@"\", @"\\") + @"""
  },
  ""Logging"": {
    ""LogLevel"": {
      ""Default"": ""Information"",
      ""Microsoft.AspNetCore"": ""Warning""
    }
  },
  ""AllowedHosts"": ""*"",
  ""Jwt"": {
    ""Key"": ""YourSuperSecretKeyHere"",
    ""Issuer"": ""yourdomain.com"",
    ""Audience"": ""yourdomain.com""
  },
  ""ApiSettings"": {
    ""ApiKey"": ""YourSecureApiKey""
    },
  ""OAuth2"": {
    ""Authority"": ""your_oauth2_authority"",
    ""ClientId"": ""your_client_id"",
    ""ClientSecret"": ""your_client_secret"",
    ""Scope"": ""openid profile email""
  }
}";

        string appSettingsFilePath = Path.Combine(projectFolder, "appsettings.json");
        File.WriteAllText(appSettingsFilePath, appSettingsTemplate, Encoding.UTF8);
    }

    private void GenerateControllers(string projectFolder)
    {
        foreach (var entity in _settings.Entities)
        {
            GenerateController(projectFolder, entity);
        }
        // Generate Account Controller if authentication is enabled
        if (_settings.AuthenticationType != "None")
        {
            GenerateAccountController(projectFolder);
        }
    }
    private void GenerateAccountController(string projectFolder)
    {
        string controllersFolder = Path.Combine(projectFolder, "Controllers");
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "AccountControllerTemplate.txt");
        string templateContent = File.ReadAllText(templatePath);

        // Create a Scriban template
        var template = Template.Parse(templateContent);

        // Create a Scriban template context
        var context = new TemplateContext();
        var scriptObject = new ScriptObject();

        // Add the data to the template context
        scriptObject.Add("ApiName", _settings.ApiName);
        scriptObject.Add("AuthenticationType", _settings.AuthenticationType);
        context.PushGlobal(scriptObject);

        // Render the template
        string controllerCode = template.Render(context);

        string controllerFilePath = Path.Combine(controllersFolder, "AccountController.cs");
        File.WriteAllText(controllerFilePath, controllerCode);
    }
    private void CopyRepositoryAndSpecificationFiles(string projectFolder)
    {
        string sourceFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates"); // Assuming "Templates" folder is in the same directory as the executable
        string dataFolder = Path.Combine(projectFolder, "Data");
        string repositoriesFolder = Path.Combine(dataFolder, "Repositories");
        string specificationsFolder = Path.Combine(dataFolder, "Specifications");

        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "IGenericRepository.txt"), Path.Combine(repositoriesFolder, "IGenericRepository.cs"));
        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "GenericRepository.txt"), Path.Combine(repositoriesFolder, "GenericRepository.cs"));
        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "ISpecification.txt"), Path.Combine(specificationsFolder, "ISpecification.cs"));
        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "BaseSpecification.txt"), Path.Combine(specificationsFolder, "BaseSpecification.cs"));
        CopyAndReplaceNamespace(Path.Combine(sourceFolder, "SpecificationEvaluator.txt"), Path.Combine(specificationsFolder, "SpecificationEvaluator.cs"));
    }

    private void CopyAndReplaceNamespace(string sourceFilePath, string destinationFilePath)
    {
        try
        {
            string content = File.ReadAllText(sourceFilePath);
            content = content.Replace("<#= ApiName #>", _settings.ApiName); // Replace the placeholder

            File.WriteAllText(destinationFilePath, content);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error copying file {sourceFilePath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void GenerateDbContextFile(string projectFolder, string dataFolder)
    {
        string dbContextCode = GenerateDbContextCode(_settings.ApiName, _settings.Entities);
        string dbContextFilePath = Path.Combine(dataFolder, $"{_settings.ApiName}DbContext.cs");
        File.WriteAllText(dbContextFilePath, dbContextCode);
    }

    private void GenerateEntityConfigurationFiles(string projectFolder, string dataFolder)
    {
        string configurationsFolder = Path.Combine(dataFolder, "Configurations");
        foreach (var entity in _settings.Entities)
        {
            string entityConfigurationCode = GenerateEntityConfigurationCode(_settings.ApiName, entity);
            string entityConfigurationFilePath = Path.Combine(configurationsFolder, $"{entity.EntityName}Configuration.cs");
            File.WriteAllText(entityConfigurationFilePath, entityConfigurationCode);
        }
    }

    private void GenerateEntities(string projectFolder, string entitiesFolder)
    {
        foreach (var entity in _settings.Entities)
        {
            // Generate the C# code for the entity class using String Builder
            string classCode = GenerateClassCode(entity.EntityName, entity.Properties);

            // Save the code to a file
            string filePath = Path.Combine(entitiesFolder, $"{entity.EntityName}.cs");
            File.WriteAllText(filePath, classCode);
        }
    }

    private List<PropertyDefinition> GetEntityProperties(SqlConnection connection, string entityName)
    {
        List<PropertyDefinition> properties = new List<PropertyDefinition>();

        string query = $@"
                SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = '{entityName}'";

        using (SqlCommand command = new SqlCommand(query, connection))
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string columnName = reader["COLUMN_NAME"].ToString();
                string dataType = reader["DATA_TYPE"].ToString();
                string propertyType = MapSqlTypeToCSharpType(dataType);

                //properties.Add(new PropertyDefinition { PropertyName = columnName, PropertyType = propertyType });

                string isNullable = reader["IS_NULLABLE"].ToString().ToUpper();
                string maxLength = reader["CHARACTER_MAXIMUM_LENGTH"].ToString();

                PropertyDefinition property = new PropertyDefinition { PropertyName = columnName, PropertyType = propertyType };

                if (isNullable == "NO")
                {
                    property.Required = true;
                }

                if (!string.IsNullOrEmpty(maxLength) && int.TryParse(maxLength, out int maxLen))
                {
                    property.MaxLength = maxLen;
                }

                properties.Add(property);
            }
        }

        return properties;
    }

    private string MapSqlTypeToCSharpType(string sqlType)
    {
        switch (sqlType.ToLower())
        {
            case "int":
                return "int";
            case "bigint":
                return "long";
            case "smallint":
                return "short";
            case "tinyint":
                return "byte";
            case "varchar":
            case "nvarchar":
            case "char":
            case "nchar":
            case "text":
            case "ntext":
                return "string";
            case "decimal":
                return "decimal";
            case "money":
                return "decimal";
            case "smallmoney":
                return "decimal";
            case "float":
                return "double";
            case "real":
                return "float";
            case "datetime":
                return "DateTime";
            case "smalldatetime":
                return "DateTime";
            case "datetime2":
                return "DateTime";
            case "date":
                return "DateOnly";
            case "time":
                return "TimeOnly";
            case "bit":
                return "bool";
            case "uniqueidentifier":
                return "Guid";
            case "varbinary":
                return "byte[]";
            default:
                return "object"; // Unknown type
        }
    }

    private string GenerateClassCode(string className, List<PropertyDefinition> properties)
    {
        string code = $@"
using System;

namespace {_settings.ApiName}.Entities
{{
    public class {className}
    {{";

        foreach (var property in properties)
        {
            code += $@"
        public {property.PropertyType} {property.PropertyName} {{ get; set; }}";
        }

        code += @"
    }
}";

        return code;
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        if (fbdAppFolder.ShowDialog() == DialogResult.OK)
        {
            txtProjectFolder.Text = fbdAppFolder.SelectedPath;
        }
    }

    private string GenerateDbContextCode(string apiName, List<EntityDefinition> entities)
    {
        StringBuilder code = new StringBuilder();

        code.AppendLine("using Microsoft.EntityFrameworkCore;");
        code.AppendLine($"using {apiName}.Entities;");
        code.AppendLine($"using {apiName}.Data.Configurations;");
        code.AppendLine();
        code.AppendLine($"namespace {apiName}.Data");
        code.AppendLine("{");
        code.AppendLine($"    public class {apiName}DbContext : DbContext");
        code.AppendLine("    {");
        code.AppendLine($"        public {apiName}DbContext(DbContextOptions<{apiName}DbContext> options) : base(options)");
        code.AppendLine("        {");
        code.AppendLine("        }");
        code.AppendLine();

        foreach (var entity in entities)
        {
            code.AppendLine($"        public DbSet<{entity.EntityName}> {entity.EntityName}s {{ get; set; }}");
        }

        code.AppendLine();
        code.AppendLine("        protected override void OnModelCreating(ModelBuilder modelBuilder)");
        code.AppendLine("        {");
        foreach (var entity in entities)
        {
            code.AppendLine($"            modelBuilder.ApplyConfiguration(new {entity.EntityName}Configuration());");
        }
        code.AppendLine("        }");
        code.AppendLine("    }");
        code.AppendLine("}");

        return code.ToString();
    }

    private string GenerateEntityConfigurationCode(string apiName, EntityDefinition entity)
    {
        StringBuilder code = new StringBuilder();

        code.AppendLine("using Microsoft.EntityFrameworkCore;");
        code.AppendLine("using Microsoft.EntityFrameworkCore.Metadata.Builders;");
        code.AppendLine($"using {apiName}.Entities;");
        code.AppendLine();
        code.AppendLine($"namespace {apiName}.Data.Configurations");
        code.AppendLine("{");
        code.AppendLine($"    public class {entity.EntityName}Configuration : IEntityTypeConfiguration<{entity.EntityName}>");
        code.AppendLine("    {");
        code.AppendLine($"        public void Configure(EntityTypeBuilder<{entity.EntityName}> builder)");
        code.AppendLine("        {");
        code.AppendLine($"            builder.ToTable(\"{entity.EntityName}\"); // Table name");
        code.AppendLine();

        var idProperty = entity.Properties.FirstOrDefault(p => p.PropertyName.ToLower() == "id");
        if (idProperty != null)
        {
            code.AppendLine($"            builder.HasKey(e => e.{idProperty.PropertyName});");
        }
        else
        {
            code.AppendLine("            //  No 'Id' property found.  Add configuration here if needed.");
        }

        code.AppendLine("        }");
        code.AppendLine("    }");
        code.AppendLine("}");

        return code.ToString();
    }
    private void GenerateApiProjectFile(string projectFolder)
    {
        string apiProjectTemplate = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "ApiProject.csproj.txt"));
        apiProjectTemplate = apiProjectTemplate.Replace("<#= ApiName #>", _settings.ApiName);
        string apiProjectFilePath = Path.Combine(projectFolder, $"{_settings.ApiProjectName}.csproj");
        File.WriteAllText(apiProjectFilePath, apiProjectTemplate, Encoding.UTF8);
    }

    private void GenerateProgramFile(string projectFolder)
    {
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "Program.cs.txt");
        string templateContent = File.ReadAllText(templatePath);

        // Create a Scriban template
        var template = Template.Parse(templateContent);

        // Create a Scriban template context
        var context = new TemplateContext();
        var scriptObject = new ScriptObject();

        // Add the data to the template context
        scriptObject.Add("ApiName", _settings.ApiName);
        scriptObject.Add("AuthenticationType", _settings.AuthenticationType);
        scriptObject.Add("Entities", _settings.Entities);
        context.PushGlobal(scriptObject);

        // Render the template
        string programCode = template.Render(context);

        string programFilePath = Path.Combine(projectFolder, "Program.cs");
        File.WriteAllText(programFilePath, programCode);
    }
    private void GenerateController(string projectFolder, EntityDefinition entity)
    {
        string controllersFolder = Path.Combine(projectFolder, "Controllers");
        string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "ControllerTemplate.txt");
        string templateContent = File.ReadAllText(templatePath);

        // Create a Scriban template
        var template = Template.Parse(templateContent);

        // Create a Scriban template context
        var context = new TemplateContext();
        var scriptObject = new ScriptObject();

        // Add the data to the template context
        scriptObject.Add("ApiName", _settings.ApiName);
        scriptObject.Add("EntityName", entity.EntityName);
        scriptObject.Add("AuthenticationType", _settings.AuthenticationType);

        context.PushGlobal(scriptObject);

        // Render the template
        string controllerCode = template.Render(context);

        string controllerFilePath = Path.Combine(controllersFolder, $"{entity.EntityName}Controller.cs");
        File.WriteAllText(controllerFilePath, controllerCode);
    }
}