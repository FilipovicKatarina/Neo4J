using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using Neo4JProj.Models;

namespace Neo4JProj.Controllers
{
    public class InstruktorController : Controller
    {
        private GraphClient client;

        public InstruktorController()
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

        public IActionResult PrikaziInstruktore()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:instruktor) return n", new Dictionary<string, object>(), CypherResultMode.Set);
            List<Instruktor> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<Instruktor>(query).ToList();

            return View(skole);
        }

        public IActionResult dodajInstruktora()
        {
            return View();
        }

        public IActionResult sacuvajInstruktoraUbazu(string Idinstruktora, string Ime, string Prezime, string Starost, string Pol, string Biografija, string Brojtel)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idInstruktora", Idinstruktora);
            queryDict.Add("ime", Ime);
            queryDict.Add("prezime", Prezime);
            queryDict.Add("starost", Starost);
            queryDict.Add("pol", Pol);
            queryDict.Add("biografija", Biografija);
            queryDict.Add("brojtel", Brojtel);
            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (n:instruktor {idInstruktora:'" + Idinstruktora + "', ime:'" + Ime
                                                            + "', prezime:'" + Prezime + "', starost:'" + Starost
                                                            + "', pol:'" + Pol
                                                            + "', biografija:'" + Biografija
                                                             + "', brojtel:'" + Brojtel
                                                            + "'}) return n", queryDict, CypherResultMode.Set);
            List<Instruktor> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<Instruktor>(query).ToList();

            return RedirectToAction("dodajInstruktora");
        }

        public IActionResult idiNaobrisiInstruktorStranicu()
        {
            return View();
        }

        public IActionResult ObrisiInstruktora(string Idinstruktora)//vodi racuna kako se zove parametar ako se prebaci negde
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idInstruktora", Idinstruktora);
            var query = new Neo4jClient.Cypher.CypherQuery(" match (n:instruktor {idInstruktora: '" + Idinstruktora + "'}) detach delete n",
                                                             queryDict, CypherResultMode.Projection);
            Instruktor skol = ((IRawGraphClient)client).ExecuteGetCypherResults<Instruktor>(query).FirstOrDefault();

            return RedirectToAction("idiNaobrisiInstruktorStranicu");
        }

        public IActionResult PromeniInstruktora(string ime,string prezime,string biografijaNova)//edit biografiju
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            queryDict.Add("prezime", prezime);
            queryDict.Add("biografijanova", biografijaNova);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:instruktor) and exists(n.biografija) and n.ime='"+ime+"' and n.prezime='"+prezime+"' set n.biografija= '"+biografijaNova+"' return n",
                                                             queryDict, CypherResultMode.Set);
            List<Instruktor> pl = ((IRawGraphClient)client).ExecuteGetCypherResults<Instruktor>(query).ToList();

            return RedirectToAction("idiNaobrisiInstruktorStranicu");
        }

        public IActionResult PronadjiPlesoveKojeDrzi(string ime)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            var query = new Neo4jClient.Cypher.CypherQuery("match (n)-[r:DRZI]->(f) where n.ime=' " + ime + "' return f",
                                                            queryDict, CypherResultMode.Set);
            List<Korisnik> plesovi = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).ToList();

            return RedirectToAction("idiNaobrisiKorisnikStranicu");
        }

        public IActionResult dodajInstruktoraUSkolu(string idInstruktora, string ime)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            queryDict.Add("idInstruktora", idInstruktora);
            var query = new Neo4jClient.Cypher.CypherQuery("match (i:instruktor),(m:plesnaskola) where i.idInstruktora='" + idInstruktora + "' and m.ime ='" + ime + "' CREATE(i) -[r: RADI]->(m)",
                                                            queryDict, CypherResultMode.Set);
            ((IRawGraphClient)client).ExecuteCypher(query);

            return RedirectToAction("idiNaZaposliInstruktora");
        }

        public IActionResult idiNaZaposliInstruktora()
        {
            return View();
        }
    }
}