using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using IndividuellAngular.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndividuellAngular.Controllers
{

    [Route("api/[controller]")]
    public class FAQController : Controller
    {

        private readonly QuestionContext _context;

        public FAQController(QuestionContext context)
        {
            _context = context;
        }

        // GET api/FAQ/ - Spørsmål og svar
        [HttpGet]
        public JsonResult Get()
        {

            var questionDB = new QuestionDB(_context);
            List<question> alleQuestions = questionDB.hentAlleQuestions();
            return Json(alleQuestions);

        }

        // PUT api/FAQ - Legger til rating
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]question innKunde)
        {
            
                var questionDb = new QuestionDB(_context);
                bool OK = questionDb.endreEnRating(id, innKunde);
                if (OK)
                {
                    return Json(OK);
                }
            
            return Json("Kunne ikke endre rating i DB");
        }

        // GET api/FAQ/Bruker
        [HttpGet]
        [Route ("Bruker")]
        public JsonResult GetBruker()
        {

            var BrukerDB = new QuestionDB(_context);
            List<bruker> alleBrukere = BrukerDB.hentAlleBrukere();
            return Json(alleBrukere);

        }

        // POST api/FAQ/Bruker
        [HttpPost]
        [Route("Bruker")]
        public JsonResult Post([FromBody]bruker innBrukere)
        {
            if (ModelState.IsValid)
            {
                var brukerDb = new QuestionDB(_context);
                bool OK = brukerDb.lagreBruker(innBrukere);
                if (OK)
                {
                    return Json("OK");
                }
            }
            return Json("Kunne ikke sette inn kunden i DB");
        }

        // DELETE api/FAQ/Bruker
        [HttpDelete("{id}")]
        
        public JsonResult Delete(int id)
        {
            var brukerDb = new QuestionDB(_context);
            bool OK = brukerDb.slettEnBruker(id);
            if (!OK)
            {
                return Json("Kunne ikke slette brukeren!");
            }
            return Json("OK");
        }
    }
}