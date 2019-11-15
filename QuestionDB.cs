using IndividuellAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace IndividuellAngular
{
    public class QuestionDB
    {
        private readonly QuestionContext _context;

        public QuestionDB(QuestionContext context)
        {
            _context = context; 
            settInnQuestion(_context);
            
            //_context.Database.EnsureCreated();         
        }                

        public List<question> hentAlleQuestions()
        {       
            
            List<question> alleQuestions = _context.Questions.Select(k => new question()
            {
                id = k.id,
                sporsmal = k.sporsmal,
                svar = k.svar,
                ratingOpp = k.ratingOpp,
                ratingNed = k.ratingNed,               
            }).ToList();
            
            return alleQuestions;
        }

        public bool lagreQuestion(question innQuestion)
        {
            var nyQuestion = new Question
            {
                sporsmal = innQuestion.sporsmal,
                svar = innQuestion.svar,
                ratingOpp = innQuestion.ratingOpp,
                ratingNed = innQuestion.ratingNed,
            };

            try
            {
                // lagre kunden
                _context.Questions.Add(nyQuestion);
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                
                return false;
            }
            return true;
        }

        public void settInnQuestion(QuestionContext context)
        {
           
            List<Question> gamleQuestion = context.Questions.ToList();
            if (gamleQuestion.Count > 0) //Her sjekker koden om det er en tom destinasjonstabell, hvis den er tom så returnerer den og skriver ut
            {
                Console.Write("Tabellen er ikke tom");
                return;
            }

            var q1 = new Question();
            q1.sporsmal = "Fungerer dette?";
            q1.svar = "Ja";
            q1.ratingOpp = 0;
            q1.ratingNed = 0;
            
            var q2 = new Question();
            q2.sporsmal = "Hva med nå?";
            q2.svar = "Ja";
            q2.ratingOpp = 0;
            q2.ratingNed = 0;

            try
            {
                context.Add(q1);
                context.Add(q2);
                context.SaveChanges();          
            }

            catch (Exception e)
            {
                throw new Exception("Får ikke lagt inn verdiene i tabellen: " + e);
            }
        }

        public bool endreEnRating(int id, question innRating)
        {
            // finn kunden
            Question idRating = _context.Questions.FirstOrDefault(k => k.id == id);
            if (idRating == null)
            {
                return false;
            }
            // legg inn ny verdier i denne fra innKunde
            idRating.sporsmal = innRating.sporsmal;
            idRating.svar = innRating.svar;
            idRating.ratingOpp = innRating.ratingOpp;
            idRating.ratingNed = innRating.ratingNed;

            try
            {
                // lagre kunden
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }

        public List<bruker> hentAlleBrukere()
        {

            List<bruker> alleBrukere = _context.Brukere.Select(b => new bruker()
            {
                id = b.id,
                email = b.email,
                fornavn = b.fornavn,
                etternavn = b.etternavn,
                adresse = b.adresse,
                brukersporsmal = b.brukersporsmal
            }).ToList();

            return alleBrukere;
        }


        public bool lagreBruker(bruker innBruker)
        {
            var nyBruker = new Bruker
            {
                email = innBruker.email,
                fornavn = innBruker.fornavn,
                etternavn = innBruker.etternavn,
                adresse = innBruker.adresse,
                brukersporsmal = innBruker.brukersporsmal
            };

            try
            {
                // lagre kunden
                _context.Brukere.Add(nyBruker);
                _context.SaveChanges();
            }
            catch (Exception feil)
            {

                return false;
            }
            return true;
        }

        public bool slettEnBruker(int id)
        {
            try
            {
                Bruker finnBruker = _context.Brukere.Find(id);
                _context.Brukere.Remove(finnBruker);
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
    }
}
