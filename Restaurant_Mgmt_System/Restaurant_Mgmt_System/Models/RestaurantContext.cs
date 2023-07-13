using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

public class RestaurantContext : DbContext
{
    public DbSet<RestaurantItem> RestaurantItems { get; set; }

    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {

    }
}
