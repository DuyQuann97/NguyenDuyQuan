using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class ViecCanLam
    {
        public string tenViecCanLam {  get; set; }
        public int doUuTien {  get; set; }
        public string thongTinViecCanLam { get; set; }
        public string trangThaiViecCanLam { get; set; }
        public ViecCanLam() { }

        public ViecCanLam(string TenViecCanLam , int DoUuTien, string ThongTinViecCanLam, string TrangThaiViecCanLam) 
        {
            this.tenViecCanLam = TenViecCanLam;
            this.doUuTien = DoUuTien;
            this.thongTinViecCanLam = ThongTinViecCanLam;
            this.trangThaiViecCanLam = TrangThaiViecCanLam;
        }
    }
}
