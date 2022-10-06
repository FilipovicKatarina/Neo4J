using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4JProj.Models;

namespace Neo4JProj.Controllers
{
    public class PlesController : Controller
    {
        private GraphClient client;

        public PlesController()
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

        public IActionResult PrikaziPles()
        {
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:ples) return n", new Dictionary<string, object>(), CypherResultMode.Set);
            List<Ples> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<Ples>(query).ToList();

            return View(skole);
        }

        public IActionResult dodajPles()
        {
            return View();
        }

        public IActionResult sacuvajPlesUbazu(string Idplesa, string Naziv, string Zemljaporekla)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idplesa", Idplesa);
            queryDict.Add("naziv", Naziv);
            queryDict.Add("zemljaporekla", Zemljaporekla);
            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (n:ples {idplesa:'" + Idplesa + "', naziv:'" + Naziv
                                                            + "', zemljaporekla:'" + Zemljaporekla
                                                            + "'}) return n", queryDict, CypherResultMode.Set);
            List<Ples> pl = ((IRawGraphClient)client).ExecuteGetCypherResults<Ples>(query).ToList();

            return RedirectToAction("dodajPles");
        }

        public IActionResult idiNaobrisiPlesStranicu()
        {
            return View();
        }

        public IActionResult ObrisiPles(string Idsplesa)//vodi racuna kako se zove parametar ako se prebaci negde
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idplesa", Idsplesa);
            var query = new Neo4jClient.Cypher.CypherQuery(" match (n:ples {idplesa: '" + Idsplesa + "'}) detach delete n",
                                                             queryDict, CypherResultMode.Projection);
            Ples skol = ((IRawGraphClient)client).ExecuteGetCypherResults<Ples>(query).FirstOrDefault();
            return RedirectToAction("idiNaobrisiPlesStranicu");
        }

        public IActionResult PromeniPles(string staroIme, string novoIme)//edit zemlju porekla plesa
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("staroime", staroIme);
            queryDict.Add("novoime", novoIme);
            var query = new Neo4jClient.Cypher.CypherQuery("start n = node(*) where(n: ples) and exists(n.zemljaporekla) and n.zemljaporekla ='"+staroIme+"' set n.zemljaporekla ='"+novoIme+"' return n",
                                                             queryDict, CypherResultMode.Set);
            List<Ples> pl = ((IRawGraphClient)client).ExecuteGetCypherResults<Ples>(query).ToList();

            return RedirectToAction("idiNaobrisiPlesStranicu");
        }

        public IActionResult PretragaPlesaPoImenu(string ime)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:ples) and exists(n.naziv) and n.naziv=~'.* " + ime + ".*' return n",
                                                            queryDict, CypherResultMode.Set);
            List<Korisnik> plesovi = ((IRawGraphClient)client).ExecuteGetCypherResults<Korisnik>(query).ToList();

            return RedirectToAction("idiNaobrisiPlesStranicu");
        }
    }
}