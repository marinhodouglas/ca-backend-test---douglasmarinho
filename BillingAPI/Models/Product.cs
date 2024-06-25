using System;
using System.ComponentModel.DataAnnotations;

namespace BillingAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public String ProductName { get; set; }

    }
}
