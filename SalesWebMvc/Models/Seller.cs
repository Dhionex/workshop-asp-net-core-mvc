using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage ="{0} Obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} deve ter entre {2} e {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Entre com um e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Display(Name ="Salário Base")]
        [Range(100.0, 50000.0, ErrorMessage ="{0} deve ser entre {1} e {2}")]
        public double BaseSalary { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage =" Data de nascimento obrigátorio")]
        public DateTime BirthDate { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public Seller ()
        {

        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales (SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales (SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales (DateTime initial, DateTime final)
        {

            //CALCULA VENDAS DE UM DETERMIDADO VENDEDOR EM UM DETREMINADO PERIODO 
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }

    }
}
