using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using libDAO.Models;
using libDAO.DAOs;
using mvc.DTOs;
namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Contato> contatos;
        ContatoDAO contatoDAO = new ContatoDAO();
        contatos = await contatoDAO.List();
        return View(contatos);
    }
    [HttpGet]
    public IActionResult FrmInsContato()
    {
        return View();
    }
    [HttpPost]
    public IActionResult InserirContato(contatoDTO contatoDTO) //public IActionResult InserirContato(string nome, string telefone)
    {
        Contato contato = new Contato();
        contato.Nome = contatoDTO.nome;
        contato.Telefone = contatoDTO.telefone;
        ContatoDAO contatoDAO = new ContatoDAO();
        contatoDAO.Create(contato);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult ApagarContato(int id)
    {
        ContatoDAO contatoDAO = new ContatoDAO();
        contatoDAO.Destroy(id);
        return RedirectToAction("Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
