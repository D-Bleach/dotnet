﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Bai1.Models
{
    public partial class BenhNhan
    {
        public int MaBn { get; set; }
        public string HoTen { get; set; }
        public int? SoNgayNamVien { get; set; }
        public double? VienPhi { get; set; }
        public int? MaKhoa { get; set; }

        public virtual Khoa MaKhoaNavigation { get; set; }
        //public virtual Khoa Khoa { get; set; }
    }
}
