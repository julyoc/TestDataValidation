using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestDataValidation
{
    internal class PersonData
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public uint Edad { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }

        private bool ValidCedula()
        {
            var provced = int.Parse(Cedula.Substring(0, 1));
            if (provced > 24 || provced <= 0) return false;
            provced = int.Parse(Cedula.ToArray()[2].ToString());
            if (provced >= 6) return false;
            var dijValid = int.Parse(Cedula.ToArray()[Cedula.Length - 1].ToString());
            var arr = Cedula.Substring(0, 9).ToArray().Select(x => int.Parse(x.ToString()));
            var k = 1;
            var cont = 0;
            foreach (var i in arr)
            {
                if (k % 2 == 1)
                {
                    if (i * 2 >= 10) cont += i * 2 - 9;
                    else cont += i * 2;
                } 
                else cont += i;
                k++;
            }
            var comp = int.Parse(cont.ToString().ToArray()[1].ToString());
            if (10 - comp != dijValid) return false;
            return true;
        }

        private bool ValidCedulaExtranjeros()
        {
            var provced = int.Parse(Cedula.Substring(0, 1));
            if (provced != 30) return false;
            provced = int.Parse(Cedula.ToArray()[2].ToString());
            if (provced >= 6) return false;
            var dijValid = int.Parse(Cedula.ToArray()[Cedula.Length - 1].ToString());
            var arr = Cedula.Substring(0, 9).ToArray().Select(x => int.Parse(x.ToString()));
            var k = 1;
            var cont = 0;
            foreach (var i in arr)
            {
                if (k % 2 == 1)
                {
                    if (i * 2 >= 10) cont += i * 2 - 9;
                    else cont += i * 2;
                }
                else cont += i;
                k++;
            }
            var comp = int.Parse(cont.ToString().ToArray()[1].ToString());
            if (10 - comp != dijValid) return false;
            return true;
        }

        public PersonDataValid Valid()
        {
            var valid = new PersonDataValid();

            if (Nombre != null)
            {
                if (Nombre.Length >= 3 && Nombre.Length <= 30) valid.Nombre = true;
            } 
            if (Apellido != null)
            {
                if (Apellido.Length >= 3 && Apellido.Length <= 30) valid.Apellido = true;
            }
            if (Edad != null)
            {
                if (Edad >= 18 && Edad <= 100) valid.Edad = true;
            }
            if (Email != null)
            {
                var re = new Regex(@"^(([^<>()\[\]\\.,;:\s@”]+(\.[^<>()\[\]\\.,;:\s@”]+)*)|(“.+”))@((\[[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}])|(([a-zA-Z\-0–9]+\.)+[a-zA-Z]{2,}))$");
                if (re.IsMatch(Email)) valid.Email = true;
            }
            if (Telefono != null)
            {
                if (Telefono.Length == 10) valid.Telefono = true;
            }
            if (Cedula != null)
            {
                if (Cedula.Length == 10 && (ValidCedula() || ValidCedulaExtranjeros())) valid.Cedula = true;
            }
            return valid;
        }
    }


    internal class PersonDataValid
    {
        public bool Nombre { get; set; } = false;
        public bool Apellido { get; set; } = false;
        public bool Edad { get; set; } = false;
        public bool Email { get; set; } = false;
        public bool Telefono { get; set; } = false;
        public bool Cedula { get; set; } = false;

        public bool Reduce 
        { 
            get
            {
                if (!Nombre) return false;
                if (!Apellido) return false;
                if (!Edad) return false;
                if (!Email) return false;
                if (!Telefono) return false;
                if (!Cedula) return false;
                return true;
            }
        }
    }
}
