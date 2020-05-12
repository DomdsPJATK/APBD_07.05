﻿using System;
using System.Collections.Generic;

namespace APBD_07._05.Model
{
    public partial class ProcedureAnimal
    {
        public int ProcedureIdProcedure { get; set; }
        public int AnimalIdAnimal { get; set; }
        public DateTime Date { get; set; }

        public virtual Animal AnimalIdAnimalNavigation { get; set; }
        public virtual Procedure ProcedureIdProcedureNavigation { get; set; }
    }
}
