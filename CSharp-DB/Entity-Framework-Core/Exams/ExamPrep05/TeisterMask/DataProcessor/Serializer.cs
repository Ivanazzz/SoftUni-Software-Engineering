namespace TeisterMask.DataProcessor
{
    using System.Globalization;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;
    using Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            xmlHelper = new XmlHelper();

            ExportProjectDto[] projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectDto()
                {
                    Name = p.Name,
                    HasEndDate = string.IsNullOrEmpty(p.DueDate.ToString())
                        ? "No"
                        : "Yes",
                    TasksCount = p.Tasks.Count(),
                    Tasks = p.Tasks
                        .ToArray()
                        .Select(t => new ExportTaskForProjectDto()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.TasksCount)
                .ThenBy(p => p.Name)
                .ToArray();

            return xmlHelper.Serialize(projects, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            ExportEmployeeDto[] employees = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new ExportEmployeeDto()
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .ToArray()
                        .Where(t => t.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(t => new ExportTaskForEmployeeDto()
                        {
                            Name = t.Task.Name,
                            OpenDate = t.Task.OpenDate
                                .ToString("d", CultureInfo.InvariantCulture),
                            DueDate = t.Task.DueDate
                                .ToString("d", CultureInfo.InvariantCulture),
                            LabelType = t.Task.LabelType.ToString(),
                            ExecutionType = t.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}