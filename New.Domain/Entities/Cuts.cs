﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New.Domain.Entities
{ 
   public enum TypeM{main,NO}
   public class Cut
    {
     public  int x1 { get; set; }
     public  int x2 { get; set; }
     public  int y1 { get; set; }
     public  int y2 { get; set; }
     public TypeM type = TypeM.NO;
    }
}