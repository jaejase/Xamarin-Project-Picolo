// Written by Aaron Hayton N9946977
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xamarin.Forms;

namespace Picolo.Models
{
    public class Groups
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string GroupName { get; set; }
        public string MemberId1 { get; set; }
        public string MemberId2 { get; set; }
        public string MemberId3 { get; set; }
        public string MemberId4 { get; set; }
        public int MaxMembers { get; set; }
        public int GroupXP { get; set; }
    }
}
