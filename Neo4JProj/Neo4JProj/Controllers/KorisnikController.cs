using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using Neo4JProj.Models;

namespace Neo4JProj.Controllers
{
    public class KorisnikController : Controller
    {
        private GraphClient client;

        public KorisnikController()
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "katarina");
            try
            {
                client.Connect();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public IActionResult PrikaziKorisnike()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:korisnik) return n", new Dictionary<string, object>(), CypherResultMode.Set);
            List<Korisnik> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).ToList();

            return View(skole);
        }

        public IActionResult dodajKorisnika()
        {
            return View();
        }

        public IActionResult sacuvajKorisnikaUbazu(string Idkorisnika, string Ime, string Prezime, string Email)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idkorisnika", Idkorisnika);
            queryDict.Add("ime", Ime);
            queryDict.Add("prezime", Prezime);
            queryDict.Add("email", Email);
            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (n:korisnik {idkorisnika:'" + Idkorisnika + "', ime:'" + Ime
                                                            + "', prezime:'" + Prezime
                                                             + "', email:'" + Email
                                                            + "'}) return n", queryDict, CypherResultMode.Set);

            List<Korisnik> pl = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).ToList();

            return RedirectToAction("dodajKorisnika");
        }
        public IActionResult idiNaobrisiKorisnikStranicu()
        {
            return View();
        }
        public IActionResult ObrisiKorisnika(string Idkorisnika)//vodi racuna kako se zove parametar ako se prebaci negde
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idkorisnika", Idkorisnika);
            var query = new Neo4jClient.Cypher.CypherQuery(" match (n:korisnik {idkorisnika: '" + Idkorisnika + "'}) detach delete n",
                                                             queryDict, CypherResultMode.Projection);
            Korisnik skol = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).FirstOrDefault();

            return RedirectToAction("idiNaobrisiKorisnikStranicu");
        }

        public IActionResult PromeniKorisnika(string ime, string prezime,string noviMejl)//edit email
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            queryDict.Add("prezime", prezime);
            queryDict.Add("novimejl", noviMejl);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:korisnik) and exists(n.email) and n.ime='"+ime+"' and n.prezime='"+prezime+"' set n.email= '"+ noviMejl+ "' return n",
                                                             queryDict, CypherResultMode.Set);
            List<Korisnik> pl = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).ToList();

            return RedirectToAction("idiNaobrisiKorisnikStranicu");
        }
        
        public IActionResult PronadjiPrijatelje(string ime)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            var query = new Neo4jClient.Cypher.CypherQuery("match (n)-[r:JE_PRIJATELJ]->(f) where n.ime=' "+ime+"' return f",
                                                            queryDict, CypherResultMode.Set);
            List<Korisnik> korisnici= ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).ToList();

            return RedirectToAction("idiNaobrisiKorisnikStranicu");
        }
    }
}