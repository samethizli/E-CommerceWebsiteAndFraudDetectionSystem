﻿using Ekitap.Core.Entities;
using Ekitap.Data;
using Ekitap.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;//login
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;//login

namespace Ekitap.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly DatabaseContext _context;

        public AccountController(DatabaseContext context)
        {
            _context = context;
        }
        [Authorize]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()//giriş ekranı
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignInAsync(LoginViewModel loginViewModel)//giriş ekranı
        {
            if (ModelState.IsValid)
            { try
                {

                var account = await _context.AppUsers.FirstOrDefaultAsync(x => x.Email ==
                loginViewModel.Email && x.Password == loginViewModel.Password && x.IsActive);
                if (account == null)
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");

                }
                else
                {
                    var claims = new List<Claim>()
                        {
                         new(ClaimTypes.Name,account.Name),
                         new(ClaimTypes.Role,account.IsAdmin ? "Admin" : "Customer"),
                         new(ClaimTypes.Email,account.Email),
                         new("UserId",account.Id.ToString()),
                         new("UserGuid",account.UserGuid.ToString()),
                        };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(userPrincipal);
                    return Redirect(string.IsNullOrEmpty(loginViewModel.ReturnUrl) ? "/" :
                        loginViewModel.ReturnUrl);
                }

               
                }
                catch (Exception hata)
                {
                    // loglama
                    ModelState.AddModelError("", "Hata oluştu");
                }

            }
            return View(loginViewModel);
        }
        public IActionResult SignUp()//kayıt ekranı
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(AppUser appUser)//kayıt ekranı
        {
            appUser.IsAdmin = false;
            appUser.IsActive = true;
            if (ModelState.IsValid)
            {
                await _context.AddAsync(appUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }
        public async Task<IActionResult> SignOutAsync()//kayıt ekranı
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");//oturum açmaya yönlendir.
        }
    }
}
