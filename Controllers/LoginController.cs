using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_SantiagoECastillo.Models;
using tl2_tp10_2023_SantiagoECastillo.Repositorio;


namespace tl2_tp10_2023_SantiagoECastillo.Controllers;

public class LoginController : Controller{

    private IUsuarioRepositorio usuarioRepositorio;

    private readonly ILogger<HomeController> _logger;

    public LoginController(ILogger<HomeController> logger){
        _logger = logger;
        usuarioRepositorio = new UsuarioRepositorio();
    }

    public IActionResult Index(){
        return View(new )
    }
}