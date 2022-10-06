using Microsoft.AspNetCore.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using Neo4JProj.Models;

namespace Neo4JProj.Controllers
{
    public class PlesnaSkolaController : Controller
    {
        private GraphClient client;

        public PlesnaSkolaController( )
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

         public IActionResult PrikaziPlesneSkole()
        {
            var query = new Neo4jClient.Cypher.CypherQuery(" match (n:plesnaskola) return n", new Dictionary<string, object>(), CypherResultMode.Set);
            List<PlesnaSkola> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<PlesnaSkola>(query).ToList();

            return View(skole);
        }

        public IActionResult dodajPlesnuSkolu()
        {
            return View();
        }

        public IActionResult sacuvajPlesnuSkoluUbazu(string Idskole, string Ime, string Grad, string Adresa, string Email, string Brojtel,string Ocena)
        {

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idskole", Idskole);
            queryDict.Add("ime", Ime);
            queryDict.Add("grad", Grad);
            queryDict.Add("adresa", Adresa);
            queryDict.Add("email", Email);
            queryDict.Add("brojtel", Brojtel);
            queryDict.Add("ocena", Ocena);
            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (n:plesnaskola {idskole:'" + Idskole + "', ime:'" + Ime
                                                             + "', grad:'" + Grad + "', adresa:'" + Adresa
                                                             + "', email:'" + Email
                                                              + "', brojtel:'" + Brojtel
                                                               + "', ocena:'" + Ocena
                                                             + "'}) return n",queryDict, CypherResultMode.Set);

             List<PlesnaSkola> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<PlesnaSkola>(query).ToList();

            return RedirectToAction("dodajPlesnuSkolu"); 
        }

        public IActionResult idiNaobrisiStranicu()
        {
            return View();
        }

        public IActionResult ObrisiPlesnuSkolu(string Idskole)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("idskole", Idskole);  
            var query = new Neo4jClient.Cypher.CypherQuery(" match (n:plesnaskola {idskole: '" + Idskole + "'}) detach delete n",
                                                             queryDict, CypherResultMode.Projection);
            PlesnaSkola skol = ((IRawGraphClient)client).ExecuteGetCypherResults<PlesnaSkola>(query).FirstOrDefault();

            return RedirectToAction("idiNaobrisiStranicu"); 
        }

        public IActionResult PromeniPlesnuSkolu(string staroIme,string novoIme)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("staroime", staroIme);
            queryDict.Add("novoime", novoIme);
            var query = new Neo4jClient.Cypher.CypherQuery(" start n = node(*) where(n:plesnaskola) and exists(n.ime) and n.ime='"+ staroIme+"' set n.ime= '"+novoIme+"' return n",
                                                             queryDict, CypherResultMode.Set);
            List<PlesnaSkola> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<PlesnaSkola>(query).ToList();

            return RedirectToAction("idiNaobrisiStranicu");
        }

        public IActionResult OceniSkolu(string imeSkole,string ocena)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("imeskole", imeSkole);
            queryDict.Add("ocena", ocena);
            float a = float.Parse(ocena);

            if (a > 10 || a < 0)
                return RedirectToAction("idiNaobrisiStranicu");

            var query1 = new Neo4jClient.Cypher.CypherQuery(" start n = node(*) where(n:plesnaskola) and exists(n.ime) and n.ime='" + imeSkole + "'  return n.ocena",
                                                             queryDict, CypherResultMode.Set);
            string ocen = ((IRawGraphClient)client).ExecuteGetCypherResults<string>(query1).FirstOrDefault();
            a = (a + float.Parse(ocen))/2;
            var query = new Neo4jClient.Cypher.CypherQuery(" start n = node(*) where(n:plesnaskola) and exists(n.ime) and n.ime='" + imeSkole + "' set n.ocena= '" + a.ToString() + "' return n",
                                                             queryDict, CypherResultMode.Set);
            List<PlesnaSkola> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<PlesnaSkola>(query).ToList();

            return RedirectToAction("idiNaobrisiStranicu");
        }
    
        public IActionResult Preporuke()
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            var query = new CypherQuery("MATCH (m:plesnaskola)" +
                                        "RETURN m ORDER BY toFloat(m.ocena) DESC LIMIT 5",
                                        new Dictionary<string, object>(), CypherResultMode.Set);
            List<PlesnaSkola> skole = ((IRawGraphClient)client).ExecuteGetCypherResults<PlesnaSkola>(query).ToList();

            return View(skole);
        }
 
        public IActionResult dodajPlesSkoli(string idplesa, string ime)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ime", ime);
            queryDict.Add("idplesa", idplesa); 
            var query = new Neo4jClient.Cypher.CypherQuery("match (i:plesnaskola),(m:ples) where i.ime=' " + ime + "' and m.idplesa = '" + idplesa + "' CREATE(i) -[r: IMA]->(m)",
                                                            queryDict, CypherResultMode.Set); 
            ((IRawGraphClient)client).ExecuteCypher(query);

            return RedirectToAction("idiNaDodavanjePlesa");
        }

        public IActionResult idiNaDodavanjePlesa()
        {
            return View();
        }
    }
}
