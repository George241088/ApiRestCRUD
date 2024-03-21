using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public class usuario
    {
        private int id;
        private string nombre;
        private string correo;
        private DateTime fecha_registro;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public DateTime Fecha_registro { get => fecha_registro; set => fecha_registro = value; }
    }
}