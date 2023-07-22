using System;
using WebAPICQRSMediatR.Models;
using WebAPICQRSMediatR.Services;

namespace WebAPICQRSMediatR.Extensions
{
    public static class MapApis
    {
        public static void MapApi(this WebApplication app) {

            app.MapGet("/api/employee", async (IEmployeeRepository employeeRepo) =>
            {
                var emp = await employeeRepo.GetEmployeeList();
                return Results.Ok(emp);
            });

            app.MapPost("/api/employee", async (IEmployeeRepository employeeRepo, Employee employee) =>
            {
                var result = await employeeRepo.AddEmployee(employee);
                if (result != null)
                    return Results.Ok("Saved successfully");
                return Results.Problem();
            });

            app.MapPut("/api/employee", async (IEmployeeRepository employeeRepo, Employee employee) =>
            {
                var result = await employeeRepo.UpdateEmployee(employee);
                if (result != 0)
                    return Results.Ok("Updated successfully");
                return Results.Problem();
            });

            app.MapGet("/api/employee/{id}", async (IEmployeeRepository employeeRepo, int id) =>
            {
                var emp = await employeeRepo.GetEmployeeById(id);
                if (emp is null)
                    return Results.NotFound();
                return Results.Ok(emp);
            });

            app.MapDelete("/api/employee/{id}", async (IEmployeeRepository employeeRepo, int id) =>
            {
                var emp = await employeeRepo.DeleteEmployee(id);
                if (emp != 0)
                    return Results.Ok("Delete successfully");
                return Results.Problem();
            });
        }
    }
}
