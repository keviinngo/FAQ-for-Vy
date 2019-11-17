import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Question, IQuestion } from "./question";


@Component({
    selector: "app-FAQ",
    templateUrl: "./FAQ.component.html",
    styleUrls: ['./FAQ.component.css'],
})



export class FAQComponent {
    alleQuestions: Array<Question>;
    laster: boolean;
    skjema: FormGroup;
    clickedLike = false;
    clickedDislike = false;

    
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
    }

    hentAlleQuestions() {
        this._http.get<IQuestion[]>("api/FAQ/")
            .subscribe(
                Questions => {
                    this.alleQuestions = Questions;
                    this.laster = false;
                    console.log("Henter alle FAQ");
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
