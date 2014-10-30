﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class BOLoaiThongTin
    {
        public static List<LOAITHONGTIN> GetAll()
        {
            using (KaraokeEntities ke = new KaraokeEntities())
            {
                return ke.LOAITHONGTINs.Where(s => s.Deleted == false).ToList();
            }
        }
    }
}
