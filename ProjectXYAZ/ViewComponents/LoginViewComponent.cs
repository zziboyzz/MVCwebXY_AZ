using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjectXYAZ.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Firebase.Auth;
using System.Security.Claims;
using ProjectXYAZ.Models;
[ViewComponent(Name = "Login")]
public class LoginViewComponent : ViewComponent
{
   
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ErrorViewModel A = new ErrorViewModel();
        // Code to instantiate the model class.
        return View(A);
    }
}