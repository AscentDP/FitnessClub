using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3ISP919_Naliv_LoginReg.DB;
using _3ISP919_Naliv_LoginReg.Windows;

namespace _3ISP919_Naliv_LoginReg.ClassHelper
{
    public class EFClass
    {
        public static DPFitnessEntities context { get; set; } = new DPFitnessEntities();
    }
}

