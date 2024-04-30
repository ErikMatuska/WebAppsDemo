using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebAppsDemo.WebApi.Data;
namespace WebAppsDemo.WebApi;

public static class CustomerEndpoints
{
    public static void MapCustomerEntityEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/CustomerEntity").WithTags(nameof(CustomerEntity));

        group.MapGet("/", async (EshopContext db) =>
        {
            return await db.CustomerEntity.ToListAsync();
        })
        .WithName("GetAllCustomerEntities")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<CustomerEntity>, NotFound>> (int customerid, EshopContext db) =>
        {
            return await db.CustomerEntity.AsNoTracking()
                .FirstOrDefaultAsync(model => model.CustomerId == customerid)
                is CustomerEntity model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCustomerEntityById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int customerid, CustomerEntity customerEntity, EshopContext db) =>
        {
            var affected = await db.CustomerEntity
                .Where(model => model.CustomerId == customerid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.CustomerId, customerEntity.CustomerId)
                    .SetProperty(m => m.CustomerName, customerEntity.CustomerName)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCustomerEntity")
        .WithOpenApi();

        group.MapPost("/", async (CustomerEntity customerEntity, EshopContext db) =>
        {
            db.CustomerEntity.Add(customerEntity);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/CustomerEntity/{customerEntity.CustomerId}",customerEntity);
        })
        .WithName("CreateCustomerEntity")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int customerid, EshopContext db) =>
        {
            var affected = await db.CustomerEntity
                .Where(model => model.CustomerId == customerid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCustomerEntity")
        .WithOpenApi();
    }
}
