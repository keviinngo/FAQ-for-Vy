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
            q1.sporsmal = "Hvordan kan jeg endre eller avbestille billetten?";
            q1.svar = "For å endre billetten din, må du først avbestille den og så kjøpe ny billett til avgangen du skal reise med.";
            q1.ratingOpp = 0;
            q1.ratingNed = 0;
            
            var q2 = new Question();
            q2.sporsmal = "Kan jeg reservere sete om bord?";
            q2.svar = "Når du bestiller billetten på nett eller i appen er det et steg der du velger hvor i toget du ønsker å sitte. I slike tog kan du reservere en ledig plass ved siden av deg mot prisen av en ordinær voksenbillett eller Miniprisbillett.";
            q2.ratingOpp = 0;
            q2.ratingNed = 0;

            var q3 = new Question();
            q3.sporsmal = "Hvordan bestiller jeg billett hvis jeg har spesielle behov for reisen?";
            q3.svar = "Har du spesielle behov for togreisen, er det viktig at du bestiller billetten gjennom kundeservice eller på en betjent stasjon. Tjenester som rullestolplass og gratis plass for førerhund/servicehund kan i dag ikke bestilles på nettet, men funksjonshemmede får likevel tilbud om de ulike rabattene. For rullestolbrukere som ønsker å reise med Sove, har vi en bredere kupé. Denne kupeen må bestilles ved å kontakte kundeservice.";
            q3.ratingOpp = 0;
            q3.ratingNed = 0;

            var q4 = new Question();
            q4.sporsmal = "Barnet mitt skal reise alene. Hvordan fungerer det?";
            q4.svar = "Vi tilbyr ikke reiseassistanse til barn som reiser alene. Personalet om bord på togene har dessverre ikke anledning til å ta seg av barn som reiser alene, derfor er det viktig at barna er modne nok til å klare seg alene. Personalet har heller ingen lovpålagt plikt til å ta spesielt vare på ditt barn under reisen.";
            q4.ratingOpp = 0;
            q4.ratingNed = 0;

            var q5 = new Question();
            q5.sporsmal = "Hvorfor er det så fullt på toget?";
            q5.svar = "Det kan imidlertid være mange grunner til at et tog er veldig fullt. For eksempel om en tidligere avgang ble forsinket eller innstilt kan det føre til at neste tog vil ha flere passasjerer enn vanlig. Noen ganger kan det også være uforutsette hendelser som gjør at vi ikke kan kjøre med det planlagte antall togsett eller vogner. Da blir det ofte satt opp buss i tillegg til toget.";
            q5.ratingOpp = 0;
            q5.ratingNed = 0;

            try
            {
                context.Add(q1);
                context.Add(q2);
                context.Add(q3);
                context.Add(q4);
                context.Add(q5);
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
