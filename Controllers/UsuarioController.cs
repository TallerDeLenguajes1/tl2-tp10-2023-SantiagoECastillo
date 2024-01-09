using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_SantiagoECastillo.Models;
using tl2_tp10_2023_SantiagoECastillo.Repositorio;


namespace tl2_tp10_2023_SantiagoECastillo.Controllers;

public class UsuarioController : Controller {

    private IUsuarioRepositorio usuarioRepositorio;

    private readonly ILogger<HomeController> _logger;

    public UsuarioController(ILogger<HomeController> logger){
        _logger = logger;
        usuarioRepositorio = new UsuarioRepositorio();
    }


    [HttpGet]
    public IActionResult GetUsuarios(){
        var usuarios = usuarioRepositorio.ObtenerTodosUsuarios();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult CrearUsuario(){
        return View(new Usuario());
    }

    [HttpPost]
    public IActionResult CrearUsuario(Usuario usuario){
        usuarioRepositorio.CrearUsuario(usuario);
        return RedirectToAction("GetUsuarios");
    }

    [HttpGet]
    public IActionResult EditarUsuario(int idUsuario){
        var usuarioBuscado = usuarioRepositorio.ObtenerUsuarioPorId(idUsuario);
        return View(usuarioBuscado);
    }

    [HttpPost]
    public IActionResult EditarUsuario(Usuario usuario){
        var usuarioBuscado = usuarioRepositorio.ObtenerUsuarioPorId(usuario.IdUsuario);
        usuarioBuscado.NombreUsuario = usuario.NombreUsuario;
        usuarioRepositorio.ModificarUsuario(usuarioBuscado);
        return RedirectToAction("GetUsuarios");
    }

    //[HttpDelete]
    public IActionResult EliminarUsuario(int idUsuario){
        usuarioRepositorio.EliminarUsuarios(idUsuario);
        return RedirectToAction("GetUsuarios");
    }
}