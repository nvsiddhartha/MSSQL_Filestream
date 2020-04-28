using System;
using System.Collections.Generic;

namespace SQLFilestream.Models
{
    public partial class MyFileStreamTable
    {
        public Guid Fsid { get; set; }
        public string Fsdescription { get; set; }
        public byte[] Fsblob { get; set; }
    }
}
