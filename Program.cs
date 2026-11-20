
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeDb>(options =>
    options.UseSqlite("Data Source=employees.db"));

var app = builder.Build();

// Create database automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmployeeDb>();
    db.Database.EnsureCreated();
}

// GET all employees
app.MapGet("/employees", async (EmployeeDb db) =>
    await db.Employees.ToListAsync());

// GET employee by ID
app.MapGet("/employees/{id}", async (int id, EmployeeDb db) =>
{
    var employee = await db.Employees.FindAsync(id);
    return employee == null ? Results.NotFound() : Results.Ok(employee);
});

// POST new employee
app.MapPost("/employees", async (Employee employee, EmployeeDb db) =>
{
    if (await db.Employees.AnyAsync(e => e.Id == employee.Id))
        return Results.Conflict("Employee ID already exists");

    db.Employees.Add(employee);
    await db.SaveChangesAsync();
    return Results.Created($"/employees/{employee.Id}", employee);
});

// PUT update employee
app.MapPut("/employees/{id}", async (int id, Employee updated, EmployeeDb db) =>
{
    var employee = await db.Employees.FindAsync(id);

    if (employee == null)
        return Results.NotFound();

    employee.Name = updated.Name;
    employee.Role = updated.Role;

    await db.SaveChangesAsync();
    return Results.Ok(employee);
});

// DELETE employee
app.MapDelete("/employees/{id}", async (int id, EmployeeDb db) =>
{
    var employee = await db.Employees.FindAsync(id);

    if (employee == null)
        return Results.NotFound();

    db.Employees.Remove(employee);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

// Employee model
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
}

// Database context
public class EmployeeDb : DbContext
{
    public EmployeeDb(DbContextOptions<EmployeeDb> options)
        : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
}
