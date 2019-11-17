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

        // Setter inn FAQ i DB
        public void settInnQuestion(QuestionContext context)
        {

            // Sjekker om det er tom FAQ
            List<Question> gamleQuestion = context.Questions.ToList();
            if (gamleQuestion.Count > 0) 
            {
                Console.Write("Tabellen er ikke tom");
                return;
            }

            var q1 = new Question();
            q1.sporsmal = "Hvordan kan jeg endre eller avbestille billetten?";
            q1.svar = "For å endre billetten din, må du først avbestille den og så kjøpe ny billett til avgangen du skal reise med.";
            q1.ratingOpp = 2;
            q1.ratingNed = -2;
            
            var q2 = new Question();
            q2.sporsmal = "Kan jeg reservere sete om bord?";
            q2.svar = "Når du bestiller billetten på nett eller i appen er det et steg der du velger hvor i toget du ønsker å sitte. I slike tog kan du reservere en ledig plass ved siden av deg mot prisen av en ordinær voksenbillett eller Miniprisbillett.";
            q2.ratingOpp = 3;
            q2.ratingNed = -1;

            var q3 = new Question();
            q3.sporsmal = "Hvordan bestiller jeg billett hvis jeg har spesielle behov for reisen?";
            q3.svar = "Har du spesielle behov for togreisen, er det viktig at du bestiller billetten gjennom kundeservice eller på en betjent stasjon. Tjenester som rullestolplass og gratis plass for førerhund/servicehund kan i dag ikke bestilles på nettet, men funksjonshemmede får likevel tilbud om de ulike rabattene. For rullestolbrukere som ønsker å reise med Sove, har vi en bredere kupé. Denne kupeen må bestilles ved å kontakte kundeservice.";
            q3.ratingOpp = 2;
            q3.ratingNed = -2;

            var q4 = new Question();
            q4.sporsmal = "Barnet mitt skal reise alene. Hvordan fungerer det?";
            q4.svar = "Vi tilbyr ikke reiseassistanse til barn som reiser alene. Personalet om bord på togene har dessverre ikke anledning til å ta seg av barn som reiser alene, derfor er det viktig at barna er modne nok til å klare seg alene. Personalet har heller ingen lovpålagt plikt til å ta spesielt vare på ditt barn under reisen.";
            q4.ratingOpp = 5;
            q4.ratingNed = -2;

            var q5 = new Question();
            q5.sporsmal = "Hvorfor er det så fullt på toget?";
            q5.svar = "Det kan imidlertid være mange grunner til at et tog er veldig fullt. For eksempel om en tidligere avgang ble forsinket eller innstilt kan det føre til at neste tog vil ha flere passasjerer enn vanlig. Noen ganger kan det også være uforutsette hendelser som gjør at vi ikke kan kjøre med det planlagte antall togsett eller vogner. Da blir det ofte satt opp buss i tillegg til toget.";
            q5.ratingOpp = 2;
            q5.ratingNed = -7;

            var q6 = new Question();
            q6.sporsmal = "Jeg har slettet appen og billetten(e) er borte. Hva gjør jeg?";
            q6.svar = "Da må du kontakte kundeservice eller en betjent stasjon slik at vi kan tilbakestille billetten din. Har du periodebillett kan du overføre denne selv ved å laste ned en erstatningsbillett etter å ha installert appen på nytt. Enkeltbilletter kan du også laste ned på nytt frem til dagen før avreise.";
            q6.ratingOpp = 3;
            q6.ratingNed = -4;

            var q7 = new Question();
            q7.sporsmal = "Hva skjer hvis jeg ikke rekker toget?";
            q7.svar = "Enkeltbilletter er gyldig til angitt avgang, det vil si at du ikke kan benytte billetten på andre avganger. Du må dermed kjøpe en ny billett hvis du vil reise med neste avgang.";
            q7.ratingOpp = 5;
            q7.ratingNed = -2;

            var q8 = new Question();
            q8.sporsmal = "Har dere dyrefri sone for meg som er allergisk?";
            q8.svar = "Togene våre har en dyrefri sone der det ikke er tillatt å ha med seg dyr. På tog med setereservasjon kan du reservere plass i dyrefri sone, mens på tog uten plassreservering finner du vogn merket med dyrefri-symbolet.";
            q8.ratingOpp = 4;
            q8.ratingNed = -2;

            var q9 = new Question();
            q9.sporsmal = "Hvordan er samarbeidet mellom Vy og Ruter?";
            q9.svar = "Har du en gyldig billett som gjelder i én eller flere soner i Oslo og Akershus, kan du forlenge reisen med en Ruter tilleggsbillett. Tilleggsbilletten må kjøpes rett før en reise, og er ikke tilgjengelig for salg om bord i togene. Tilleggsbilletten kjøper du i Vy-appen hvis du har en gyldig billett, eller på billettautomaten dersom du har reisekort. Tilleggsbilletten er kun gyldig for den reisen den er kjøpt til, og kan ikke benyttes ved senere reiser.";
            q9.ratingOpp = 2;
            q9.ratingNed = -1;

            var q10 = new Question();
            q10.sporsmal = "Jeg har en periodebillett fra Vy. Kan jeg bruke den på alle tog og busser?";
            q10.svar = "Nei, togbilletter fra Vy kan ikke brukes på Vy-busser og bussbilletter fra Vy kan ikke brukes på Vy-tog. Det er foreløpig ikke samarbeid om billetter mellom tog og buss i Vy.";
            q10.ratingOpp = 1;
            q10.ratingNed = -2;

            try
            {
                context.Add(q1);
                context.Add(q2);
                context.Add(q3);
                context.Add(q4);
                context.Add(q5);
                context.Add(q6);
                context.Add(q7);
                context.Add(q8);
                context.Add(q9);
                context.Add(q10);
                context.SaveChanges();          
            }

            catch (Exception e)
            {
                throw new Exception("Får ikke lagt inn verdiene i tabellen: " + e);
            }
        }

        public bool endreEnRating(int id, question innRating)
        {
            // finn rating
            Question idRating = _context.Questions.FirstOrDefault(k => k.id == id);
            if (idRating == null)
            {
                return false;
            }
            // legg inn ny verdier i denne fra innRating
            idRating.sporsmal = innRating.sporsmal;
            idRating.svar = innRating.svar;
            idRating.ratingOpp = innRating.ratingOpp;
            idRating.ratingNed = innRating.ratingNed;

            try
            {
                // lagre rating
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
                // lagre brukeren
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
