using System;
using System.ComponentModel.DataAnnotations;

namespace BillingAPI.Models

{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public String Adress { get; set; }
    }
}

