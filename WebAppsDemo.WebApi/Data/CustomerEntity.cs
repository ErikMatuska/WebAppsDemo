using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppsDemo.WebApi.Data
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
