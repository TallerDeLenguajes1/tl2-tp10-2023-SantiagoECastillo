using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_SantiagoECastillo.Models;
using tl2_tp10_2023_SantiagoECastillo.Repositorio;


namespace tl2_tp10_2023_SantiagoECastillo.Controllers;

public class TableroController : Controller{

    private ITableroRepositorio tableroRepositorio;

    private readonly ILogger<HomeController> _logger;

    public TableroController(ILogger<HomeController> logger){
        _logger = logger;
        tableroRepositorio = new TableroRepositorio();
    }


    [HttpGet]
    public IActionResult ObtenerTableros(){
        var tableros = tableroRepositorio.ListarTableros();
        return View(tableros);
    }

    [HttpGet]
    public IActionResult CrearTablero(){
        return View(new Tablero());
    }

    [HttpPost]
    public IActionResult CrearTablero(Tablero tablero){
        tableroRepositorio.CrearTablero(tablero);
        return RedirectToAction("ObtenerTableros");
    }

    [HttpGet]
    public IActionResult EditarTablero(int idTablero){
        var tableroAEditar = tableroRepositorio.ObtenerTablero(idTablero);
        return View(tableroAEditar);
    }

    [HttpPost]
    public IActionResult EditarTablero(Tablero tablero){
        var tableroEditado = tableroRepositorio.ObtenerTablero(tablero.IdTablero);
        tableroEditado.Nombre = tablero.Nombre;
        tableroEditado.Descripcion = tablero.Descripcion;
        tableroEditado.IdUsuarioPropietario = tablero.IdUsuarioPropietario;
        tableroRepositorio.ModificarTablero(tablero.IdTablero, tableroEditado);
        return RedirectToAction("ObtenerTableros");
    }

    //[HttpDelete]
    public IActionResult EliminarTablero(int idTablero){
        tableroRepositorio.EliminarTablero(idTablero);
        return RedirectToAction("ObtenerTableros");
    }
   
}