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

/*
    [HttpGet]
    public IActionResult GetTableros(){
        
    }
   */ 
}