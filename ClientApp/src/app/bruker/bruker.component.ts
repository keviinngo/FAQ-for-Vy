import { Component, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Bruker, IBruker } from "./bruker";
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: "app-bruker",
    templateUrl: "./bruker.component.html",
    styleUrls: ['./bruker.component.css'],
   
})

export class BrukerComponent {
    alleBrukere: Array<Bruker>;
    laster: boolean;
    skjema: FormGroup;
    skjemaStatus: string;
    visBrukerListe: boolean;

    constructor(private _http: HttpClient, private fb: FormBuilder) {
        this.skjema = fb.group({
            id: [""],
            email: [null, Validators.compose([Validators.required, Validators.pattern("^[a-zA-ZøæåØÆÅ0-9]+(\.[_a-zA-ZøæåØÆÅ0-9]+)*@[a-zA-ZøæåØÆÅ0-9-]+(\.[a-zA-ZøæåØÆÅ0-9-]+)*(\.[a-z]{2,15})$")])],
            fornavn: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            etternavn: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])],
            adresse: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ0-9\\-. ]{2,30}")])],
            brukersporsmal: [null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-.?! ]{2,150}")])],
        });

    }

    ngOnInit() {
        this.laster = true;
        this.skjemaStatus = "Registrere";
        this.hentAlleBrukere();
        this.visBrukerListe = true;
    }

    hentAlleBrukere() {
        this._http.get<IBruker[]>("api/FAQ/Bruker")
            .subscribe(
                Brukere => {
                    this.alleBrukere = Brukere;
                    this.laster = false;
                    console.log("ferdig post-api/FAQ/Bruker");
                },
                error => alert(error)
            );
    };

    vedSubmit() {       
        this.lagreBruker();
        this.registrerBruker();
    }

    registrerBruker() {
        // resette verdiene i skjema 
        this.skjema.setValue({
            id: "",
            email: "",
            fornavn: "",
            etternavn: "",
            adresse: "",
            brukersporsmal: ""

        });
        this.skjema.markAsPristine(); // sett skjemaet til "uberørt" slik at det ikke kommer validerings-feilmeldinger       
        this.skjemaStatus = "Registrere";
    }

    lagreBruker() {
        var lagretBruker = new Bruker();

        lagretBruker.email = this.skjema.value.email;
        lagretBruker.fornavn = this.skjema.value.fornavn;
        lagretBruker.etternavn = this.skjema.value.etternavn;
        lagretBruker.adresse = this.skjema.value.adresse;
        lagretBruker.brukersporsmal = this.skjema.value.brukersporsmal;

        const body: string = JSON.stringify(lagretBruker);
        const headers = new HttpHeaders({ "Content-Type": "application/json" });

        this._http.post("api/FAQ/Bruker", body, { headers: headers })
            .subscribe(
                retur => {
                    this.hentAlleBrukere();                    
                    this.visBrukerListe = true;
                    console.log("ferdig post-api/FAQ/Bruker");
                },
                error => alert(error)
            );
    };

    sletteBruker(id: number) {
        this._http.delete("api/FAQ/" + id)
            .subscribe(
                () => {
                    this.hentAlleBrukere();
                    console.log("ferdig delete-api/FAQ");
                },
                error => alert(error),
            );
    };

}
