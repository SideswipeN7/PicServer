using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pic.Settings.Pages
{
    public partial class Authentication
    {
        [Parameter] 
        public string Action { get; set; }
    }
}
