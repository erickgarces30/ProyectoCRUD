﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academico
{
    public class Estudiante
    {
        public string Matricula { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
    }
}
