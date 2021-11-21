using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sky.Data;
using Sky.Models;
using static Sky.Data.Helper;

namespace Sky.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
    }
}
