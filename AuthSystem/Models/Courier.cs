using AuthSystem.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    
    public class Courier
    {
        // And if you want a brand new Guid then just do

        private Guid uid = Guid.NewGuid();
        
        // If you already have a string representation of the Guid, you can do this:

        Guid guid = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");

        

        /*public DateTime GetDateTime { get; set; }

        private Guid guid;

        public Courier(Guid guid)
        {
            this.guid = guid;
        }

        public Guid GetGuid()
        {
            return guid;
        }

        public void SetGuid(Guid value)
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }*/
    }
}
