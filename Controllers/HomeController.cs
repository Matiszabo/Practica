using System.Diagnostics;
using Practica.Models;
using Microsoft.AspNetCore.Mvc;
using practica.Models;
using Practica.Models;
namespace practica.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListaAlumnos = BD.SeleccionarAlumnos();
        ViewBag.AlumnosReprobados = BD.SeleccionarAlumnosAprobados();
        ViewBag.AlumnosAprobados = BD.SeleccionarAlumnosReprobados();
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult VerDetalleAlumno(int id)
    {
        Alumno alumno = BD.AlumnoElegido(id);
        ViewBag.Alumno = alumno;
        ViewBag.Promedio = alumno.promedio;
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
