import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Question, IQuestion } from "./question";
//import { NgbAccordionConfig } from '@ng-bootstrap/ng-bootstrap';
//import { MatTreeNestedDataSource } from '@angular/material/tree';
//import { NestedTreeControl } from '@angular/cdk/tree';
import { MatExpansionModule } from '@angular/material/expansion';

@Component({
    selector: "app-FAQ",
    templateUrl: "./FAQ.component.html",
    styleUrls: ['./FAQ.component.css'],
    //providers: [NgbAccordionConfig] // add the NgbAccordionConfig to the component providers
})

    /*
export class NgbdAccordionConfig {
    constructor(config: NgbAccordionConfig) {
        // customize default values of accordions used by this component tree
        config.closeOthers = true;
        config.type = 'danger';
    }
}
*/


export class FAQComponent {
    alleQuestions: Array<Question>;
    laster: boolean;
    skjema: FormGroup;
    skjemaStatus: string;
    visSkjema: boolean;
    visQuestionListe: boolean;
    public currentCount = 0;

    clickedLike = false;
    clickedDislike = false;

    panelOpenState = false;

    //nestedDataSource: MatTreeNestedDataSource<Question>;
    //nestedTreeControl: NestedTreeControl<Question>;

    /*
    private _url: string = "api/question/";

    

    hentAlleQuestions(): Observable<Question[]> {
        //this.laster = "Vennligst vent";
        return this._http.get<Question[]>(this._url);
          
    }
    */
    constructor(private _http: HttpClient, private fb: FormBuilder) {
        this.skjema = fb.group({
            id: [""],
            sporsmal: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            svar: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],      
            ratingOpp: [null, Validators.compose([Validators.required, Validators.pattern("[0-9]{1}")])],
            ratingNed: [null, Validators.compose([Validators.required, Validators.pattern("[0-9]{1}")])]
        });

    }

    ngOnInit() {
        this.laster = true;
        this.hentAlleQuestions();
        this.visSkjema = false;
        this.visQuestionListe = true;
        this.panelOpenState = false;
    }

    hentAlleQuestions() {
        this._http.get<IQuestion[]>("api/FAQ/")
            .subscribe(
                Questions => {
                    this.alleQuestions = Questions;
                    this.laster = false;
                    console.log("ferdig post-api/FAQ");
                },
                error => alert(error)
            );
    };

    vedSubmit() {
        if (this.skjemaStatus == "Registrere") {
            this.lagreQuestion();
        }
        else {
            alert("Feil i applikasjonen!");
        }
    }

    registrerQuestion() {
        // må resette verdiene i skjema dersom skjema har blitt brukt til endringer
        this.skjema.setValue({
            id: "",
            sporsmal: "",
            svar: "",
            ratingOpp: "",
            ratingNed: ""
        });
        this.skjema.markAsPristine(); // sett skjemaet til "uberørt" slik at det ikke kommer validerings-feilmeldinger
        this.visQuestionListe = false;
        this.skjemaStatus = "Registrere";
        this.visSkjema = true;
    }

    tilbakeTilListe() {
        this.visQuestionListe = true;
        this.visSkjema = false;
    }
  public incrementCounter() {
        this.currentCount++;
    }
    lagreQuestion() {
        var lagretQuestion = new Question();

        lagretQuestion.sporsmal = this.skjema.value.sporsmal;
        lagretQuestion.svar = this.skjema.value.svar;
        lagretQuestion.ratingOpp = this.skjema.value.ratingOpp;
        lagretQuestion.ratingNed = this.skjema.value.ratingNed;

        const body: string = JSON.stringify(lagretQuestion);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.post("api/FAQ/Question", body, { headers: headers })
            .subscribe(
                retur => {
                    this.hentAlleQuestions();
                    this.visSkjema = false;
                    this.visQuestionListe = true;
                    console.log("ferdig post-api/FAQ");
                },
                error => alert(error)
            );
    };

    // her blir rating hentet
    endreRating(id: number, sporsmal: string, svar: string, ratingOpp: number, ratingNed: number, tester: number) {

        switch (tester) {
            case 0:
                ratingOpp++;
                this.endreEnRating(id, sporsmal, svar, ratingOpp, ratingNed);
                console.log("Like was called!");
                break;
            case 1:
                ratingNed--;
                this.endreEnRating(id, sporsmal, svar, ratingOpp, ratingNed);
                console.log("Dislike was called!");
                break;
        }
    }

  

    // her blir den endrede rating lagret
    
    endreEnRating(id: number, sporsmal: string, svar: string, ratingOpp: number, ratingNed: number) {
        const endretFAQ = new Question();

 
        endretFAQ.sporsmal = sporsmal;
        endretFAQ.svar = svar;
        endretFAQ.ratingOpp = ratingOpp;
        endretFAQ.ratingNed = ratingNed;
        

        const body: string = JSON.stringify(endretFAQ);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.put("api/FAQ/" + id, body, { headers: headers })
            .subscribe(
                () => {
                    this.hentAlleQuestions();
                    
                    console.log("ferdig post-api/FAQ");
                },
                error => alert(error),
            );
    }
    
}
