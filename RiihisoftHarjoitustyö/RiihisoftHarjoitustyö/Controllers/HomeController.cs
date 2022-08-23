using Microsoft.AspNetCore.Mvc;
using RiihisoftHarjoitustyö.Models;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace RiihisoftHarjoitustyö.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<Tiedot> tiedots = new List<Tiedot>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = RiihisoftHarjoitustyö.Properties.Resources.ConnectionString;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            FetchData();
            return View(tiedots);
        }
        private void FetchData()
        {
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [id]\r\n      ,[Etunimi]\r\n      ,[Sukunimi]\r\n      ,[Sähköposti]\r\n      ,[AvoinPalaute]\r\n  FROM [Palaute1].[dbo].[Palaute_1]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    tiedots.Add(new Tiedot() { Id = (int)dr["id"],
                        Etunimi = dr["Etunimi"].ToString(),
                        Sukunimi = dr["Sukunimi"].ToString(),
                        Sähköposti = dr["Sähköposti"].ToString(),
                        AvoinPalaute = dr["AvoinPalaute"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IActionResult Palautelomake()
        {
            return View();
        }
        
        public IActionResult SaveRecord(Palaute1 model)
        {
            try
            {
                
                Palaute1Context db = new Palaute1Context();
                Palaute1 palaute1 = new Palaute1();
                palaute1.Id = model.Id;
                palaute1.Etunimi = model.Etunimi;
                palaute1.Sukunimi = model.Sukunimi;
                palaute1.Sähköposti = model.Sähköposti;
                palaute1.AvoinPalaute = model.AvoinPalaute;
                //palaute1.Id = model.Id;

                db.Palaute1s.Add(palaute1);
                db.SaveChanges();

                int latestApID = palaute1.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}